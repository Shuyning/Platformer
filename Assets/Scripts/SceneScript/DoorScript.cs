using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject exitPlane;
    BoxCollider2D bx;
    CharacterMove character;

    bool opening, enter;

    void Start()
    {
        bx = GetComponent<BoxCollider2D>();
        character = FindObjectOfType<CharacterMove>();

        bx.enabled = false;
        opening = false;
    }

    void Update()
    {
        if(ChestScript.open)
        {
            if(!opening)
            {
                bx.enabled = true;
            }
            if(enter && !opening)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.Instance.LevelNumber++;
                    Debug.Log("Press F");
                    bx.enabled = false;
                    opening = true;
                }
            }
        }

        if(opening)
        {
            exitPlane.SetActive(true);
            character.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Door Enter");
            enter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
}
