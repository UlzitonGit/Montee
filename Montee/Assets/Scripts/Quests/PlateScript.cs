using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            door.transform.position = Vector2.MoveTowards(door.transform.position, new Vector2(target.position.x, target.position.y), 0.1f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {

        }
    }
    }
