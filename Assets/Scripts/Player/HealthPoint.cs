using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPoint : MonoBehaviour
{
    public int health;
    public int numberOflives;
    bool dead;

    public Image[] lives;

    public Sprite fullLive;
    public Sprite EmptyLive;
    public AudioSource source;
    public AudioClip deadClip;
    public Animator animator;

    CharacterMove character;
    CapsuleCollider2D capsuleCollider2D;
    CameraControllerScript cam;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        source.GetComponent<AudioSource>();
        character = GetComponent<CharacterMove>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        cam = GameObject.Find("Camera").GetComponent<CameraControllerScript>();
        cam.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > numberOflives)
        {
            health = numberOflives;
        }

        for(int i = 0; i < lives.Length; i++)
        {
            if(i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = EmptyLive;
            }

            if(i < numberOflives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }

        if(health <= 0 && !dead)
        {
            Debug.Log("Dead");
            cam.enabled = false;
            dead = true;
            capsuleCollider2D.isTrigger = true;
            character.Jump(1);
            source.PlayOneShot(deadClip, 0.5f);

            Invoke("LoadThisLevel", 1.5f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= (int)damage;
        
        if(health > 0)
        {
            Physics2D.IgnoreLayerCollision(10, 11, true);
            Invoke("TakeOnEnterEnemy", 3f);
            animator.SetBool("isTakeDamage", true);
        }
    }

    public void Dead()
    {
        health = 0;
    }

    public void TakeHealth(int point)
    {
        health += point;
    }

    void LoadThisLevel()
    {
        int thisLevel = SceneManager.GetActiveScene().buildIndex;
        dead = false;

        SceneManager.LoadScene(thisLevel);
    }

    void TakeOnEnterEnemy()
    {
        animator.SetBool("isTakeDamage", false);
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
