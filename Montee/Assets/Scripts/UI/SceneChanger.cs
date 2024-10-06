using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;
public class SceneChanger : MonoBehaviour
{
    AsyncOperation asyncOperation;
    [SerializeField] UnityEngine.UI.Image loadBar;
    [SerializeField] int sceneID;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject menuPanel;
    
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(sceneID);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            loadBar.fillAmount = progress;
            yield return 0;
        }
    }
    public void StartButtonClick()
    {
        menuPanel.SetActive(false);
        loadingPanel.SetActive(true);
        StartCoroutine(LoadScene());
    }
}
