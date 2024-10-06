using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask playerLayer;
    private float bulletSpeed = 20f;
    private Rigidbody2D rbBullet;
    [SerializeField] Vector3 dir;


    void Update()
    {
        CheckGround();
        transform.Translate(dir * bulletSpeed * Time.deltaTime);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f, groundLayer);
        if (collider.Length > 0)
        {
            Destroy(gameObject);
        }
    }
}
