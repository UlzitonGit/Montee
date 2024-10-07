using UnityEngine;

public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] float damage = 35;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerHealth>() != null) collision.GetComponent<PlayerHealth>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
