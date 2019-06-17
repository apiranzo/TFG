using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicioconstelacions : MonoBehaviour
{
    
    public GameObject[] punts;
    
    public GameObject TransConst;
    public GameObject Destello; 

    GameObject musicPlayer;

    bool flag;

   

    private void Start()
    {
        
        TransConst.SetActive(false);
        Destello.SetActive(false);

        musicPlayer = GameObject.Find("musicPlayer");

        flag = true;

    }

    private void Update()
    {
        foreach (GameObject punt in punts)
        {
            punt.GetComponent<ChangeAlphaConst>().enabled = true;
           
        }

        if (flag)
        {
            musicPlayer.SendMessage("CanviDestat", 4);
            flag = false; 
        }
    }


    public void Receptor(float receptorPercentatge)
    {
        if (receptorPercentatge >= 1f)
        {
            // ha de passar per moment de transicio!!!!
            
            TransConst.SetActive(true);
            Destello.SetActive(true);

        }
    }
}
