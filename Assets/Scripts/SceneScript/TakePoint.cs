using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePoint : MonoBehaviour
{
    public Animator anim;
    public AudioSource source;
    public AudioClip takeClip;
    SpriteRenderer sprite;
    BoxCollider2D bx;
    HealthPoint healthPoint;
    public int heal;

    public float timeWait, timeRespawn, countRespawn;
    float startTime = 0;
    float timeBtwRespawn = 0;
    bool activeModel;

    private void Start() 
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isStay", true);
        source = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
        healthPoint = GameObject.FindObjectOfType<HealthPoint>();
        activeModel = true;
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            sprite.enabled = false;
            bx.enabled = false;
            source.PlayOneShot(takeClip, 0.5f);
            healthPoint.TakeHealth(heal);
            countRespawn--;

            if(countRespawn <= 0)
            {
                Destroy(gameObject, 1.5f);
            }
            else
            {
                activeModel = false;
            }
            
        }
    }

    private void Update() 
    {
        playAnim();
        Respawn();
    }

    void playAnim()
    {
        if(activeModel)
        {
            startTime += Time.deltaTime;

            if(startTime >= timeWait)
            {
                startTime = 0;
                anim.SetBool("isStay", false);
            }
            else if(startTime > 0.5)
            {
                anim.SetBool("isStay", true);
            }
        }
    }

    void Respawn()
    {
        if(!activeModel)
        {
            timeBtwRespawn += Time.deltaTime;

            if(timeBtwRespawn >= timeRespawn)
            {
                sprite.enabled = true;
                bx.enabled = true;
                activeModel = true;
                startTime = 0;
            }
        }
    }
}
