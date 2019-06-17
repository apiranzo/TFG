using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullesInt : MonoBehaviour
{
    public Animator fulla4;
    public Animator fulla16;
    public Animator fulla21;
    public Animator fulla27;
    public Animator fulla33;
    public Animator fulla34;
    public Animator fulla37;
    

    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HipCenter;
    private GameObject KinectObject;
    private SimpleGestureListener gestureListener;

    public float rangMax;
    public float rangMin;

    void Start()
    {
        fulla4 = GameObject.Find("fulla04").GetComponent<Animator>();
        fulla16 = GameObject.Find("fulla16").GetComponent<Animator>();
        fulla21 = GameObject.Find("fulla21").GetComponent<Animator>();
        fulla27 = GameObject.Find("fulla27").GetComponent<Animator>();
        fulla33 = GameObject.Find("fulla33").GetComponent<Animator>();
        fulla34 = GameObject.Find("fulla34").GetComponent<Animator>();
        fulla37 = GameObject.Find("fulla37").GetComponent<Animator>();

        KinectManager manager = KinectManager.Instance;
        gestureListener = GameObject.Find("KinectObject").GetComponent<SimpleGestureListener>();
    }

    private void Update()
    {
        KinectManager manager = KinectManager.Instance;
        if ((!manager || !manager.IsInitialized() || !manager.IsUserDetected()))
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

                        if (gestureListener.IsSwipeLeft())
                        {
                            ActivarMov();

                        }
                        else if (gestureListener.IsSwipeRight())
                        {
                            ActivarMov();

                        }


                    }

                    else
                    {
                        DesactivarMov();

                    }


                }

            }
        }


    }

    public void ActivarMov()
    {
        fulla4.SetBool("fulla4", true);
        fulla16.SetBool("fulla16", true);
        fulla21.SetBool("fulla21", true);
        fulla27.SetBool("fulla27", true);
        fulla33.SetBool("fulla33", true);
        fulla34.SetBool("fulla34", true);
        fulla37.SetBool("fulla37", true);

        Debug.Log("true");
        
    }

    public void DesactivarMov()
    {
        fulla4.SetBool("fulla4", false);
        fulla16.SetBool("fulla16", false);
        fulla21.SetBool("fulla21", false);
        fulla27.SetBool("fulla27", false);
        fulla33.SetBool("fulla33", false);
        fulla34.SetBool("fulla34", false);
        fulla37.SetBool("fulla37", false);
    }
}
