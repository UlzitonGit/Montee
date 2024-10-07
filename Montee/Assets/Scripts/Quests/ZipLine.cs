using UnityEngine;

public class ZipLine : MonoBehaviour
{
    [SerializeField] Transform zip1;
    [SerializeField] Transform zip2;
    [SerializeField] int speed = 5;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.GetComponent<PlayerHealth>() != null)
        {
            if (collision.GetComponent<PlayerHealth>() != null)
            {
                collision.GetComponent<PlayerMovement>().onZipLine = true;
                collision.transform.parent = transform;
                collision.GetComponent<PlayerMovement>().rb.velocity = new Vector3 (0, 0, 0);
                collision.GetComponent<PlayerMovement>().rb.isKinematic = true;
            }
        }
    }
}
