using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPart : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    // Start is called before the first frame update
    public void Part()
    {
        _particleSystem.Play();
    }
}
