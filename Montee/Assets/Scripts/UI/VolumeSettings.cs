using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource SFX;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    float musicVolume;
    float sfxVolume;
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        musicSlider.value = musicVolume;
        SFXSlider.value = sfxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        musicVolume = musicSlider.value;
        sfxVolume = SFXSlider.value;
        Music.volume = musicVolume;
        SFX.volume = sfxVolume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }

  
}
