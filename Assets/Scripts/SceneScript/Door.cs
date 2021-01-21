using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    BoxCollider2D bx;

    void Start()
    {
        anim = GetComponent<Animator>();
        bx = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    public void Open()
    {
        anim.SetBool("Open", true);
        bx.enabled = false;
    }

    public void Close()
    {
        anim.SetBool("Open", false);
        bx.enabled = true;
    }
}
