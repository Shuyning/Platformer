using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Color color = sprite.material.color;
        color.a = 0f;
        sprite.material.color = color;
    }

    IEnumerator InvisibleSprite()
    {
        for(float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color color = sprite.material.color;
            color.a = f;
            sprite.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartInvisible()
    {
        StartCoroutine("InvisibleSprite");
    }
}
