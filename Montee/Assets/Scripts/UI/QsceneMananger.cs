using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QsceneMananger : MonoBehaviour
{
    
    public void NewScene()
    {
        SceneManager.LoadScene(2);
    }
}
