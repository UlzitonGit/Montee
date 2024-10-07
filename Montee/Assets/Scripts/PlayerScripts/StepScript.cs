using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepScript : MonoBehaviour
{
    [SerializeField] public PlayerMovement stepFunc;
    // Start is called before the first frame update
    public void Step()
    {
        stepFunc.PlaySoundStep();
    }
}
