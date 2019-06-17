using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulla27 : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        
        animator.SetBool("fulla27", true);
        
    }

    private void OnMouseExit()
    {
       
        animator.SetBool("fulla27", false);
        
    }
}

