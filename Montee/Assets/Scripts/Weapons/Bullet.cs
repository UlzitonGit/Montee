using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject part;
    [SerializeField] LayerMask enemyLayer;
    private float bulletSpeed = 20f;
    private Rigidbody2D rbBullet;
    [SerializeField] Vector3 dir;


    void Update()
    {
        CheckEnemy();
        CheckGround();
        transform.Translate(dir * bulletSpeed * Time.deltaTime);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f, groundLayer);
        if (collider.Length > 0)
        {
            Instantiate(part, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void CheckEnemy()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f, enemyLayer);
        if (collider.Length > 0)
        {
            collider[0].GetComponent<EnemyBehaviour>().Stun();
            Destroy(gameObject);
        }
    }
}
