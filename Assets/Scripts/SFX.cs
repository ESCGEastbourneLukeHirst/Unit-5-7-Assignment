using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SFX : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private TextMeshProUGUI volumeTextUI = null;

    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0, 0");
    }
    public void SaveVolumeButton()
    {
        float volume = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volume);
        LoadValues();
    }
    void LoadValues()
    {
        float volume = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volume;
        AudioListener.volume = volume;
    }
}
