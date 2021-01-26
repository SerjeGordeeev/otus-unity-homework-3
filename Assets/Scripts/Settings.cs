using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundsSlider;
    public AudioMixer gameAudioMixer;

    private void OnEnable()
    {
        musicSlider.onValueChanged.AddListener(MusicSliderValueChanged);
        soundsSlider.onValueChanged.AddListener(SoundsSliderValueChanged);
    }

    private void OnDisable()
    {
        musicSlider.onValueChanged.RemoveListener(MusicSliderValueChanged);
        soundsSlider.onValueChanged.RemoveListener(SoundsSliderValueChanged);
    }

    private void MusicSliderValueChanged(float value)
    {
        gameAudioMixer.SetFloat("Background", value - musicSlider.maxValue);
    }

    private void SoundsSliderValueChanged(float value)
    {
        gameAudioMixer.SetFloat("Sounds", value - musicSlider.maxValue);
    }
}
