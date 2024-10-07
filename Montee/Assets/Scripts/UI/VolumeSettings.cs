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
    [SerializeField] GameObject optionsPanel;
    bool panelActive = false;
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
        if (Input.GetKeyDown(KeyCode.P) && panelActive == false)
        {
            optionsPanel.SetActive(true);
            Time.timeScale = 0;
            panelActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && panelActive == true)
        {
            optionsPanel.SetActive(false);
            Time.timeScale = 1;
            panelActive = false;
            Sett();
        }
    }
    public void Sett()
    {
        musicVolume = musicSlider.value;
        sfxVolume = SFXSlider.value;
        Music.volume = musicVolume;
        SFX.volume = sfxVolume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }
  
}
