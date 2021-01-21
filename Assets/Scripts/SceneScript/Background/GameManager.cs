using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    public class GameManager : Singlton<GameManager>
{
    GameObject tutorPanel;

    bool openTutor;
    int levelNumber;
    int currentLevel;
    [SerializeField] int coins;
    [SerializeField] int maxCoins;
    bool mainMenu;
    [SerializeField] int valueMaxCoin;
    float volumeCount = -1;
    SpawnHero spawnHero;

    public bool OpenTutor
    { 
        get
        {
            return openTutor;
        } 
        set
        {
            openTutor = value;
        }
    }
    public int LevelNumber
    { 
        get
        {
            return levelNumber;
        } 
        set
        {
            levelNumber = value;
        }
    }

    public int СurrentLevel
    { 
        get
        {
            return currentLevel;
        } 
        set
        {
            currentLevel = value;
        }
    }
    public int Coins
    { 
        get
        {
            return coins;
        } 
        set
        {
            coins = value;
        }
    }

    public int MaxCoins
    { 
        get
        {
            return maxCoins;
        } 
        set
        {
            maxCoins = value;
        }
    }

    public bool MainMenu
    { 
        get
        {
            return mainMenu;
        } 
        set
        {
            mainMenu = value;
        }
    }

    public int ValueMaxCoin
    { 
        get
        {
            return valueMaxCoin;
        } 
        set
        {
            valueMaxCoin = value;
        }
    }
    public GameObject TutorPanel
    { 
        get
        {
            return tutorPanel;
        } 
        set
        {
            tutorPanel = value;
        }
    }


    void Start()
    {
        mainMenu = true;

        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            mainMenu = false;
        }

        levelNumber = SceneManager.GetActiveScene().buildIndex;
        maxCoins = valueMaxCoin;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        volumeCount = PlayerPrefs.GetFloat("VolumeSound");

        if(volumeCount == -1)
        {
            PlayerPrefs.SetFloat("VolumeSound", 1);
        }
    }

    void Update()
    {
        if(tutorPanel == null)
        {
            tutorPanel = GameObject.Find("/Canvas/TutorPanel");
        }
        
        if(!openTutor && !mainMenu)
        {
            tutorPanel.SetActive(false);
        }
        else if(openTutor && !mainMenu)
        {
            tutorPanel.SetActive(openTutor);
        }
        
        if(Input.GetKeyDown(KeyCode.U))
        {
            coins = maxCoins;
        }
    }
}


