using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemyBehaviour : MonoBehaviour
{
    PlayerMovement player;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Vector3 dir;
    [SerializeField] GameObject attackZone;
    [SerializeField] LayerMask stunLayer;
    [SerializeField] LayerMask basicLayer;
    [SerializeField] bool isRanged;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    [SerializeField] float offset;
    private bool isRaged = false;
    private bool isActive = true;
    bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
        if (isRanged == true)
        {
            StartCoroutine(AttackRanged());
        }
        else
        {
            StartCoroutine(AttackReload());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == false) return;
        CheckPlayer();
        if(isRaged && player.transform.position.x > transform.position.x)
        {
            transform.Translate(dir * Time.deltaTime);
        }
        if (isRaged && player.transform.position.x < transform.position.x)
        {
            transform.Translate(dir * -1 * Time.deltaTime);
        }
        if (isRanged == true)
        {
            Vector3 difference = player.transform.position - firePoint.transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            firePoint.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }
    }
    private void CheckPlayer()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 15f, playerLayer);
        isRaged = collider.Length > 0;
    }
    public void Stun()
    {
        StartCoroutine(Stunning());
    }
    IEnumerator Stunning()
    {
        isActive = false;
        gameObject.layer = 9;
        yield return new WaitForSeconds(2);
        gameObject.layer = 7;
        isActive = true;
    }
    
    IEnumerator AttackReload()
    {
        yield return new WaitForSeconds(4);
        if(isRaged == true && isActive == true)
        {
            GameObject att = Instantiate(attackZone, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.2f);
            Destroy(att.gameObject);
            StartCoroutine(AttackReload());
        }
        else
        {
            StartCoroutine(AttackReload());
        }
    }
    IEnumerator AttackRanged()
    {
        yield return new WaitForSeconds(0.5f);
        if (isRaged == true && isActive == true)
        {
            GameObject att = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            StartCoroutine(AttackRanged());
        }
        else
        {
            StartCoroutine(AttackRanged());
        }
    }
    
}
