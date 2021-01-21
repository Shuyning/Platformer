using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    private int pRounded;
    public static int needLevel;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(LaunchLevel());
        }

        if(PlayerPrefs.GetInt("LevelComplete") == 0)
        {
            PlayerPrefs.SetInt("LevelComplete", 1);
        }
    }

    IEnumerator LaunchLevel()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(needLevel);

        while(async.isDone == false)
        {
            float p = async.progress * 100f;
            pRounded = Mathf.RoundToInt(p);
            yield return true;
        }
    }
}

