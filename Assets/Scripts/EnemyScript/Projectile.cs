using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed, damage;
    public Rigidbody2D rb;
    Transform player;
    HealthPoint playerHP;
    Vector2 target; 

    void Start()
    {
        player = GameObject.Find("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        playerHP = GameObject.Find("Player").GetComponent<HealthPoint>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            DestroyProjectile();
            playerHP.TakeDamage(damage);
        }
        else if(other.gameObject.tag.Equals("Boss"))
        {

        }
        else
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
