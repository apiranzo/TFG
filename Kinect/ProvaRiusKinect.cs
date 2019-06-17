using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaRiusKinect : MonoBehaviour
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

     public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HipCenter;
    //private GameObject[] joints;
    private GameObject joint;  

     //int i;
     //private GameObject nameHip; 


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

                    joint = GameObject.Find("HipCenterCollider");

                    Debug.Log(joint.name);

                    //PROVA1

                    /* 
                    for (i=0; i<joints.Length; i++)
                     {
                        if (joints[i].name == "HipCenter")
                        {
                         if (collision.gameObject == joints[i])
                            {
                                Debug.Log("collision" + collision.gameObject.name);
                            }
                        
                        }
                      
                     }  */



                    /*   //PROVA2
                       foreach(GameObject joints in GameObject[])
                       { if (joints.name == "HipCenter"){

                          }
                       }


                       if (collision.gameObject == joints[0])
                       {
                           Debug.Log("Mateixa posició");
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
                       } */

                }

            }

        }

    }



    public void OnTriggerStay(Collider collision)
    {
        
        
            Debug.Log("collision" + collision.gameObject.name);
            

    }

     private void PujarAlpha()
     {
         if (activ)
         {
             riu.color = new Color(1, 1, 1, alphaI);
         }

         if (activ && alphaI <= alphaF)
         {
             alphaI += .003f;
             riu.color = new Color(1, 1, 1, alphaI);
             //Debug.Log(alphaI);
         }

         if (activ && alphaI >= alphaF && flag)
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


