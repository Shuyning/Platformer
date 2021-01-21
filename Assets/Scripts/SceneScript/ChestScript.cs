using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    BoxCollider2D bx;
    Animator anim;
    bool enter, press;
    public static bool open;

    void Start()
    {
        press = true;
        anim = GetComponent<Animator>();
        bx = GetComponent<BoxCollider2D>();
        sprite.enabled = false;
        bx.enabled = false;
    }

    void Update()
    {
        if(GameManager.Instance.Coins == GameManager.Instance.MaxCoins && press)
        {
            sprite.enabled = true;
            bx.enabled = true;
        }

        if(enter && press)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Press F");
                anim.SetTrigger("isOpen");
                press = false;
                bx.enabled = false;
                open = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("ChestBox Enter");
            enter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
}
