using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAndroidButtom : MonoBehaviour
{
    public float speed = 5f;
    GameObject character;
    CharacterMove characterMove;
    Rigidbody2D rb;
    float checkMove;

    public float CheckMove
    {
        set
        {
            checkMove = value;
        }
    }

    void Start()
    {
        character = GameObject.Find("Player");
        characterMove = character.GetComponent<CharacterMove>();
        rb = character.GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if(checkMove == 1)
        {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else if(checkMove == -1)
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
    }

    public void Jump(float power)
    {
        if((characterMove.extraJumps > 0 || characterMove.canJump))
        {
            characterMove.source.PlayOneShot(characterMove.jumpClip, 0.5f);
            rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
            characterMove.extraJumps--;
        }
        else if(characterMove.extraJumps == 0 && characterMove.grounded)
        {
            characterMove.source.PlayOneShot(characterMove.jumpClip, 0.5f);
            rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
        }
    }
}
