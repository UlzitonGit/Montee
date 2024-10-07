using System.Collections;
using UnityEngine;

public class PlayerChoose : MonoBehaviour
{
    public bool heroActive = true;
    public bool summonActive = false;
    public bool isSummonSpawned = false;
    [SerializeField] PlayerMovement player;
    public PlayerMovementSumnmon summon;
    ThrowSummon thrwSummon;
    [SerializeField] GameObject mainCamera;
    [SerializeField] PhysicsMaterial2D physicsMaterialActive;
    [SerializeField] PhysicsMaterial2D physicsMaterialInActive;
    bool backing = false;
    bool isBack= false;
    [SerializeField] float timeToBack;
    public float currentTime = 0;
    [SerializeField] Animator playerAnimFix;
    private void Start()
    {
        thrwSummon = GetComponentInChildren<ThrowSummon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) )
        {
            ChangeControl();
        }
        if (Input.GetKeyDown(KeyCode.B) && summon != null)
        {
            StartCoroutine(BackToPlayer());
        }
        CameraController();
        if(backing == true)
        {
            if(summon != null) summon.transform.position = Vector3.Lerp(summon.transform.position, player.transform.position, 2.5f * Time.deltaTime);
        }
        if(heroActive == true && summon != null)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= timeToBack )
            {
                currentTime = 0;
                StartCoroutine(BackToPlayer());
            }
        }
    }
    public void ChangeControl()
    {
        //print("h");
        if (heroActive == true && isSummonSpawned == true && backing == false)
        {
            player.rb.sharedMaterial = physicsMaterialInActive;
            summon.rb.sharedMaterial = physicsMaterialActive;
            heroActive = false;
            summonActive = true;
            player.enabled = heroActive;
            summon.enabled = summonActive;
            player.rb.velocity = new Vector3(0, 0, 0);
        }
        else if (summonActive == true && isSummonSpawned == true)
        {
            player.rb.sharedMaterial = physicsMaterialActive;
            summon.rb.sharedMaterial = physicsMaterialInActive;
            currentTime = 0;
            heroActive = true;
            summonActive = false;
            player.enabled = heroActive;
            summon.enabled = summonActive;
            summon.rb.velocity = new Vector3(0, 0, 0);
        }
    }
  
    IEnumerator BackToPlayer()
    {
        if(isBack == false)
        {           
            isBack = true;
            backing = true;
            summon.rb.isKinematic = true;
            summon.GetComponent<CapsuleCollider2D>().enabled = false;
            summon.enabled = false;
            if (heroActive == false) ChangeControl();
            yield return new WaitForSeconds(3);
            backing = false;
            isSummonSpawned = false;
            heroActive = true;
            summonActive = false;
            player.enabled = heroActive;
            summon.enabled = summonActive;
            Destroy(summon.gameObject);
            thrwSummon.isSpawned = false;
            isBack = false;
        }
    }

    private void CameraController()
    {
        if (summonActive == true)
        {
            playerAnimFix.SetInteger("State", 0);
            Vector3 pos = summon.transform.position;
            pos.z = -10f;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, pos, Time.deltaTime);
        }
        if (heroActive == true && summonActive == false)
        {
            Vector3 pos = player.transform.position;
            pos.z = -10f;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, pos, Time.deltaTime);
        }
    }
}
