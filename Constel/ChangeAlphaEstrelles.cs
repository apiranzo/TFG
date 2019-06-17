using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlphaEstrelles : MonoBehaviour
{
    public SpriteRenderer estrelles;
    

    float alphaI;
    float alphaF;


    public GameObject cuques;
    public GameObject constelacions;
    public SpriteRenderer[] cuquesAlpha;

    float alphaIC;
    float alphaFC; 

    bool flag;
    bool flag2; 

    public GameObject Sol;

    



    private void Start()
    {
        
        estrelles = GetComponent<SpriteRenderer>();

        alphaI = estrelles.color.a;
        alphaF = 1f;

        flag = false;
        constelacions.SetActive(false);

        
        alphaFC = 0f;

        Sol.GetComponent<CanviLlum>().enabled = false;
        flag2 = true;

        

    }

    private void Update()
    {
        if (flag2)
        {
            Sol.GetComponent<CanviLlum>().enabled = true;
            flag2 = false; 
        }

        estrelles.color = new Color(1, 1, 1, alphaI);


        if (alphaI <= alphaF)
        {
            alphaI += .001f;
            estrelles.color = new Color(1, 1, 1, alphaI);
            //Debug.Log(alphaI);

           
            
        }

        

       if (alphaI >= alphaF)
       {
            DestroyGameObject();
       }

       if (flag)
       {
            constelacions.SetActive(true);
            
       }
     
    }

    public void DestroyGameObject()
    {
        foreach (SpriteRenderer cuca in cuquesAlpha)
        {
            cuca.GetComponentInChildren<SpriteRenderer>();
            alphaIC = cuca.color.a;

            if (alphaIC >= alphaFC)
            {
                alphaIC -= .005f;
                cuca.color = new Color(1, 1, 1, alphaIC);
            }

            
        }
        if (alphaIC <= alphaFC)
        {
            Destroy(cuques);
        }


        flag = true; 
    }

}
