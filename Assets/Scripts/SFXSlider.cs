using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SFXSlider : MonoBehaviour
{
    public TMP_Text volumeText;
    public Slider sfxSlider;
    public AudioMixerGroup sfxMixerGroup;
    public string sfxMixerParameter = "SFXVolume";

    private void Start()
    {
        // Load the saved SFX volume, or set it to the default value of 1 if it hasn't been set yet
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Add a listener for the slider value change
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // Update the volume text with the initial value
        volumeText.text = sfxSlider.value.ToString("0.00");

        // Set the initial SFX volume in the audio mixer group
        sfxMixerGroup.audioMixer.SetFloat(sfxMixerParameter, Mathf.Log10(sfxSlider.value) * 20f);
    }

    private void SetSFXVolume(float value)
    {
        // Update the SFX volume in the audio mixer group
        sfxMixerGroup.audioMixer.SetFloat(sfxMixerParameter, Mathf.Log10(value) * 20f);

        // Save the SFX volume for future use
        PlayerPrefs.SetFloat("SFXVolume", value);

        // Save the player preferences immediately
        PlayerPrefs.Save();

        // Update the volume text with the new value
        volumeText.text = value.ToString("0.00");
    }
}

