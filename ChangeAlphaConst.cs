using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlphaConst : MonoBehaviour
{
    public SpriteRenderer punt;
      

    float alphaI;
    float alphaF;

    void Start()
    {
        punt = GetComponent<SpriteRenderer>();
        GetComponent<animacioConstelacions>().enabled = false; 

        alphaI = punt.color.a;
        alphaF = 1f;
    }

    
    void Update()
    {
        punt.color = new Color(1, 1, 1, alphaI);
        //Debug.Log(alphaI);


        if (alphaI <= alphaF)
        {
            alphaI += .005f;
            punt.color = new Color(1, 1, 1, alphaI);
            //Debug.Log(alphaI);
        }

        if (alphaI >= alphaF)
        {
            GetComponent<animacioConstelacions>().enabled = true;
        }

        

    }
}
