using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Animator[] animator;
    [SerializeField] ParticleSystem part;
    [SerializeField] GameObject light;
    public int index;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Checkpoint") == index)
        {
            player.position = transform.position;

            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].SetTrigger("Start");
            }
            part.Play();
            light.SetActive(true);
            PlayerPrefs.SetInt("Checkpoint", index);
        }
        Debug.Log(PlayerPrefs.GetInt("Checkpoint"));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().GetDamage(-100);
            if (PlayerPrefs.GetInt("Checkpoint") < index)
            {
                for (int i = 0; i < animator.Length; i++)
                {
                    animator[i].SetTrigger("Start");
                }
                part.Play();
                light.SetActive(true);
                PlayerPrefs.SetInt("Checkpoint", index);
            }
        }
    }
}
