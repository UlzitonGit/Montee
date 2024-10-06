using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Transform target;
    [SerializeField] Transform target2;
    public bool onPressed = false;
    Transform pos;
    void Start()
    {
        pos = door.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(onPressed == true) door.transform.position = Vector2.MoveTowards(door.transform.position, new Vector2(target.position.x, target.position.y), 3 * Time.deltaTime);
        if(onPressed == false) door.transform.position = Vector2.MoveTowards(door.transform.position, new Vector2(target2.position.x, target2.position.y), 3 * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            onPressed = true;
        }
        else onPressed = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            onPressed = false;
        }
    }

}
