using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChanger : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_AudioClip;
    bool changing = false;
    bool up = false;
    float musicVolume = 0;
    private void Update()
    {
        if (changing == true && up == false)
        {
            print("minus");
            m_AudioSource.volume -= 0.01f;           
        }
        if(m_AudioSource.volume <= 0 && changing == true)
        {
            up = true;
            changing = false;
            m_AudioSource.clip = m_AudioClip;
            m_AudioSource.Play();
        }

        if (up == true && m_AudioSource.volume < musicVolume)
        {
            print("plus");
           
            m_AudioSource.volume += 0.01f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
            changing = true;
        }
    }
}
