using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject summonBullet;
    [SerializeField] Transform spawnPoint;
    bool canShoot = true;
    [SerializeField] SoundScripts EMPSFX;
    [SerializeField] Image reload;
    float reloads = 0;
    bool isReloading = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            Shoot();
        }
        if(isReloading == true)
        {
            
            reloads += Time.deltaTime;
            reload.fillAmount = reloads;
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
        isReloading = true;
        reload.enabled = true;
        yield return new WaitForSeconds(1);
        reload.enabled = false;
        reloads = 0;
        isReloading = false;
        canShoot = true;
    }
}
