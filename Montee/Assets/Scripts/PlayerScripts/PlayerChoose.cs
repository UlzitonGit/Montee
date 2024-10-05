using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoose : MonoBehaviour
{
    public bool heroActive = true;
    public bool summonActive = false;
    public bool isSummonSpawned = false;
    [SerializeField] PlayerMovement player;
    public PlayerMovement summon;
    ThrowSummon thrwSummon;
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
    }
    public void ChangeControl()
    {
        print("h");
        if (heroActive == true && isSummonSpawned == true)
        {
            //player.rb.isKinematic = true;
            //summon.rb.isKinematic = false;
            heroActive = false;
            summonActive = true;
            player.enabled = heroActive;
            summon.enabled = summonActive;
            player.rb.velocity = new Vector3(0, 0, 0);
        }
        else if (summonActive == true && isSummonSpawned == true)
        {
            //player.rb.isKinematic = false;
            //summon.rb.isKinematic = true;
            heroActive = true;
            summonActive = false;
            player.enabled = heroActive;
            summon.enabled = summonActive;
            summon.rb.velocity = new Vector3(0, 0, 0);
        }
    }
    private void BackToPlayer()
    {
        //thrwSummon.isSpawned = false;
        //player.rb.isKinematic = false;
        isSummonSpawned = false;
        heroActive = true;
        summonActive = false;
        player.enabled = heroActive;
        summon.enabled = summonActive;
        Destroy(summon.gameObject);
    }
}
