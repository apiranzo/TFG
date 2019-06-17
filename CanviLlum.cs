using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanviLlum : MonoBehaviour
{
    public GameObject llumsInicials;
    public GameObject llumsCel;

    private void Start()
    {
        llumsInicials.SetActive(true);
        llumsCel.SetActive(false);

    }

    void CanviLlums()
    {
        llumsInicials.SetActive(false);
        llumsCel.SetActive(true);
    }
}
