using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicioestrelles : MonoBehaviour
{
    

    public SpriteRenderer cel;

    public GameObject sol;
    public GameObject sol2; 

    GameObject musicPlayer;

    bool flag = true; 
     


    void Start()
    {

        musicPlayer = GameObject.Find("musicPlayer");
        cel.enabled = true;

        sol.SetActive(true);
        sol2.SetActive(false);

    }


    public void Receptor(float receptorPercentatge)
    {

        if (receptorPercentatge >= 0.7f)
        {
            if (flag)
            {
                musicPlayer.SendMessage("CanviDestat", 3);
                flag = false; 
            }
            
            

            Debug.Log("pujocel");
            cel.GetComponent<ChangeAlphaEstrelles>().enabled = true;

            sol2.SetActive(true);
            sol.SetActive(false);
           


        }
    }
    

   
}
