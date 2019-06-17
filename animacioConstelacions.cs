using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animacioConstelacions : MonoBehaviour
{
    public Animator linia;
    public GameObject liniaObjecte;
    

    public GameObject puntObject;
    public float xAngle, yAngle, zAngle;
     

    public AudioSource soConst;

    bool soUn;
    bool soDos;

    public bool rotacio;

    bool flag;
    bool flag2; 

    int tempo; 


    public void Start()
    {
        linia = liniaObjecte.GetComponent<Animator>();
        linia.enabled = false; 

      

        soConst = GetComponent<AudioSource>();

        soUn = true;

        puntObject.GetComponent<Transform>();

        rotacio = true;
        flag = true;

        flag2 = false; 
    }

    public void Update()
    {
        if (!rotacio)
        {
            linia.SetFloat("revert", 0.5f);
            flag = false;
        }

        if (flag2)
        {
            if (tempo >= 0)
            {
                tempo++;
            }
        }
        if (!flag)
        {
            if (tempo >= 0)
            {
                tempo--;
            }

            if (tempo <= 0)
            {
                linia.SetFloat("revert", 0f);

            }
        }
       

    }

    public void OnMouseEnter()
    {
        if (rotacio)
        {
            puntObject.transform.Rotate(xAngle, yAngle, zAngle + 5);
        }

        
        tempo = 0;
        flag2 = true;
        flag = true; 

    }

    private void OnMouseOver()
    {
       
            linia.enabled = true;
        // linia.speed = 0.5f;
        if (flag)
        {
         linia.SetFloat("revert", 0.5f);
        }
            
            

            if (soUn)
            {
                soConst.Play();
                soUn = false;
            }
       
            
         
    }

    private void OnMouseExit()
    {
        if (flag)
        {
            flag2 = false; 

            if (tempo > 0)
            {
                linia.SetFloat("revert", -0.5f);
                flag = false; 
            }
            

        }
        
        
        //linia.speed = 0f;
        
        soUn = true;
    }

   

    public void Automatic()
    {

        rotacio = false; 
    }

    

   


}
