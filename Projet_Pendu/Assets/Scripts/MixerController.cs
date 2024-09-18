using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer hangmanAudioMixer;

    public void SetMasterVolume(float sliderValue)
    {
        hangmanAudioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetBGMVolume(float sliderValue)
    {
        hangmanAudioMixer.SetFloat("BGMVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSFXVolume(float sliderValue)
    {
        hangmanAudioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
}
