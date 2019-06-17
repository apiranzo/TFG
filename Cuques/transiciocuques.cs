using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transiciocuques : MonoBehaviour
{

    public GameObject fums;
    GameObject musicPlayer;

    private void Start()
    {
        musicPlayer = GameObject.Find("musicPlayer");
    }


    public void AudioTrans()
    {
        musicPlayer.SendMessage("CanviDestat", 2);
    }

    public void DestroyGameObject()
    {
        Destroy(fums);
    }

   
    

}
