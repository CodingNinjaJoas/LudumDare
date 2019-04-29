using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    public Transform cameraT;
    private Transform [] layers;
    private float viewZone = 10f;
    public float backgroundSize;
    private int leftIndex;
    private int rightIndex;

    public void Start()
    {
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
            leftIndex = 0;
            rightIndex = layers.Length - 1;
        }
    }

    public void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    public void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }

    public void Update()
    {
        if (cameraT.transform.position.x < (layers[leftIndex].transform.position.x + viewZone))
        {
            ScrollLeft();
        }

        if (cameraT.transform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            ScrollRight();
        }
    }
}
