using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectEMP : MonoBehaviour
{

    private void Awake()
    {
        SoundScripts EMPImpact = FindObjectOfType<SoundScripts>();
         
        EMPImpact.EMPImpactSound();
    }
}
