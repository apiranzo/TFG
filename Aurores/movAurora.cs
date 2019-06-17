using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movAurora : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 finishPosition;

    float positionY; 

    private void Start()
    {
        startPosition = transform.position;
        
    }

    private void OnMouseOver()
    {
        positionY = Random.Range(-5, 5);
        finishPosition = new Vector3(startPosition.x, positionY, startPosition.z);
        transform.position = Vector3.Lerp(startPosition, finishPosition, 10f); 
    }
}
