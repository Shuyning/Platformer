using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    public float smoothing;
    public float minPos, maxPos, minPosP, maxPosP;
    public float yLimit, startPos;
    float x, y, z;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        x = player.position.x;
        z = player.position.z;
        y = player.position.y;

        SetCamyOverX(x, y, z);
    }

    void SetCamyOverX(float x, float y , float z)
    {
        if(yLimit <= y && x >= minPosP && x <= minPos)
        {
            transform.position = new Vector3(minPos, yLimit, z);
        }
        else if(yLimit <= y && x <= maxPosP && x >= maxPos)
        {
            transform.position = new Vector3(maxPos, yLimit, z);
        }
        else if(yLimit >= y && x >= minPosP && x <= minPos)
        {
            transform.position = new Vector3(minPos, startPos, z);
        }
        else if(yLimit >= y && x <= maxPosP && x >= maxPos)
        {
            transform.position = new Vector3(maxPos, startPos, z);
        }
        else if(yLimit <= y && x >= minPos && x <= maxPos)
        {
            transform.position = new Vector3(x, yLimit, z);
        }
        else if(yLimit >= y &&x >= minPos && x <= maxPos)
        {
            transform.position = new Vector3(x, startPos, z);
        }
    }

    void Update()
    {
        x = player.position.x;
        z = player.position.z;
        y = player.position.y;

        SetCamyOverX(x, y, z);

        if(x >= minPos && x <= maxPos)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x , transform.position.y), smoothing * Time.deltaTime);
        }
    }
}
