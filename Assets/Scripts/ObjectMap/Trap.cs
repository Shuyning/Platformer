using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Rigidbody2D rb;
    HealthPoint healthPoint;
    Trap trap;
    [SerializeField] float damage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthPoint = GameObject.Find("Player").GetComponent<HealthPoint>();
        trap = GetComponent<Trap>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag.Equals("Player") && healthPoint != null)
        {
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag.Equals("Player") && healthPoint != null)
        {
            healthPoint.TakeDamage(damage);
        }
        
        if(other.collider != null)
        {
            healthPoint = null;
            Invoke("TurnKinematic", 2f);
        }
    }

    void TurnKinematic()
    {
        rb.isKinematic = true;
    }
}
