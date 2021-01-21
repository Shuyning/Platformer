using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    [SerializeField] float dumping = 1.5f;
    [SerializeField] Vector2 offSet = new Vector2(2f, 1f);
    [SerializeField] bool isLeft;

    Transform player;

    int lastX;

    private void Start() {
        offSet = new Vector2(Mathf.Abs(offSet.x), offSet.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);

        if(playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offSet.x, player.position.y - offSet.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offSet.x, player.position.y + offSet.y, transform.position.z);
        }
    }

    private void Update() {
        if(player){
            int currentX = Mathf.RoundToInt(player.position.x);
            
            if(currentX > lastX)
            {
                isLeft = false;
            }
            else if(currentX < lastX)
            {
                isLeft = true;
            }

            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;

            if(isLeft)
            {
                target = new Vector3(player.position.x - offSet.x, player.position.y + offSet.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offSet.x, player.position.y + offSet.y, transform.position.z);
            }

            Vector3 currentPosition =  Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);

            transform.position = currentPosition;
        }
    }
}
