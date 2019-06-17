using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inici : MonoBehaviour
{
    public AudioSource soInici;
    public float volumI;

    bool canvi; 

    private void Start()
    {
        soInici = GetComponent<AudioSource>();
        canvi = true;
        volumI = soInici.volume; 
    }

    private void OnMouseOver()
    {
        BaixarSo();

        if (!canvi)
        {
            SceneManager.LoadScene("Interaccio");
            canvi = true; 
        }
            
               
    }

    public void BaixarSo()
    {
        volumI = soInici.volume; 

        if (volumI >= 0)
        {
            volumI = soInici.volume - (Time.deltaTime / (1 - 0.5f));
            soInici.volume = volumI;
            Debug.Log(volumI);
        }
        if (volumI <= 0)
        {
            canvi = false; 
        }
    }


}
