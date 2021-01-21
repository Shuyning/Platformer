using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesScript : MonoBehaviour
{
    Animator anim;
    public GameObject coinCheck;
    public Transform coinCheckPosition;
    public int coinValue;

    private void Start() 
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(coinValue != 0)
            {
                Instantiate(coinCheck, coinCheckPosition.position, Quaternion.identity);
                anim.SetTrigger("Bit");
                coinValue--;
                
                if(GameManager.Instance.Coins < GameManager.Instance.MaxCoins)
                {
                    GameManager.Instance.Coins++;
                }
            }
        }
    }
}
