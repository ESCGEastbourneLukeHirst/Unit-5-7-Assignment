using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public AudioMixerGroup musicMixerGroup;
    public AudioMixerGroup sfxMixerGroup;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

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
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;

            // Set the appropriate mixer group for the sound
            if (s.isMusic)
            {
                s.source.outputAudioMixerGroup = musicMixerGroup;
            }
            else
            {
                s.source.outputAudioMixerGroup = sfxMixerGroup;
            }
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
            Debug.LogWarning("Sound: " + name + " was not able to play! Please ensure you have typed in the correct name.");
            return;
        }
        s.source.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
}
