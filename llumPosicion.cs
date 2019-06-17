using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class llumPosicion : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.001f;

    Light lt;

    float grad = 25.0f; //gradació de la intensitat
    float range = 0.59f;

    

    
    void Start()
    {
        lt = GetComponent<Light>(); //entrem dins del component light
        lt.intensity = grad; //delimitar intensitat a 0

        lt.range = range; 

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        //transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -4.7f), mousePosition, moveSpeed);
        //Debug.Log(transform.position);

        if (Input.GetAxis("Mouse X") > 0 | Input.GetAxis("Mouse X") < 0 )
        {
           // augmentGrad();

           // augmentRange();
          
        }

    }

   /* private void augmentGrad()
    {
        lt = GetComponent<Light>();
        grad = lt.intensity; 

        if (lt.intensity == grad)
        {
            lt.intensity = grad + 1f * Time.deltaTime * moveSpeed;
            
           // Debug.Log(grad + "grad");

        }

        if (grad >= 40.0f)
        {
            lt.intensity = 40.0f;
            
            
        }
    }

    private void augmentRange()
    {
        lt = GetComponent<Light>();
        range = lt.range;  

        if (range < 6f)
        {
            lt.range = range + 1f * Time.deltaTime * moveSpeed;
            //Debug.Log(range + "range");
        }

        if (range >= 6f)
        {
            lt.range = 6f;
        }

    } */

    

}
