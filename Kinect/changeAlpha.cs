using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAlpha : MonoBehaviour
{
    private SpriteRenderer riu;
    private GameObject rius; 

    float alphaI;
    float alphaF;
    [SerializeField]
    public float percentatge;

    public static int actius;
    public int totalactius; 

    bool activ;
    bool desactiv;

    //bool comprovacio;

    bool flag;

    //Kinect

    public float rangMax;
    public float rangMin;

    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HipCenter;



    private void Start()
    {
        rius = GameObject.Find("rius"); //busca rius
        riu = GetComponent<SpriteRenderer>();

        alphaI = 0f;
        alphaF = 1f;

        activ = false;
        desactiv = false;
        //comprovacio = true;
        flag = true; 

        riu.enabled = false;
        percentatge = 0;
        actius = 0;
        totalactius = 10; //Pujar a 6!!!!!

     

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
                    if (posJoint.x <= rangMax && posJoint.x >= rangMin)
                    {
                        
                        riu.enabled = true;
                        activ = true;
                        desactiv = false;
                        PujarAlpha();
                    }
                    else
                    {
                        riu.enabled = true;
                        desactiv = true;
                        activ = false;
                        PujarAlpha();
                    }

                }

            }

        }

    }

    private void PujarAlpha()
    {
        if (activ)
        {
            riu.color = new Color(1, 1, 1, alphaI);
        }

        if (activ && alphaI <= alphaF)
        {
            alphaI += .005f;
            riu.color = new Color(1, 1, 1, alphaI);
            //Debug.Log(alphaI);
        }

        if (activ && alphaI >= 0.8f && flag)
        {

            actius++;
            Percentatge(percentatge);
            flag = false;

        }

        if (desactiv)
        {
            riu.color = new Color(1, 1, 1, alphaI);
        }

    }

   
    public void Percentatge(float percentatge)
    {
        percentatge = actius / totalactius;
        Debug.Log("actius: " + actius);
        rius.SendMessage("Receptor", percentatge);
        
      
    }

}
