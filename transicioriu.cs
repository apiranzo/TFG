using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicioriu : MonoBehaviour
{
    public GameObject rius1;
    public GameObject rius2;
    public GameObject rius3;
    public GameObject rius4;
    public GameObject rius5;
    public GameObject rius6;

    public SpriteRenderer[] primerRius;
    public SpriteRenderer[] segonRius;
    public SpriteRenderer[] tercerRius;
    public SpriteRenderer[] quartRius;
    public SpriteRenderer[] cinqueRius;
    public SpriteRenderer[] siseRius;


    public GameObject managerFums;
    public GameObject boira; 
    public GameObject fums1;
    public GameObject fums2;
    public GameObject fums3;
    public GameObject fums4;
    public GameObject fums5;
    public GameObject fums6;

    public GameObject llumSol; 


    bool flag;
    bool flag2; 

    int grup;

    float alphaI;

    GameObject musicPlayer; 
     

    private void Start()
    {
        rius1.SetActive(false);
        rius2.SetActive(false);
        rius3.SetActive(false);
        rius4.SetActive(false);
        rius5.SetActive(false);
        rius6.SetActive(false);

        

        grup = Random.Range(0, 6);

        GrupRius();

        managerFums.SetActive(false);
        fums1.SetActive(false);
        fums2.SetActive(false);
        fums3.SetActive(false);
        fums4.SetActive(false);
        fums5.SetActive(false);
        fums6.SetActive(false);

        boira.SetActive(false);

        flag = false;
        flag2 = true; 


        musicPlayer = GameObject.Find("musicPlayer");



    }

    private void Update()
    {
        
        if (flag && rius1.activeSelf == true)
        {
            foreach (SpriteRenderer riu in primerRius)
            {
                riu.GetComponentInChildren<ChangAlphaAutomatic>().enabled = true;
            }
        }
        if (flag && rius2.activeSelf == true)
        {
            foreach (SpriteRenderer riu in segonRius)
            {
                riu.GetComponentInChildren<ChangAlphaAutomatic>().enabled = true;
            }
        }
        if (flag && rius3.activeSelf == true)
        {
            foreach (SpriteRenderer riu in tercerRius)
            {
                riu.GetComponentInChildren<ChangAlphaAutomatic>().enabled = true;
            }
        }
        if (flag && rius4.activeSelf == true)
        {
            foreach (SpriteRenderer riu in quartRius)
            {
                riu.GetComponentInChildren<ChangAlphaAutomatic>().enabled = true;
            }
        }
        if (flag && rius5.activeSelf == true)
        {
            foreach (SpriteRenderer riu in cinqueRius)
            {
                riu.GetComponentInChildren<ChangAlphaAutomatic>().enabled = true;
            }
        }
        if (flag && rius6.activeSelf == true)
        {
            foreach (SpriteRenderer riu in siseRius)
            {
                riu.GetComponentInChildren<ChangAlphaAutomatic>().enabled = true;
            }

        }

    }

    public void Receptor(float receptorPercentatge)
    {
        if(receptorPercentatge>=0.75f)
        {
            if (flag2)
            {
                musicPlayer.SendMessage("CanviDestat", 1);
                flag2 = false; 
            }
            
            boira.SetActive(true);
            llumSol.GetComponent<Animator>().enabled = true; 
            flag = true;
           
        }
    }

    public void Receptor2(float receptor2Percentatge2)
    {
        if (receptor2Percentatge2 >= 1f)
        {

            //Debug.Log("animació");
            managerFums.SetActive(true);
 
            GrupFums();

        }
    }

    public void GrupRius()
    {
        

        if (grup == 0)
        {
            rius1.SetActive(true);
            rius2.SetActive(false);
            rius3.SetActive(false);
            rius4.SetActive(false);
            rius5.SetActive(false);
            rius6.SetActive(false);
            Debug.Log("rius1");
        }

        if (grup == 1)
        {
            rius1.SetActive(false);
            rius2.SetActive(true);
            rius3.SetActive(false);
            rius4.SetActive(false);
            rius5.SetActive(false);
            rius6.SetActive(false);
            Debug.Log("rius2");
        }

        if (grup == 2)
        {
            rius1.SetActive(false);
            rius2.SetActive(false);
            rius3.SetActive(true);
            rius4.SetActive(false);
            rius5.SetActive(false);
            rius6.SetActive(false);
            Debug.Log("rius3");
        }

        if (grup == 3)
        {
            rius1.SetActive(false);
            rius2.SetActive(false);
            rius3.SetActive(false);
            rius4.SetActive(true);
            rius5.SetActive(false);
            rius6.SetActive(false);
            Debug.Log("rius4");
        }

        if (grup == 4)
        {
            rius1.SetActive(false);
            rius2.SetActive(false);
            rius3.SetActive(false);
            rius4.SetActive(false);
            rius5.SetActive(true);
            rius6.SetActive(false);
            Debug.Log("rius5");
        }

        if (grup == 5)
        {
            rius1.SetActive(false);
            rius2.SetActive(false);
            rius3.SetActive(false);
            rius4.SetActive(false);
            rius5.SetActive(false);
            rius6.SetActive(true);
            Debug.Log("rius6");
        }

    }

    public void GrupFums()
    {


        if (grup == 0)
        {
            fums1.SetActive(true);
            fums2.SetActive(false);
            fums3.SetActive(false);
            fums4.SetActive(false);
            fums5.SetActive(false);
            fums6.SetActive(false);
            Debug.Log("fums1");
        }

        if (grup == 1)
        {
            fums1.SetActive(false);
            fums2.SetActive(true);
            fums3.SetActive(false);
            fums4.SetActive(false);
            fums5.SetActive(false);
            fums6.SetActive(false);
            Debug.Log("fums2");
        }

        if (grup == 2)
        {
            fums1.SetActive(false);
            fums2.SetActive(false);
            fums3.SetActive(true);
            fums4.SetActive(false);
            fums5.SetActive(false);
            fums6.SetActive(false);
            Debug.Log("fums3");
        }

        if (grup == 3)
        {
            fums1.SetActive(false);
            fums2.SetActive(false);
            fums3.SetActive(false);
            fums4.SetActive(true);
            fums5.SetActive(false);
            fums6.SetActive(false);
            Debug.Log("fums4");
        }

        if (grup == 4)
        {
            fums1.SetActive(false);
            fums2.SetActive(false);
            fums3.SetActive(false);
            fums4.SetActive(false);
            fums5.SetActive(true);
            fums6.SetActive(false);
            Debug.Log("fums5");
        }

        if (grup == 5)
        {
            fums1.SetActive(false);
            fums2.SetActive(false);
            fums3.SetActive(false);
            fums4.SetActive(false);
            fums5.SetActive(false);
            fums6.SetActive(true);
            Debug.Log("fums6");
        }

    }

   

   
}
