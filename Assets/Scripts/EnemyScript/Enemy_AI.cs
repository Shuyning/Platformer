using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    public AudioSource source;
    public AudioClip deadClip;
    public Transform[] movePoint;
    public float speed, powerJump;
    public float health;
    public float rayDistans;
    bool dead;
    bool movingRight = true;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Start() 
    {
        dead = false;
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();

        Physics2D.queriesStartInColliders = false;
    }

    private void FixedUpdate() 
    {
        
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

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(transform.position.x <= movePoint[0].position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
        else if(transform.position.x >= movePoint[1].position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }

        if(movingRight && !dead)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, rayDistans);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.tag.Equals("Player") == hit.collider)
                {
                    return;
                }

                rb.velocity = Vector2.up * powerJump;
            }
        }
        else if(!movingRight && !dead)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.left, rayDistans);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.tag.Equals("Player") == hit.collider)
                {
                    return;
                }

                rb.velocity = Vector2.up * powerJump;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistans);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.left * rayDistans);
    }
}
