using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulla33 : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        
        animator.SetBool("fulla33", true);
        
    }

    private void OnMouseExit()
    {
        
        animator.SetBool("fulla33", false);
        
    }
}

