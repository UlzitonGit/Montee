using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScripts : MonoBehaviour
{
    [SerializeField] private AudioClip EMPSound1;
    [SerializeField] private AudioClip stepSound1;
    [SerializeField] private AudioClip stepSound2;
    [SerializeField] private AudioClip stepSound3;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip EMPImpact;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Step()
    {
        int rnd = Random.Range(1, 4);
        if (rnd == 1)
        {
            audioSource.PlayOneShot(stepSound1, PlayerPrefs.GetFloat("sfxVolume"));
        }
        else if (rnd == 2)
        {
            audioSource.PlayOneShot(stepSound2, PlayerPrefs.GetFloat("sfxVolume"));
        }
        else
        {
            audioSource.PlayOneShot(stepSound3, PlayerPrefs.GetFloat("sfxVolume"));
        }
    }
    public void Jump()
    {
        audioSource.PlayOneShot(jumpSound, PlayerPrefs.GetFloat("sfxVolume"));
    }
    public void EMPSound()
    {
        audioSource.PlayOneShot(EMPSound1, PlayerPrefs.GetFloat("sfxVolume"));
    }
    public void EMPImpactSound()
    {
        audioSource.PlayOneShot(EMPImpact, PlayerPrefs.GetFloat("sfxVolume"));
    }
}
