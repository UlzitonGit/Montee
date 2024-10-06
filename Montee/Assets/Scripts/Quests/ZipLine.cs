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
    void Update()
    {
        if(zip == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, zip1.position, speed * Time.deltaTime);
        }
        if (zip == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, zip2.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Zip") && collision.gameObject == zip1.gameObject && zip == false)
        {
            zip = true;
        }
        if (collision.CompareTag("Zip") && collision.gameObject == zip2.gameObject && zip == true)
        {
            zip = false;
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().onZipLine = true;
            collision.transform.parent = transform;
            collision.GetComponent<PlayerMovement>().rb.isKinematic = true;
        }
    }
}
