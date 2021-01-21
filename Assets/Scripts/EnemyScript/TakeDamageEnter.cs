using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEnter : MonoBehaviour
{
    public float damage;
    HealthPoint healthPoint;

    private void Start() 
    {
        healthPoint = GameObject.Find("Player").GetComponent<HealthPoint>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            healthPoint.TakeDamage(damage);
        }
    }
}
