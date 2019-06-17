using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //cal afegir-ho per accedir al mixcontroler Audio


public class MixerControl : MonoBehaviour
{
    public AudioMixerSnapshot baseRius;
    public AudioMixerSnapshot transRius;
    public AudioMixerSnapshot baseCuques;
    public AudioMixerSnapshot transCuques;
    public AudioMixerSnapshot baseConst;
    public AudioMixerSnapshot transConst;
    public AudioMixerSnapshot baseAurores;
    public AudioMixerSnapshot final; 

    public AudioSource baseRiusClip;
    public AudioSource transRiusClip;
    public AudioSource baseCuquesClip;
    public AudioSource transCuquesClip;
    public AudioSource baseConstClip;
    public AudioSource transConstClip;
    public AudioSource baseAuroresClip;

  /*  public AudioClip[] variacioRius;
    public AudioSource variacioRiusSource; */


    public float bpm = 128f;  //bits per minut


    private float m_TransitionIn; //Fade In SI NO LA NECESSITO BORRAR!!!!
    private float m_Transition; // in miliseconds to transition.
    private float m_QuarterNote; 



    void Start()
    {
        m_QuarterNote = 60f / bpm;
        m_TransitionIn = m_QuarterNote; // fadein ràpid (multiplicar per algun nombre si ho volem més lent)
        m_Transition = m_QuarterNote * 25; // fadeout lent (variar el nombre 32 si volem més ràpid)
        baseRiusClip.Play();
        baseRius.TransitionTo(m_Transition);
    }


  

    public void CanviDestat(float estat)
    {

        
        if (estat == 1)
        {
            transRiusClip.Play();
            transRius.TransitionTo(m_Transition);
        }

        if (estat == 2)
        {
            baseCuquesClip.Play();
            baseCuques.TransitionTo(m_Transition);
        }

        if (estat == 3)
        {
            transCuquesClip.Play();
            transCuques.TransitionTo(m_Transition);
        }

        if (estat == 4)
        {
            baseConstClip.Play();
            baseConst.TransitionTo(m_Transition);
        }

        if (estat == 5)
        {
            transConstClip.Play();
            transConst.TransitionTo(m_Transition);
        }

        if (estat == 6)
        {
            baseAuroresClip.Play();
            baseAurores.TransitionTo(m_Transition);
        }

        if (estat == 7)
        {
            final.TransitionTo(m_Transition);
        }
    }

   /* public void VariacioRius(float activ)
    {
        if (activ == 1)
        {
            int randClip = Random.Range(0, variacioRius.Length);
            variacioRiusSource.clip = variacioRius[randClip];
            variacioRiusSource.Play();
        }

        if (activ == 2)
        {
            variacioRiusSource.volume = variacioRiusSource.volume - (Time.deltaTime / (0.5f));
        }

    }*/
    
}
