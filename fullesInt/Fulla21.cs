using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulla21 : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
       
        animator.SetBool("fulla21", true);
        
    }

    private void OnMouseExit()
    {
       
        animator.SetBool("fulla21", false);
   
    }
}

