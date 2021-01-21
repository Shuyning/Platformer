using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public Slider volumeSett;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        PlayerPrefs.SetFloat("VolumeSound", volumeSett.value);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
        pauseButton.SetActive(true);
    }

    public void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        pauseButton.SetActive(false);
    }

    public void LoadMenu()
    {
        GameManager.Instance.MainMenu = true;
        LoadingScript.needLevel = 0;
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start() 
    {
        volumeSett.value = PlayerPrefs.GetFloat("VolumeSound");
    }
}
