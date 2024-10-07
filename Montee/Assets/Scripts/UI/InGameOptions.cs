using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameOptions : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;
    bool panelActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void Back()
    {
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
        panelActive = false;
    }
}
