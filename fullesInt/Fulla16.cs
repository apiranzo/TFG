using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulla16 : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
       
        animator.SetBool("fulla16", true);
      
    }

    private void OnMouseExit()
    {
        
        animator.SetBool("fulla16", false);
      
    }
}

