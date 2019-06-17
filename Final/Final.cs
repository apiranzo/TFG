using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    private SpriteRenderer logo;
    float AlphaI; 

    void Start()
    {
        logo = GetComponent<SpriteRenderer>();
        AlphaI = logo.color.a;  
    }

    // Update is called once per frame
    void Update()
    {
        if (AlphaI <= 1f)
        {
            AlphaI += .002f;
            logo.color = new Color(1, 1, 1, AlphaI);
        }

        if (AlphaI >= 1f)
        {
            for(int i = 0; i <= 600; i++)
            {
                if (i == 600)
                {
                    SceneManager.LoadScene("Inici");
                }
            }
        }
    }
}
