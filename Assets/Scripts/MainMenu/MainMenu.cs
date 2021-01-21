using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject levePanel;
    public GameObject settingPanel;
    public GameObject changePanel;
    public Slider volumeSett;

    void Start()
    {
        Debug.Log(volumeSett.value);
        menuPanel.SetActive(true);
        levePanel.SetActive(false);
        settingPanel.SetActive(false);
        changePanel.SetActive(false);
        volumeSett.value = PlayerPrefs.GetFloat("VolumeSound");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    private void Update() 
    {
        PlayerPrefs.SetFloat("VolumeSound", volumeSett.value);
    }
}
