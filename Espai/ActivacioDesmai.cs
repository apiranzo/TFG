using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacioDesmai : MonoBehaviour
{
    public GameObject copa; 

    void Start()
    {
        copa.GetComponent<ControladorDesmai>().enabled = false; 
    }

    public void ActivacioGlowDesmai()
    {
        copa.GetComponent<ControladorDesmai>().enabled = true; 
    }
}
