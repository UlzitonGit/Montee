using System.Collections;
using UnityEngine;

public class SoundEffectEMP : MonoBehaviour
{

    private void Awake()
    {
        SoundScripts EMPImpact = FindObjectOfType<SoundScripts>();
         
        EMPImpact.EMPImpactSound();
        StartCoroutine(Aboba());
    }

    private IEnumerator Aboba()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
