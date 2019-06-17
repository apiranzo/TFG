using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadMainLevel : MonoBehaviour 
{
	private bool levelLoaded = false;
    public float rangMax;
    public float rangMin;

    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HipCenter;
   

    void Update() 
	{
		KinectManager manager = KinectManager.Instance;
		
		/*if(!levelLoaded && manager && KinectManager.IsKinectInitialized())
		{
            DontDestroyOnLoad(gameObject); 
			levelLoaded = true;
            SceneManager.LoadScene("Interaccio");
        } */

       
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
                    if (posJoint.x <= rangMax && posJoint.x >= rangMin && !levelLoaded)
                    {
                        SceneManager.LoadScene("Interaccio");
                        levelLoaded = true;

                    }


                }

            }

        } 
    }
	
}
