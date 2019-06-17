using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScalaCuca : MonoBehaviour
{
    
    public Vector3 cucaStart;
    public Vector3 cucaEnd;

    bool flag;
    bool flag2;

    float speed = 1.5f;
    float startTime;
    float journey;
    float discoveret;
    float fracjourney;


    void Start()
    {
        
        startTime = Time.time; //dius que el float starttime serà de tipus Time per tant medirà amb frames
        
        journey = Vector3.Distance(cucaStart, cucaEnd); //Distance = és la totalitat del recorregut des del punt a al punt b
    }

    
    void Update()
    {
         discoveret = (Time.time - startTime) * speed; // declarem que també és time i li restem el time incial
         fracjourney = discoveret / journey; //fraccionem la distància amb time / totalitat del camí 

        if (transform.localScale==cucaStart)
         {
            if(flag2) //quan sigui true entrarà a la funió 
            {
                Reinicialitzar(); //només s'executarà un cop
                flag2 = false; //passarà a false
            }

                flag = true; //s'executarà la segona



         }
        
        if (transform.localScale == cucaEnd)
        {
            
            if (!flag2)
            {
                Reinicialitzar();
                flag2 = true;
            }
            
            flag = false;
            
        }

        if (flag == true)
            transform.localScale = Vector3.Lerp(cucaStart, cucaEnd, fracjourney); //3 paràmetres incial, final, temps entre un i altre 
        else
        transform.localScale = Vector3.Lerp(cucaEnd, cucaStart, fracjourney); //3 paràmetres incial, final, temps entre un i altre
    }

    private void Reinicialitzar()
    {
        //Debug.Log(cucaStart);
        speed = 1.0f;
        
        
        discoveret=0.0f;
        fracjourney=0.0f;
        startTime = Time.time; //dius que el float starttime serà de tipus Time per tant medirà amb frames

        journey = Vector3.Distance(cucaStart, cucaEnd); //Distance = és la totalitat del recorregut des del punt a al punt b
    }
}
