using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorAurores : MonoBehaviour
{
    GameObject musicPlayer;

    bool flag;
   

    public GameObject sol3;
    public GameObject terceresLlums;

    public GameObject aurora1;
    public GameObject aurora2;
    public GameObject aurora3;
    public GameObject aurora4;
    public GameObject aurora5;
    public GameObject aurora6;
    public GameObject aurora7;

    void Start()
    {
        musicPlayer = GameObject.Find("musicPlayer"); //PASSAR A AURORES

        flag = true;

        sol3.SetActive(false); //PASSAR A AURORES
        terceresLlums.SetActive(false); //PASSAR A AURORES

        aurora1.SetActive(false);
        aurora2.SetActive(false);
        aurora3.SetActive(false);
        aurora4.SetActive(false);
        aurora5.SetActive(false);
        aurora6.SetActive(false);
        aurora7.SetActive(false);

      
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            musicPlayer.SendMessage("CanviDestat", 6); //PASSAR A AURORES
            flag = false;
        }

        sol3.SetActive(true); //PASSAR A AURORES
        terceresLlums.SetActive(true); //PASSAR A AURORES

        aurora1.SetActive(true);
        aurora2.SetActive(true);
        aurora3.SetActive(true);
        aurora4.SetActive(true);
        aurora5.SetActive(true);
        aurora6.SetActive(true);
        aurora7.SetActive(true);
    }

    public void Receptor(float receptorPercentatge)
    {
        if (receptorPercentatge >= 1f)
        {
            sol3.SetActive(false);
            terceresLlums.SetActive(false);

            for (int i = 0; i<= 10; i++)
            {
                musicPlayer.SendMessage("CanviDestat", 7);

                if (i == 10)
                {
                    SceneManager.LoadScene("Final");
                }
            }

            

            
        }
    }
}
