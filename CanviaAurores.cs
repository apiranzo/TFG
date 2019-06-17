using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanviaAurores : MonoBehaviour
{
    public GameObject aurores;

    GameObject musicPlayer;

    bool flag = true;

    public GameObject llum1;
    public GameObject llum2;
    

    public GameObject constelacions; 




    void Start()
    {
        aurores.SetActive(false);

        musicPlayer = GameObject.Find("musicPlayer");
        llum1.SetActive (true);
        llum2.SetActive (true);
        constelacions.SetActive(true);
        

    }

    public void ActivacioSo()
    {
        if (flag)
        {
            musicPlayer.SendMessage("CanviDestat", 5);
            flag = false;
        }
    }

    public void ApagarLlums()
    {
        llum1.SetActive(false);
        llum2.SetActive(false);
        constelacions.SetActive(false);
    }
    
    public void ActivacioAurores()
    {
            
            aurores.SetActive(true);
            
        
    }
}
