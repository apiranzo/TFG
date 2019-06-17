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
    public AudioClip soPrimer;
    public AudioClip soSegon; 

    bool soUn;
    bool soDos;
    bool flag = true;
    bool flag2;

    int tempo;

    public bool rotacio;
    bool flag3;

    //Kinect

    public float rangMax;
    public float rangMin;

    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HipCenter;
    private GameObject KinectObject;
    private SimpleGestureListener gestureListener;


    public void Start()
    {
        linia = liniaObjecte.GetComponent<Animator>();
        linia.enabled = false; 

       

        soConst = GetComponent<AudioSource>();

        soUn = true;
        soDos = true; 

        puntObject.GetComponent<Transform>();

        rotacio = true;
        flag2 = false;
        flag3 = true; 

        //Kinect
        KinectManager manager = KinectManager.Instance;
        gestureListener = GameObject.Find("KinectObject").GetComponent<SimpleGestureListener>();


    }

    public void Update()
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
                    if (posJoint.x <= rangMax && posJoint.x >= rangMin)
                    {
                        if (rotacio)
                        {
                            if (flag3)
                            {
                                puntObject.transform.Rotate(xAngle, yAngle, zAngle + 2);
                                tempo = 0;
                                if (soDos)
                                {
                                    soConst.clip = soPrimer;
                                    soConst.Play();
                                    soDos = false; 
                                }
                               
                                    
                                
                            }
                            
                             
                            
                        }

                        
                        flag2 = true;
                        flag = true;

                       
                        
                        if (gestureListener.IsRaiseLeftHand())
                        {
                            Debug.Log("Click");
                            linia.enabled = true;
                            // linia.speed = 0.5f;
                            flag3 = false; 
                            if (flag)
                            {
                                linia.SetFloat("revert", 0.5f);
                            }

                            if (soUn)
                            {
                                soConst.clip = soSegon;
                                soConst.Play();
                                soUn = false;
                            }
                        }

                        if (gestureListener.IsRaiseRightHand())
                        {
                            Debug.Log("Click");
                            linia.enabled = true;
                            // linia.speed = 0.5f;
                            flag3 = false;
                            if (flag)
                            {
                                linia.SetFloat("revert", 0.5f);
                            }

                            if (soUn)
                            {
                                soConst.clip = soSegon;
                                soConst.Play();
                                soUn = false;
                            }
                        }


                    }
                    else
                    {
                        flag2 = false;

                        if (tempo > 0)
                        {
                            linia.SetFloat("revert", -0.5f);
                            flag = false;
                        }
                        //linia.speed = 0f;
                        soUn = true;
                        flag3 = true;
                        soDos = true; 
                    }

                }

            }

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

        if (!rotacio)
        {
            linia.SetFloat("revert", 0.5f);
            flag = false;
        }
    }

   

    public void Automatic()
    {

        rotacio = false; 
    }

    

   


}
