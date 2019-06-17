using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicioLlumRius : MonoBehaviour
{
    public Light lr;
    public GameObject llum;

    Vector3 mousePosition;

    public float posicioZ; 

    void Start()
    {
        llum.GetComponent<Transform>();
        
    }


    void Update()
    {
        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        llum.transform.position = new Vector3(mousePosition.x, mousePosition.y, posicioZ);

        Debug.Log(mousePosition);
    }
}
