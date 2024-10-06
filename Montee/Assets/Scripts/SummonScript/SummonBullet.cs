using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBullet : MonoBehaviour
{
    private float bulletSpeed = 20f;
    private Rigidbody2D rbBullet;
    [SerializeField] Vector3 dir;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject toSummon;
    bool hited = false;
    void Start()
    {
        
    }

    void Update()
    {
        CheckGround();
        transform.Translate(dir * bulletSpeed * Time.deltaTime);
        if (hited == true)
        {
            GameObject summon = Instantiate(toSummon,transform.position, Quaternion.identity);
            PlayerChoose pl = FindFirstObjectByType<PlayerChoose>();
            pl.isSummonSpawned = true;         
            pl.summon = summon.GetComponent<PlayerMovement>();
            pl.ChangeControl();
            Destroy(gameObject);
        }
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.4f, groundLayer);
        hited = collider.Length > 0;

    }
}
