using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inici : MonoBehaviour
{

    //Kinect

    public float rangMax;
    public float rangMin;

    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HipCenter;

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
                    if (posJoint.x <= rangMax && posJoint.x >= rangMin)
                    {
                        SceneManager.LoadScene("Interaccio");

                    }
                   

                }

            }

        }

    }


}
