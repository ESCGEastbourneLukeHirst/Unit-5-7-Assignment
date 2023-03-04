using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MusicSlider : MonoBehaviour
{
    public Slider musicSlider;
    public TMP_Text volumeText;
    public AudioMixerGroup musicMixerGroup;
    public string musicMixerParameter = "MusicVolume";

    private void Start()
    {
        // Load the saved music volume, or set it to the default value of 1 if it hasn't been set yet
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Add a listener for the slider value change
        musicSlider.onValueChanged.AddListener(SetMusicVolume);

        // Set the initial music volume in the audio mixer
        musicMixerGroup.audioMixer.SetFloat(musicMixerParameter, Mathf.Log10(musicSlider.value) * 20f);

        // Update the volume text with the initial value
        volumeText.text = musicSlider.value.ToString("0.00");
    }

    private void SetMusicVolume(float value)
    {
        // Update the music volume in the audio mixer
        musicMixerGroup.audioMixer.SetFloat(musicMixerParameter, Mathf.Log10(value) * 20f);

        // Save the music volume for future use
        PlayerPrefs.SetFloat("MusicVolume", value);

        // Save the player preferences immediately
        PlayerPrefs.Save();

        // Update the volume text with the new value
        volumeText.text = value.ToString("0.00");
    }
}


