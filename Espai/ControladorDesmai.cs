using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDesmai : MonoBehaviour
{
    private Animator animator;

    int collisions; 


    void Start()
    {
        animator = GetComponent<Animator>();


        collisions = 0; 
    }

    

    public void OnTriggerEnter(Collider collision)
    {
        collisions++;
        Debug.Log(collisions);

        if (collisions >= 1)
        {
            animator.SetBool("Patata", true);
            
        }
      
    }

    public void OnTriggerExit(Collider other)
    {
        collisions--; 

        if (collisions<= 0)
        {
            animator.SetBool("Patata", false);
        }
       
    }
}
