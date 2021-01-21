using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCube : MonoBehaviour
{
    public float factorJump;

    CharacterMove character;
    Animator animator;
    public PhysicsMaterial2D physicsMaterial2D;
    public AudioSource source;
    public AudioClip enterClip;

    void Start()
    {
        character = GetComponent<CharacterMove>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            physicsMaterial2D.bounciness = factorJump;
            animator.SetTrigger("enterPlayer");
            source.PlayOneShot(enterClip, 0.5f);
            Debug.Log(physicsMaterial2D.bounciness);
        }
        else if(other.gameObject.layer.Equals("Enemy"))
        {
            physicsMaterial2D.bounciness = factorJump;
            animator.SetTrigger("enterPlayer");
            Debug.Log(factorJump);
        }
    }
}
