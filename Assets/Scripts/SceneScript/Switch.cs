using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject wall;
    Vector3 pos;
    Vector3 minPos;
    Vector3 posObj;
    Vector3 startPosObj;
    public float degryPress, objMovePos;
    bool close;

    void Start()
    {
        startPosObj = wall.transform.position;
        posObj = new Vector3(wall.transform.position.x, wall.transform.position.y + objMovePos, wall.transform.position.z);
        pos = transform.position;
        minPos = new Vector3(transform.position.x, transform.position.y - degryPress, transform.position.z);
    }

    private void Update() 
    {
        if(close && startPosObj.y < wall.transform.position.y)
        {
            wall.transform.Translate(Vector2.down * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag.Equals("Player") && minPos.y < transform.position.y)
        {
            transform.Translate(Vector2.down * Time.deltaTime);
            Debug.Log("Press switch");
        }

        if(other.tag.Equals("Player") && wall.transform.position.y < posObj.y)
        {
            wall.transform.Translate(Vector2.up * Time.deltaTime);
            close = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        transform.position = pos;
        close = true;
    }
}
