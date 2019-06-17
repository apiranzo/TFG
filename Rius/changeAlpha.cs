using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAlpha : MonoBehaviour
{
    private SpriteRenderer riu;
    private GameObject rius; 

    float alphaI;
    float alphaF;
    [SerializeField]
    public float percentatge;

    public static int actius;
    public int totalactius; 

    bool activ;
    bool desactiv;

    bool comprovacio;

    bool flag;
   

    private void Start()
    {
        rius = GameObject.Find("rius"); //busca rius
        riu = GetComponent<SpriteRenderer>();

        alphaI = 0f;
        alphaF = 1f;

        activ = false;
        desactiv = false;
        comprovacio = true;
        flag = true; 

        riu.enabled = false;
        percentatge = 0;
        actius = 0;
        totalactius = 10; //Pujar a 6!!!!!

     

    }
    
    private void Update()
    {
        if (activ == true)
        {
            riu.color = new Color(1, 1, 1, alphaI);
        }

        if (activ == true && alphaI <= alphaF)
        {
            alphaI += .003f;
            riu.color = new Color(1, 1, 1, alphaI);
            
        }

        if (activ == true && alphaI >= 0.8f && flag)
        {

            actius++;
            Percentatge(percentatge);
            flag = false;
            //Debug.Log(actius);
        }

        

        if (desactiv == true)
        {
            riu.color = new Color(1, 1, 1, alphaI);
        }

    }

    private void OnMouseOver()
    {
        if (comprovacio) {
            riu.enabled = true;
            activ = true;
            desactiv = false;
         
                
        }
        
    }

    private void OnMouseExit()
    {
        activ = false;
        desactiv = true;
       
         
    }
    public void Percentatge(float percentatge)
    {
        percentatge = actius / totalactius;
        
        rius.SendMessage("Receptor", percentatge);
        
      
    }

}
