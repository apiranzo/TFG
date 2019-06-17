using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulla04 : MonoBehaviour
{
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        animator.SetBool("fulla4", true);
       
    }

    private void OnMouseExit()
    {
        animator.SetBool("fulla4", false);
        
    }
}
