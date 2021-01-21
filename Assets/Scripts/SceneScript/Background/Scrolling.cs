using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] bool scrolling, paralax = true;

    [SerializeField] float backgroundSize;
    [SerializeField] float paralaxSpeed;
    Transform cameraTransform;
    Transform[] layers;
    float viewZone = 10f;
    int leftIndex;
    int rightIndex;

    float lastCameraX; 

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;

        layers = new Transform[transform.childCount];

        for(int i = 0;  i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    void scrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x  - backgroundSize);   
        leftIndex = rightIndex;
        rightIndex--;

        if(rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    void scrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x  + backgroundSize);   
        rightIndex = leftIndex;
        leftIndex++;

        if(leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(paralax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * paralaxSpeed);
        }

        lastCameraX = cameraTransform.position.x;

        if(scrolling)
        {
            if(cameraTransform.position.x < (layers[leftIndex].position.x + viewZone))
            {
                scrollLeft();
            }

            if(cameraTransform.position.x > (layers[rightIndex].position.x - viewZone))
            {
                scrollRight();
            }
        }       
    }
}
