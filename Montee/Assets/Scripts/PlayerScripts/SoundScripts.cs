using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScripts : MonoBehaviour
{
    [SerializeField] public PlayerMovement playerFunc;
    // Start is called before the first frame update
    public void Step()
    {
        playerFunc.PlaySoundStep();
    }
    public void Jump()
    {
        playerFunc.PlaySoundJump();
    }
}
