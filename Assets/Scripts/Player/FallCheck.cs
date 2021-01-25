using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            Debug.Log(CharacterMove.rb.velocity.y);
        }

        if (collision.gameObject.tag.Equals("Floor") && CharacterMove.rb.velocity.y < -15)
        {
            Debug.Log("Damage");
        }
    }
}
