using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentAurores : MonoBehaviour
{
    private Animator animator;

    private AudioSource effect;

    public SpriteRenderer aurora;

    private Light auroraLlum;

    

    [SerializeField]
    public float percentatge;

    public static int actius = 0;
    public int totalactius;

    
    

    private GameObject aurores;
    public GameObject auroraCollider;

    private Animator auroraAnim;


    void Start()
    {
        animator = GetComponent<Animator>();
        aurores = GameObject.Find("aurores");

        effect = GetComponent<AudioSource>();

        aurora = GetComponent<SpriteRenderer>();
        aurora.enabled = false; 

        auroraLlum = GetComponent<Light>();
        auroraLlum.enabled = false;
        

        
        percentatge = 0;
        
        totalactius = 7; //Pujar a ?? quantes son

         

        //auroraCollider = GameObject.Find(auroraCollider.name);
         
    }

    private void Update()
    {
        aurora.enabled = true; 
        animator.enabled = true;
        auroraLlum.enabled = true;
        
        
        
    }

    public void Sound()
    {
        
        effect.Play();
            
    }

    private void Automatic()
    {
        //auroraCollider.SendMessage("Automatic", false); //Mirar com fer-ho
        //Debug.Log("Automatic");
        animator.SetFloat("revert", 1f);
        auroraCollider.GetComponent<AuroraCollider>().enabled = false;
        effect.Play();
    }

    private void Contador()
    {
        actius++;
        Percentatge(percentatge);
        effect.Play();
        

    }

    public void Percentatge(float percentatge)
    {
        percentatge = actius / totalactius;
        Debug.Log("actius: " + actius);
        aurores.SendMessage("Receptor", percentatge);


    }




}
