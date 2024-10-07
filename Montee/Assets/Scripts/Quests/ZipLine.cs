using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    [SerializeField] Transform zip1;
    [SerializeField] Transform zip2;
    public bool zip = false;
    [SerializeField] int speed = 5;

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().onZipLine = true;
            collision.transform.parent = transform;
            collision.GetComponent<PlayerMovement>().rb.velocity = new Vector3 (0, 0, 0);
            collision.GetComponent<PlayerMovement>().rb.isKinematic = true;
        }
    }
}
