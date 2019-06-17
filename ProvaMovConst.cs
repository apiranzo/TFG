using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaMovConst : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        animator.SetBool("Mov", true);
    }

    private void OnMouseExit()
    {
        animator.SetBool("Mov", false);
    }
}
