using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    public TMP_Text volumeText1;
    public TMP_Text volumeText2;
    public Slider volumeSlider1;
    public Slider volumeSlider2;

    private void Start()
    {
        volumeSlider1.value = PlayerPrefs.GetFloat("Volume1", 1);
        volumeSlider2.value = PlayerPrefs.GetFloat("Volume2", 1);

        volumeSlider1.onValueChanged.AddListener(value => AdjustVolume(value, volumeText1, 1));
        volumeSlider2.onValueChanged.AddListener(value => AdjustVolume(value, volumeText2, 2));
        AdjustVolume(volumeSlider1.value, volumeText1, 1);
        AdjustVolume(volumeSlider2.value, volumeText2, 2);
    }

    private void AdjustVolume(float value, TMP_Text volumeText, int sliderNumber)
    {
        volumeText.text = value.ToString("0.00");

        if (sliderNumber == 1)
        {
            AudioListener.volume = value;
            PlayerPrefs.SetFloat("Volume1", value);
        }
        else if (sliderNumber == 2)
        {
            AudioListener.volume = value;
            PlayerPrefs.SetFloat("Volume2", value);
        }

        PlayerPrefs.Save();
    }
}

