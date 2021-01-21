using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    Animator anim;
    public AudioSource source;
    public AudioClip deadClip;
    public float speed;
    public int i;
    public float health;
    bool dead;

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if(health > 0)
        {
            anim.SetBool("takeDamage", true);
            Physics2D.IgnoreLayerCollision(10, 11, true);
            Invoke("MissPlayer", 3f);
        }
    }

    public void MissPlayer()
    {
        anim.SetBool("takeDamage", false);
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    private void Start() 
    {
        anim = GetComponent<Animator>();
        dead = false;
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(i * speed, rb.velocity.y);
    }

    private void Update() 
    {
        if(health <= 0 && !dead)
        {
            dead = true;
            rb.mass = 10;
            boxCollider2D.enabled = false;
            source.PlayOneShot(deadClip, 0.5f);
            Destroy(gameObject, 4f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Border")
        {
            i *= -1;
        }
    }
}
