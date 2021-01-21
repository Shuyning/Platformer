using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHero : MonoBehaviour
{
    [SerializeField] GameObject hero;
    [SerializeField] Sprite[] heroSprite;

    SpriteRenderer mainSprite;
    Animator animator;
    readonly string heroSelect = "heroSelect";
    int getChar;

    void Start()
    {
        mainSprite = hero.GetComponent<SpriteRenderer>();
        animator = hero.GetComponent<Animator>();
        Debug.Log("turn####");

        getChar = PlayerPrefs.GetInt(heroSelect) - 1;

        for(int i = 0; i < heroSprite.Length; i++)
        {
            if(getChar == i)
            {
                mainSprite.sprite = heroSprite[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        getChar = PlayerPrefs.GetInt(heroSelect) - 1;

        

        if(heroSprite[getChar] != mainSprite.sprite)
        {
            Debug.Log("swap sprite");
            mainSprite.sprite = heroSprite[getChar];
        }
    }
}
