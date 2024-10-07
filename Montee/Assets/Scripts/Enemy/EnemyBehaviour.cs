using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    PlayerMovement player;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Vector3 dir;
    [SerializeField] GameObject attackZone;
    [SerializeField] LayerMask stunLayer;
    [SerializeField] LayerMask basicLayer;
    [SerializeField] ParticleSystem part;
    [SerializeField] bool isRanged;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator anim;
    [SerializeField] float offset;
    private bool isRaged = false;
    private bool isActive = true;
    bool canAttack = true;
    bool dashing = false;
    bool canDash = true;
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
        if(dashing && player.transform.position.x > transform.position.x)
        {
            transform.Translate(dir * 3 * Time.deltaTime);
            spriteRenderer.flipX = true;
        }
        if (dashing && player.transform.position.x < transform.position.x)
        {
            transform.Translate(dir * -3 * Time.deltaTime);
            spriteRenderer.flipX = false;
        }
        if (isRanged == true)
        {
            Vector3 difference = player.transform.position - firePoint.transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            firePoint.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }
        if(isRaged == true && canDash == true )
        {
            StartCoroutine(Dashing());
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
        SoundScripts EMPImpact = FindObjectOfType<SoundScripts>();

        EMPImpact.EMPImpactSound();
    }
    IEnumerator Dashing()
    {
        canDash = false;
        dashing = true;
        yield return new WaitForSeconds(0.5f);
        dashing = false;
        if(isActive ==true) StartCoroutine(AttackReload());
        yield return new WaitForSeconds(2f);
        canDash = true;
    }
    IEnumerator Stunning()
    {
        isActive = false;
        part.Play();
        gameObject.layer = 9;
        anim.SetBool("Shocked", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("Shocked", false);
        gameObject.layer = 7;
        isActive = true;
    }
    
    IEnumerator AttackReload()
    {
         anim.SetTrigger("Attack");
         yield return new WaitForSeconds(0.2f);
        SoundScripts EMPImpact = FindObjectOfType<SoundScripts>();

        EMPImpact.KickSound();
        GameObject att = Instantiate(attackZone, transform.position, transform.rotation);
         yield return new WaitForSeconds(0.2f);
         Destroy(att.gameObject);         
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
