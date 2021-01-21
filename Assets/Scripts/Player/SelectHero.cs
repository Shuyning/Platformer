using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectHero : MonoBehaviour
{
    public GameObject[] hero;

    SpriteRenderer[] sprite;

    int charInt = 1;
    int lengthHero = 0;
    readonly string heroSelect = "heroSelect";

    private void Awake() 
    {
        if(PlayerPrefs.GetInt(heroSelect) != 0)
        {
            charInt = PlayerPrefs.GetInt(heroSelect) - 1;
        }
        lengthHero = hero.Length;

        sprite = new SpriteRenderer[lengthHero];
        Debug.Log(lengthHero + " = lengthHero");

        for(int i = 0; i < lengthHero; i++)
        {
            sprite[i] = hero[i].GetComponent<SpriteRenderer>();

            if(i == charInt)
            {
                sprite[i].enabled = true;
            }
            else
            {
                sprite[i].enabled = false;
            }
        }
    }

    public void Next()
    {
        charInt++;
        Loop();

        for(int i = 0; i < sprite.Length; i++)
        {
            if(charInt == i)
            {
                sprite[i].enabled = true;
            }
            else
            {
                sprite[i].enabled = false;
            }
        }

        Debug.Log(charInt + " = char int");
        PlayerPrefs.SetInt(heroSelect, charInt + 1);
    }

    public void Previous()
    {
        charInt--;
        Loop();

        for(int i = 0; i < sprite.Length; i++)
        {
            if(charInt == i)
            {
                sprite[i].enabled = true;
            }
            else
            {
                sprite[i].enabled = false;
            }
        }

        Debug.Log(charInt + " = char int");
        PlayerPrefs.SetInt(heroSelect, charInt + 1);
    }

    void Loop()
    {
        Debug.Log(sprite.Length + " " + lengthHero + " Loop");
        if(charInt > lengthHero - 1)
        {
            charInt = 0;
        }
        else if(charInt < 0)
        {
            charInt = lengthHero - 1;
        }
    }
}
