using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume()         // ���������� �� �������
    {
        float musicVolume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicVolume); // ���� ��������
        myMixer.SetFloat("music", Mathf.Log10(musicVolume)*20); // ������ ������ ����
    }
    public void SetSFXVolume()         // ���������� �� �������
    {
        float SFXVolume = musicSlider.value;
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume); // ���� ��������
        myMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20); // ������ ������ ����
    }
}
