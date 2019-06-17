using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioVariacio : MonoBehaviour
{
    public AudioSource variacio;
    private SpriteRenderer riuColor; 


    private float alphaF; 

    public float volumeI;
    public float volumeF;
   // public float speedSound; 

    bool activ;
    bool desactiv;

    bool interaccio; 

    private void Start()
    {
        riuColor = GetComponent<SpriteRenderer>();

        alphaF = 1;
        interaccio = true; 

        variacio.enabled = false;
        variacio = GetComponent<AudioSource>();
        
        activ = false;
        desactiv = false;

        volumeI = 0.5f;
        volumeF = 0f;

        //speed = 2f; 
    }

    private void Update()
    {
        if (activ  && variacio.volume == 0.5f)
        {
            
            variacio.volume = volumeI;
            Debug.Log("hola");
        }

        if (activ && variacio.volume <= 0.5f)
        {
            
            volumeI = variacio.volume + (Time.deltaTime / (3 + 0.2f)) ;
            variacio.volume = volumeI;
            Debug.Log("ara pujo" + volumeI);
        }

   

        if (desactiv  && variacio.volume >= -0.3f)
        {
            volumeI = variacio.volume - (Time.deltaTime / (2 - 0.5f));
            variacio.volume = volumeI; 
        }

        if (desactiv  && variacio.volume <= -0.3f)
        {
            volumeI = variacio.volume + (Time.deltaTime / (3 + 0.5f));
            variacio.volume = volumeI;
            Debug.Log("ara no entenc que faig" + volumeI);

            desactiv = false;
        }

       

        if (riuColor.color.a >= alphaF)
        {
            interaccio = false; 
        }
        if (!interaccio)
        { if (variacio.volume >= 0f)
            {
                volumeI = variacio.volume - (Time.deltaTime / (2 - 0.5f));
                variacio.volume = volumeI;
            }
            
        }
    }

    private void OnMouseOver()
    {
        if (interaccio)
        {
            variacio.enabled = true;
            activ = true;
            desactiv = false;
        }
        

        //volumeI = 1;
    }

    private void OnMouseExit()
    {
        if (interaccio)
        {
            activ = false;
            desactiv = true;
        }

        
        
    }

}
