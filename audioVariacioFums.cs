using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioVariacioFums : MonoBehaviour
{
    public AudioSource transiciorius;
    //public AudioSource baserius;

    public GameObject rius; 

    float volumI = 0.0f;
    float volumF = 1f;
    public float speed = 0.5f;

    public void Start()
    {
        transiciorius = GetComponent<AudioSource>();
        transiciorius.enabled = false;
        transiciorius.volume = volumI;
        transiciorius.GetComponent<AudioSource>().Play(0);

        rius.GetComponent<AudioSource>();
    }

    void Update()
    {
        transiciorius.enabled = true;
        
        if (transiciorius.volume <= volumF)
        {
            volumI = transiciorius.volume + (Time.deltaTime / (speed + 0.5f));
            transiciorius.volume = volumI;
        }

        if (transiciorius.volume >= volumF)
        {
            transiciorius.volume = volumF;
            Destroy(rius.GetComponent<AudioSource>());
        }
    }
}
