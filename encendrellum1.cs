using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encendrellum1 : MonoBehaviour
{
    float grad = 0f;
    public float gradF;
    float moveSpeed = 0.1f;

    private Light lt;

    
    

    private void Start()
    {
        lt = GetComponent<Light>();
        lt.intensity = grad;
         
    }

    private void OnMouseOver() {

        lt = GetComponent<Light>();
        
        grad = lt.intensity;


        if (lt.intensity == grad)
        {
            lt.intensity = grad + 1.5f * Time.deltaTime * moveSpeed;

        }
        if (grad >= gradF/2f)
        {
            lt.intensity = gradF/2f;
            
        }

        Debug.Log("estoy dentro");
     
    }

    

}
    

  
    
