using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CLevelMenu : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    public Button reset;

    int levelComplete;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        level2.interactable = false;
        level3.interactable = false;

        switch(levelComplete)
        {
            case 2: level2.interactable = true;
            break;
            case 3: level2.interactable = true;
                    level3.interactable = true;
            break;
        }

        Debug.Log(levelComplete);
    }

    public void loadTo(int level)
    {
        GameManager.Instance.MainMenu = false;
        LoadingScript.needLevel = level + 1;
        SceneManager.LoadScene(1);
        GameManager.Instance.Coins = 0;
    }

    public void Reset()
    {
        level2.interactable = false;
        level3.interactable = false;

        PlayerPrefs.DeleteKey("LevelComplete");
    }

    public void LoadLastLevel()
    {
        Debug.Log(levelComplete);
        GameManager.Instance.MainMenu = false;
        if(levelComplete == 0)
        {
            LoadingScript.needLevel = 2;
        }
        else
        {
            LoadingScript.needLevel = levelComplete + 1;
        }
        
        SceneManager.LoadScene(1);
        GameManager.Instance.Coins = 0;
    }
}
