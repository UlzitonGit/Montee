using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Transform player;
    public int index;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Checkpoint") == index)
        {
            player.position = transform.position;
        }
        Debug.Log(PlayerPrefs.GetInt("Checkpoint"));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("Checkpoint") < index)
            {
                PlayerPrefs.SetInt("Checkpoint", index);
            }
        }
    }
}
