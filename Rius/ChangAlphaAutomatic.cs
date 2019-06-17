using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangAlphaAutomatic : MonoBehaviour
{

    public SpriteRenderer riu;
    //public SpriteRenderer fum;
    private GameObject rius;

    float alphaI;
    float alphaF;

    bool flag; 

    [SerializeField]
    public float percentatge;

    public static int actius;
    public int totalactius;


    private void Start()
    {
        rius = GameObject.Find("rius"); //busca rius

        riu.enabled = true; 

        riu = GetComponent<SpriteRenderer>();
        


        alphaI = riu.color.a;
        alphaF = 1f;

        percentatge = 0;
        actius = 0;
        totalactius = 13; //Pujar a 12

        flag = true; 
    }

    private void Update()
    {
        
        riu.color = new Color(1, 1, 1, alphaI);
        //Debug.Log(alphaI);
        GetComponent<AudioSource>().enabled = false;

        if (alphaI <= alphaF)
        {
            alphaI += .003f ;
            riu.color = new Color(1, 1, 1, alphaI);
            //Debug.Log(alphaI);
        }

        if (alphaI >= alphaF && flag)
        {
            actius++;
            
            Percentatge2(percentatge);
            flag = false; 
        }
            


    }

    public void Percentatge2(float percentatge)
    {
        percentatge = actius / totalactius;
        Debug.Log("actius: " + actius);
        rius.SendMessage("Receptor2", percentatge);


    }

}
