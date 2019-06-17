using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contadorConstel : MonoBehaviour
{
    [SerializeField]
    public float percentatge;

    public static int actius;
    public int totalactius;
    private GameObject constelacions;

    bool nomesuna;

    public GameObject punts;
    public AudioSource puntsSo;

    private SpriteRenderer glow;
    public GameObject glowLine;

    float alphaI;

    bool flag; 

    private void Start()
    {
        constelacions = GameObject.Find("Constelacions");
        percentatge = 0;
        actius = 0;
        totalactius = 5; //Pujar a ?? quantes son

        nomesuna = true;

        puntsSo = punts.GetComponent<AudioSource>();

        glow = glowLine.GetComponent<SpriteRenderer>();
        alphaI = glow.color.a;
        flag = false; 
    }

    public void Update()
    {
        if (flag)
        {
            if (alphaI <= 1)
            {
                alphaI += .005f;
                glow.color = new Color(1, 1, 1, alphaI);
            }
        }
        
    }

    public void StopRotacio()
    {
        punts.GetComponent<animacioConstelacions>().rotacio = false; 
    }

    public void Completa()
    {

        if (nomesuna)
        {
            actius++;
            Percentatge(percentatge);
            nomesuna = false;
           
        }

        



    }

    public void FiSo()
    {
        puntsSo.volume = 0f;
    }

    public void PujarGlow()
    {
        flag = true; 
    }

    public void Percentatge(float percentatge)
    {
        percentatge = actius / totalactius;
        Debug.Log("actius: " + actius);
        constelacions.SendMessage("Receptor", percentatge);


    }
}
