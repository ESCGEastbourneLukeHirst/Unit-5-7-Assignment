using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnOff : MonoBehaviour
{
    [SerializeField] AudioSource music;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        int musicOn = PlayerPrefs.GetInt("musicOn", 1);
        if (musicOn == 1)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
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
