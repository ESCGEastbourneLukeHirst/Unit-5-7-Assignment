using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public float musicVolume;
    public float sfxVolume;

    void Start()
    {
        Play("Background Music");
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        // Set the volume values from PlayerPrefs
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.Play();

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }

    }

    private void Update()
    {
        foreach (Sound s in sounds)
        {
            if (s.isMusic == true)
            {
                s.source.volume = s.volume * musicVolume;
            }
            else
            {
                s.source.volume = s.volume * sfxVolume;
            }
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Was not able to play! Please ensure you have typed in the correct name!");
            return;
        }
        s.source.Play();
    }
}