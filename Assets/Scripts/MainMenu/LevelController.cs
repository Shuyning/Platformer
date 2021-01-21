using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instanse = null;
    string nameScene;
    int sceneIndex;
    int levelComplete;
    int countScene;

    // Start is called before the first frame update
    void Start()
    {
        if(instanse == null)
        {
            instanse = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        countScene = SceneManager.sceneCountInBuildSettings - 1;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Debug.Log(sceneIndex + "  " + countScene);
    }

    public void isEndGame()
    {
        if(sceneIndex == countScene)
        {
            Invoke("LoadMainMenu", 0f);
        }
        else
        {
            if(levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            }
            Invoke("NextLevel", 1f);
        }
    }

    void NextLevel()
    {
        LoadingScript.needLevel = sceneIndex + 1;
        SceneManager.LoadScene(1);
        GameManager.Instance.Coins = 0;
    }

    public void LoadMainMenu()
    {
        LoadingScript.needLevel = 0;
        GameManager.Instance.MainMenu = true;
        SceneManager.LoadScene(1);
    }

    public void LoadThisLevel()
    {
        LoadingScript.needLevel = sceneIndex;
        SceneManager.LoadScene(sceneIndex);
        GameManager.Instance.Coins = 0;
    }
}
