using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip coin;
    SpriteRenderer sprite;
    BoxCollider2D bx;
    bool enterBool;

    private void Start() 
    {
        enterBool = true;
        source = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player" && enterBool)
        {
            sprite.enabled = false;
            bx.enabled = false;
            enterBool = false;

            source.PlayOneShot(coin, 0.5f);
            
            if(GameManager.Instance.Coins < GameManager.Instance.MaxCoins)
            {
                GameManager.Instance.Coins++;
            }

            Invoke("DeleteObject", 0.5f);
            Debug.Log("enter");
        }
    }

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}
