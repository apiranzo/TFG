using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulla37 : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
       
        animator.SetBool("fulla37", true);
    }

    private void OnMouseExit()
    {
        
        animator.SetBool("fulla37", false);
    }
}

