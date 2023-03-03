using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SFXSlider : MonoBehaviour
{
    public TMP_Text volumeText;
    public Slider volumeSlider;
    public string sfxMixerParameter = "SFXVolume";

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
        AdjustVolume(volumeSlider.value);
    }

    private void SetSFXVolume(float value)
    {
        // Update the music volume in the audio mixer
        musicMixer.SetFloat(mixerVolumeParameter, Mathf.Log10(value) * 20f);

        // Save the music volume for future use
        PlayerPrefs.SetFloat("MusicVolume", value);

        // Save the player preferences immediately
        PlayerPrefs.Save();

        // Update the volume text with the new value
        volumeText.text = value.ToString("0.00");
    }
}
