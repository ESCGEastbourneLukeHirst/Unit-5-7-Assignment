using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SFXSlider : MonoBehaviour
{
    public TMP_Text volumeText;
    public Slider sfxSlider;
    public AudioMixer musicMixer;
    public string sfxMixerParameter = "SFXVolume";

    private void Start()
    {
        // Load the saved music volume, or set it to the default value of 1 if it hasn't been set yet
        sfxSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Add a listener for the slider value change
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // Update the volume text with the initial value
        volumeText.text = sfxSlider.value.ToString("0.00");
    }

    private void SetSFXVolume(float value)
    {                                         
        // Update the music volume in the audio mixer
        musicMixer.SetFloat(sfxMixerParameter, Mathf.Log10(value) * 20f);

        // Save the music volume for future use
        PlayerPrefs.SetFloat("SFXVolume", value);

        // Save the player preferences immediately
        PlayerPrefs.Save();

        // Update the volume text with the new value
        volumeText.text = value.ToString("0.00");
    }
}
