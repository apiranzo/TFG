using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraCollider : MonoBehaviour
{
    public GameObject aurora;
   // private SpriteRenderer auroraColor; 
   // float alphaI;
    private Animator auroraAnim;
    public Collider2D auroraCollider; 

    bool flag;
    
    bool flag3;

    int time; 

    void Start()
    {
        aurora.SetActive(false);
        aurora.GetComponent<MovimentAurores>().enabled = false;
        flag = true;
        auroraAnim = aurora.GetComponent<Animator>();
        
        flag3 = false; 
    }

    private void Update()
    {
       /* if (flag)
        {
            BaixarAlpha();
        } */

        if (flag3)
        {
            if (time >= 0)
            {
                time++;
            }
            
        }
        if (!flag)
        {
            if (time>= 0)
            {
                time--;
            }

            if (time <= 0)
            {
                auroraAnim.SetFloat("revert", 0f);

            }
       
        }

       // Debug.Log(time);
        
    }

    private void OnMouseEnter()
    {   
            // flag = false; 
            aurora.SetActive(true);
        

        
        time = 0;
        flag3 = true;
        flag = true;
    }

    private void OnMouseOver()
    {
        
            aurora.GetComponent<MovimentAurores>().enabled = true;
            auroraAnim.SetFloat("revert", 1f);

        

        

    }

    private void OnMouseExit()
    {
        //auroraAnim.speed = 0f; //decidir
        
            if (flag)
            {
                
                
                flag3 = false; 
                
                if (time > 0)
                {
                    auroraAnim.SetFloat("revert", -1f);
                    flag = false; 
                }
                
                     
                
               
                
            }
            // flag = true; 
            
        

    }

  /*  public void Automatic (bool flag2)
    {
        if (!flag2)
        {
            auroraAnim.SetFloat("revert", 1f);
            auroraCollider.enabled = false; 
        }
    } */

  
    

   /* private void BaixarAlpha()
    {
        auroraColor = aurora.GetComponent<SpriteRenderer>();

        alphaI = auroraColor.color.a; 
       
        if (alphaI >= 0f)
        {
            alphaI -= .05f;
            auroraColor.color = new Color(1, 1, 1, alphaI);
        }

        if (alphaI <= 0f)
        {
            aurora.SetActive(false);
            aurora.GetComponent<MovimentAurores>().enabled = false;
        }

    } */
}
