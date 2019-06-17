using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulla34 : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
      
        animator.SetBool("fulla34", true);
        
    }

    private void OnMouseExit()
    {
       
        animator.SetBool("fulla34", false);
       
    }
}

