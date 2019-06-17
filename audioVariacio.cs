using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioVariacio : MonoBehaviour
{
    public AudioSource variacio;
    private SpriteRenderer riuColor;

    float volumeI;
    float volumeF;
    // public float speedSound; 
    float alphaF;

    bool activ;
    bool desactiv;
    bool interaccio;

    //Kinect

    public float rangMax;
    public float rangMin;

    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HandRight;


    private void Start()
    {
        variacio.enabled = false;
        variacio = GetComponent<AudioSource>();
        
        activ = false;
        desactiv = false;

        volumeI = 0f;
        volumeF = 0.5f;

        alphaF = 1;
        interaccio = true;

        //speed = 2f; 
    }

    private void Update()
    {
        KinectManager manager = KinectManager.Instance;
        if (!manager || !manager.IsInitialized() || !manager.IsUserDetected())
            return;

        int iJointIndex = (int)TrackedJoint;


        if (manager.IsUserDetected())
        {
            uint userId = manager.GetPlayer1ID();

            if (manager.IsJointTracked(userId, iJointIndex))
            {
                Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, iJointIndex);
                if (posJoint != Vector3.zero)
                {
                    Debug.Log("X" + posJoint.x);
                    Debug.Log("Z" + posJoint.z);

                    if (posJoint.x <= rangMax && posJoint.x >= rangMin)
                    {
                        if (interaccio)
                        {
                            variacio.enabled = true;
                            activ = true;
                            desactiv = false;
                            AudioInOn();

                        }

                    }
                    else
                    {
                        if (interaccio)
                        {
                            activ = false;
                            desactiv = true;
                            AudioInOn();
                        }
                        
                    }

                }

            }

        }
    }

    private void AudioInOn()
    {
        if (activ && variacio.volume == 0.5f)
        {

            variacio.volume = volumeI;
            //Debug.Log("hola");
        }

        if (activ && variacio.volume <= 0.5f)
        {

            volumeI = variacio.volume + (Time.deltaTime / (3 + 0.2f));
            variacio.volume = volumeI;
            //Debug.Log("ara pujo" + volumeI);
        }



        if (desactiv && variacio.volume >= -0.3f)
        {
            volumeI = variacio.volume - (Time.deltaTime / (2 - 0.5f));
            variacio.volume = volumeI;
        }

        if (desactiv && variacio.volume <= -0.3f)
        {
            volumeI = variacio.volume + (Time.deltaTime / (3 + 0.5f));
            variacio.volume = volumeI;
            //Debug.Log("ara no entenc que faig" + volumeI);

            desactiv = false;
        }

        if (riuColor.color.a >= alphaF)
        {
            interaccio = false;
        }
        if (!interaccio)
        { if (variacio.volume >= 0f)
            {
                volumeI = variacio.volume - (Time.deltaTime / (2 - 0.5f));
                variacio.volume = volumeI;
            }
            
        }

    }


}
