using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerceraProvaC : MonoBehaviour
{
    //KINECT

    public bool slideChangeWithGestures = true;
    public float spinSpeed = 5;
    bool one;
    private GameObject KinectObject; 

    // if the presentation cube is behind the user (true) or in front of the user (false)
    private bool isSpinning = false;

    private SimpleGestureListener gestureListener;
    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HipCenter;

    public float rangMax;
    public float rangMin;


    private Vector3 posicioCuca;
    public GameObject planta;
    public GameObject cuca;
    private GameObject cuques;
    public GameObject fum;
    public GameObject cel; 


    //RELLOTGE
    public float temps;
    bool rellotgeActiu;

    //CONTADOR DE TOCS
    public float tocs;
    


    [SerializeField]
    public float percentatge;
    public static int actius;
    public int totalactius;
    bool activun;

    //CERCLES MOVIMENT
    public float degrees;
    public float radials;
    public float speedRotation;
    public float speedRotationBase; 
    public float radiusX;
    public float radiusY;

    public Vector3 centre; //punt central de moviment

    public bool negatiu = true; 


    //JOURNEY
    public float speed; //velocitat
    float startTime;
    float journey; //recorregut que ha de fer entre un i altre posició
    float discoveret; //time total
    float fracjourney; //dividim el recorregut amb segments 

    public Vector3 posicioAncla;
    public Vector3 posicioInici;
    public Vector3 posicioCel;

    //CAP AL CEL
    bool pujar;
    bool volar;

    public AudioClip vol;
    public AudioClip plantes;

    bool volB = true;
    bool plantesB = true; 

    AudioSource fuenteAudio;

    bool activar;
    

    private void Start()
    {
        //KINECT
        isSpinning = false;
        one = true;

        KinectObject = GameObject.Find("KinectObject");

        // get the gestures listener
       gestureListener = KinectObject.GetComponent<SimpleGestureListener>();

        //Posicio central de la rotació
        centre = fum.GetComponent<Transform>().position;

        temps = 0.0f;
        rellotgeActiu = true;

        tocs = 0f;
        startTime = Time.time;

        posicioCuca = cuca.GetComponent<Transform>().position;

        posicioAncla = planta.GetComponent<Transform>().position;

        posicioCel = cel.GetComponent<Transform>().position; 

        pujar = false;
        volar = true;
        

        percentatge = 0;
        actius = 0;
        totalactius = 13; //Pujar al nombre de cuques que hi hagi
        cuques = GameObject.Find("cuques");
        activun = true;

        fuenteAudio = GetComponent<AudioSource>();

        activar = false; 
    }

    void Update()
    {

        KinectManager kinectManager = KinectManager.Instance;
        if ((!kinectManager || !kinectManager.IsInitialized() || !kinectManager.IsUserDetected()))
            return;

        int iJointIndex = (int)TrackedJoint;
       
        if (kinectManager.IsUserDetected())
        {
            uint userId = kinectManager.GetPlayer1ID();
            
            if (kinectManager.IsJointTracked(userId, iJointIndex))
            {
                Vector3 posJoint = kinectManager.GetRawSkeletonJointPos(userId, iJointIndex);
                if (posJoint != Vector3.zero)
                {
                    if (!isSpinning)
                    {

                        if (slideChangeWithGestures && gestureListener)
                        {
                            if (activar)
                            {
                                if (posJoint.x <= rangMax && posJoint.x >= rangMin)
                                {
                                    if (!rellotgeActiu)
                                    {
                                        Debug.Log("hola wave");
                                        tocs = 0;
                                        if (plantesB)
                                        {
                                            fuenteAudio.clip = plantes;
                                            fuenteAudio.Play();
                                            plantesB = false;
                                            volB = false;
                                            one = true;
                                        }

                                        rellotgeActiu = true;
                                        activar = false;


                                    }
                                }

                            }

                            if (!activar)
                            {
                                if (gestureListener.IsWave())
                                {
                                    if (temps >= 5f)
                                    {
                                        Debug.Log("hola swipeUp");
                                        if (rellotgeActiu)
                                        {


                                            speedRotationBase = speedRotation;

                                            for (int i = 0; i <= 10; i++)
                                            {
                                                speedRotation = 600;
                                                MovimentCuca();

                                                if (i == 10)
                                                {
                                                    speedRotation = speedRotationBase;
                                                    MovimentCuca();

                                                }
                                            }
                                            

                                            if (volB)
                                            {
                                                fuenteAudio.clip = vol;
                                                fuenteAudio.Play();
                                                volB = false;
                                                one = true;
                                            }
                                            if (one)
                                            {
                                                tocs++; //això només ha de passar una vegada
                                                volB = true;
                                                plantesB = true; //POSAR AIXÒ QUAN FINALITZA EL GEST
                                                one = false;
                                            }

                                        }
                                    }

                                }
                            }

                        }

                    }
                }
            }
        }
       




        if (volar)
        {
            if (rellotgeActiu)
            {
                temps += Time.deltaTime;

                if (temps <= 0f)
                {
                    // Debug.Log("Cuca quieta");
                }

                if (temps > 0f && temps <= 11f)
                {
                    radiusX = 1f;
                    radiusY = 0.3f; 
                    if (negatiu)
                        speedRotation = 80f;
                    if (!negatiu)
                        speedRotation = -80f; 
                    MovimentCuca();
                    centre.y += .005f; 
                    
                }

                if (temps > 11f && temps <= 30f)
                {
                    // Debug.Log("Cuca mou");
                    if (radiusY <= 1.5f)
                        radiusY += .005f;
                    if (radiusX <= 2f)
                        radiusX += .005f;
                    if (speedRotation >= 50 && negatiu)
                        speedRotation--;
                    if (speedRotation <= -50 && !negatiu)
                        speedRotation++;
                    MovimentCuca();
                }

                if (temps > 30f)
                {
                    // Debug.Log("Cuca baixa");
                    posicioInici = posicioCuca;
                    Journey();
                }

                if (posicioCuca == posicioAncla)
                {
                    //  Debug.Log("Stop");
                    //Debug.Log(posicioCuca);
                    //Debug.Log(posicioAncla);

                    rellotgeActiu = false;

                    centre = posicioAncla;
                    if (negatiu)
                        negatiu = false;
                    if (!negatiu)
                        negatiu = true;

                    activar = true; 
                    
                }
            }

            if (!rellotgeActiu)
            {
                temps = 0f;

            }
        }

       
        
            if (tocs >= 3)
            {

                volar = false;
                pujar = true;
                isSpinning = true; 
            }
        
       

        if (pujar)
        {
            posicioInici = posicioCuca;
            Journey2();
        }
    }

    



    public void MovimentCuca()
    {
        degrees += speedRotation * Time.deltaTime;
        radials = degrees * Mathf.Deg2Rad; //Convertimos a radiales

        Vector3 postInCircle = Vector3.zero; //posició de la cuca dins del cercle de moviment
        postInCircle.x = Mathf.Cos(radials) * radiusX;
        postInCircle.y = Mathf.Sin(radials) * radiusY;


        posicioCuca = centre + postInCircle;

        cuca.transform.position = posicioCuca;
    }

    public void Journey()
    {


        journey = Vector3.Distance(posicioInici, posicioAncla);

        discoveret = (Time.time - startTime) * speed; // declarem que també és time i li restem el time incial
        fracjourney = discoveret / journey; //fraccionem la distància amb time / totalitat del camí

        posicioCuca = Vector3.Lerp(posicioInici, posicioAncla, fracjourney);

        cuca.transform.position = posicioCuca;


    }

    public void Journey2()
    {
        journey = Vector3.Distance(posicioInici, posicioCel);

        discoveret = (Time.time - startTime) * speed; // declarem que també és time i li restem el time incial
        fracjourney = discoveret / journey; //fraccionem la distància amb time / totalitat del camí

        posicioCuca = Vector3.Lerp(posicioInici, posicioCel, fracjourney);

        cuca.transform.position = posicioCuca;

        if (posicioCuca == posicioCel && activun)
        {
            actius++;
            Percentatge(percentatge);
            activun = false;
            Destroy(fuenteAudio);
        }
        

    }

    public void Percentatge(float percentatge)
    {
        percentatge = actius / totalactius;
        Debug.Log("actius: " + actius);
        cuques.SendMessage("Receptor", percentatge);

    }
}
