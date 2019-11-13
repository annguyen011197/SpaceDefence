using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject level;
    public GameObject loading;
    public GameObject option;

    public string level1Scence;
    public string level2Scence;

    private void Awake()
    {
#if UNITY_STANDALONE
        Screen.SetResolution(720, 1280, false);
        Screen.fullScreen = false;
#endif
    }
    public void PlayButtonClicked()
    {
        mainMenu.SetActive(false);
        level.SetActive(true);
    }

    public void OptionClicked()
    {
        option.SetActive(true);
    }

    public void Level1()
    {
        StartCoroutine(loadScence(level1Scence));
        // SceneManager.LoadScene(level1Scence);
    }

    public void Level2()
    {
        StartCoroutine(loadScence(level2Scence));
    }

    public IEnumerator loadScence(string name)
    {
        loading.SetActive(true);
        var asyncLoader = SceneManager.LoadSceneAsync(name);
        asyncLoader.allowSceneActivation = false;
        while (!asyncLoader.isDone)
        {
            if (asyncLoader.progress >= .9f)
            {
                yield return new WaitForSeconds(1);
                Debug.Log(asyncLoader.progress);
                asyncLoader.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
