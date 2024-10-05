using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerChoose : MonoBehaviour
{
    public bool heroActive = true;
    public bool summonActive = false;
    public bool isSummonSpawned = false;
    [SerializeField] PlayerMovement player;
    public PlayerMovement summon;
    ThrowSummon thrwSummon;
    [SerializeField] GameObject mainCamera;
    private void Start()
    {
        thrwSummon = GetComponentInChildren<ThrowSummon>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeControl();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            BackToPlayer();
        }
        CameraController();
    }
    public void ChangeControl()
    {
        print("h");
        if (heroActive == true && isSummonSpawned == true)
        {
            
            heroActive = false;
            summonActive = true;
            player.enabled = heroActive;
            summon.enabled = summonActive;
            player.rb.velocity = new Vector3(0, 0, 0);
        }
        else if (summonActive == true && isSummonSpawned == true)
        {
          
            heroActive = true;
            summonActive = false;
            player.enabled = heroActive;
            summon.enabled = summonActive;
            summon.rb.velocity = new Vector3(0, 0, 0);
        }
    }
    private void BackToPlayer()
    {
        
        
        isSummonSpawned = false;
        heroActive = true;
        summonActive = false;
        player.enabled = heroActive;
        summon.enabled = summonActive;
        Destroy(summon.gameObject);
        thrwSummon.isSpawned = false;
    }

    private void CameraController()
    {
        if (summonActive == true)
        {
            Vector3 pos = summon.transform.position;
            pos.z = -10f;
            mainCamera.transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        }
        if (heroActive == true && summonActive == false)
        {
            Vector3 pos = player.transform.position;
            pos.z = -10f;
            mainCamera.transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        }
    }
}
