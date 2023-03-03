using System;
using UnityEngine;

public class MusicOnOff : MonoBehaviour
{
    [SerializeField] AudioSource music;

    public static MusicOnOff instance;

    private void Start()
    {
        AudioListener.volume = 1;
        int musicOn = PlayerPrefs.GetInt("musicOn", 1);
        if (musicOn == 1)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void OnMusic()
    {
        music.Play();
        PlayerPrefs.SetInt("musicOn", 1);
        PlayerPrefs.Save();
    }
    public void OffMusic()
    {
        music.Stop();
        PlayerPrefs.SetInt("musicOn", 0);
        PlayerPrefs.Save();
    }
}
