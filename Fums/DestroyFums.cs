using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFums : MonoBehaviour
{
    public GameObject riu;
    public GameObject cuca;
    public GameObject fum; 

    public void Start()
    {
        cuca.SetActive(false); 
    }

    public void ActivCuques()
    {
        cuca.SetActive(true);
    }

    public void DestroyGameObject()
    {
        Destroy(riu);
    }

    public void DestroyGameObject2()
    {
        Destroy(fum); 
    }
}
