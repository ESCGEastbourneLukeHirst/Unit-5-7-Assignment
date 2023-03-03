using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicSlider : MonoBehaviour
{
    public Slider musicSlider;
    public TextMeshProUGUI musicText;

    private void Start()
    {
        // Load the saved music volume, or set it to the default value of 1 if it hasn't been set yet
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Set the music volume text to the current value
        musicText.text = musicSlider.value.ToString("0.00");

        // Add a listener for the slider value change
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void SetMusicVolume(float value)
    {
        // Update the music volume in the audio source
        AudioListener.volume = value;

        // Update the music volume text
        musicText.text = value.ToString("0.00");

        // Save the music volume for future use
        PlayerPrefs.SetFloat("MusicVolume", value);

        // Save the player preferences immediately
        PlayerPrefs.Save();
    }
}
