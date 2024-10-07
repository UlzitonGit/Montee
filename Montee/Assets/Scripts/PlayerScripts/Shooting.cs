using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject summonBullet;
    [SerializeField] Transform spawnPoint;
    bool canShoot = true;
    [SerializeField] SoundScripts EMPSFX;

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
        EMPSFX.EMPSound();
    }
    private IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
