using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBullet : MonoBehaviour
{
    private float bulletSpeed = 20f;
    private Rigidbody2D rbBullet;
    [SerializeField] Vector3 dir;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(dir * bulletSpeed * Time.deltaTime);
    }
}
