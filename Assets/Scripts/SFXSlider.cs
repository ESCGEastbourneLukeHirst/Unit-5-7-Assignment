using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SFXSlider : MonoBehaviour
{
    public TMP_Text volumeText;
    public Slider volumeSlider;
    public AudioMixer sfxMixer;
    public string sfxMixerParameter = "SFXVolume";

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
        AdjustVolume(volumeSlider.value);
    }

    public void AdjustVolume(float value)
    {
        volumeText.text = value.ToString("0.00");
        sfxMixer.SetFloat(sfxMixerParameter, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}
