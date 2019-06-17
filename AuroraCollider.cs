using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraCollider : MonoBehaviour
{
    public GameObject aurora;
    // private SpriteRenderer auroraColor; 
    // float alphaI;
    private Animator auroraAnim;
    public Collider2D auroraCollider;

    bool flag;

    bool flag3;

    int time;

    //Kinect

    public float rangMax;
    public float rangMin;

    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HipCenter;

    void Start()
    {
        aurora.SetActive(false);
        aurora.GetComponent<MovimentAurores>().enabled = false;
        flag = false;
        auroraAnim = aurora.GetComponent<Animator>();

        flag3 = false;
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
                    if (!flag)
                    {
                        aurora.SetActive(true);

                        time = 0;
                        flag3 = true;
                        flag = true;
                    }
                    

                    if (posJoint.x <= rangMax && posJoint.x >= rangMin)
                    {
                        aurora.GetComponent<MovimentAurores>().enabled = true;
                        auroraAnim.SetFloat("revert", 1f);

                    }
                    else
                    {
                        if (flag)
                        {


                            flag3 = false;

                            if (time > 0)
                            {
                                auroraAnim.SetFloat("revert", -1f);
                                flag = false;
                            }





                        }
                    }

                }

            }

        }


        if (flag3)
        {
            if (time >= 0)
            {
                time++;
            }

        }
        if (!flag)
        {
            if (time >= 0)
            {
                time--;
            }

            if (time <= 0)
            {
                auroraAnim.SetFloat("revert", 0f);

            }

        }

        // Debug.Log(time);

    }

    private void OnMouseEnter()
    {
        
    }

    

    
}
