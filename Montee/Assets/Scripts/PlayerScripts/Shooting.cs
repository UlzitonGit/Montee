using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject summonBullet;
    [SerializeField] Transform spawnPoint;
    bool canShoot = true;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(summonBullet, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(Reload());
    }
    private IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
