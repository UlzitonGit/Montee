using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;
using NUnit.Framework.Internal.Filters;
public class SceneChanger : MonoBehaviour
{
    AsyncOperation asyncOperation;
    [SerializeField] UnityEngine.UI.Image loadBar;
    [SerializeField] int sceneID;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject continueButton;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Checkpoint") > 0)
        {
            continueButton.SetActive(true);
        }
        Debug.Log(PlayerPrefs.GetInt("Checkpoint"));
    }
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
    IEnumerator LoadSceneNew()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(1);
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
    public void NewGame()
    {
        PlayerPrefs.SetInt("Checkpoint", 0);
        menuPanel.SetActive(false);
        loadingPanel.SetActive(true);
        StartCoroutine(LoadSceneNew());

    }
}
