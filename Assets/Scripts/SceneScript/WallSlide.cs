using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public float distans = 3f;
    public float speed;
    CharacterMove character;
    Rigidbody2D rb;
    RaycastHit2D hit;
    void Start()
    {
        character = GetComponent<CharacterMove>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        
        if(character.flip)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distans);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distans);
        }
        

        if(!character.grounded && hit.collider != null)
        {
            if(rb.velocity.y < speed)
            {
                rb.velocity = new Vector2(0, speed);
            }
        }
    }
}
