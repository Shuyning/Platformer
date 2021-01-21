using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            door.Open();
        }
    }

    public void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag.Equals("Player"))
        {
            door.Close();
        }
    }
}
