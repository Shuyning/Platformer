using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public float damage, powerUp;
    CharacterMove character;

    private void Start() 
    {
        character = FindObjectOfType<CharacterMove>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            character.Jump(powerUp);
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            Debug.Log("enemyHit");
        }
        else if(other.gameObject.tag == "EnemyAI")
        {
            character.Jump(powerUp);
            other.GetComponent<Enemy_AI>().TakeDamage(damage);
            Debug.Log("enemyHit");
        }
        else if(other.gameObject.tag == "Boss")
        {
            character.Jump(powerUp);
            other.GetComponent<BossScript>().TakeDamage(damage);
            Debug.Log("bossHit " + other.GetComponent<BossScript>().health);
        }
    }
}
