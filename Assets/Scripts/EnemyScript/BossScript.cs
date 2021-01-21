using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float health, speed, stoppingDistans, retrealDistans;
    public float powerJump;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public GameObject exitPlane;
    public float groundCheckRadius = 0.5f;
    public bool grounded, move;
    bool dead;
    bool moveJump;
    int i;
    Rigidbody2D rb;
    GameObject player;
    SpriteRenderer sprite;
    Collider2D[] groundCollisions;
    CharacterMove character;
    Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        character = player.GetComponent<CharacterMove>();

        dead = false;
    }

    void Update()
    {
        groundCollisions = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);

        if(groundCollisions.Length > 0)
        {
            grounded = true;
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isJump", true);
            grounded = false;
        }

        if(!dead)
        {
            ChasePlayer();
        }

        if(health <= 0 && !dead)
        {
            dead = true;
            Physics2D.IgnoreLayerCollision(10, 11, true);
            anim.SetTrigger("isDeath");
            Invoke("DeadBoss", 3f);
        }
    }

    void ChasePlayer()
    {
        if(player.transform.position.x < transform.position.x)
        {
            i = 1;
            sprite.flipX = true;
        }
        else if(player.transform.position.x > transform.position.x)
        {
            i = -1;
            sprite.flipX = false;
        }

        if(move)
        {
            if(Vector2.Distance(transform.position, player.transform.position) > stoppingDistans)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else if(Vector2.Distance(transform.position, player.transform.position) < retrealDistans)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            }
        }

        if(Vector2.Distance(transform.position, player.transform.position) > stoppingDistans || Vector2.Distance(transform.position, player.transform.position) < retrealDistans)
        {
            
            move = true;
        }
        else
        {
            move = false;
        }
    }

    public void Jump(float power)
    {
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health > 0)
        {
            Physics2D.IgnoreLayerCollision(10, 11, true);
            Invoke("TakeOnEnterPlayer", 3f);
            anim.SetBool("TakeDamage", true);
        }
    }

    void DeadBoss()
    {
        exitPlane.SetActive(true);
        character.enabled = false;
        Destroy(gameObject);
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    void TakeOnEnterPlayer()
    {
        anim.SetBool("TakeDamage", false);
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
