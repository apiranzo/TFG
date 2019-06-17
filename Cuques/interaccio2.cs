using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaccio2 : MonoBehaviour
{

    Vector3 positionStart;
    Vector3 positionFinish;

    bool flag;
    bool flag2;
    bool flag3;

    float speed = 5f; 
    float startTime;
    float journey;
    float discoveret;
    float fracjourney;

    //float timer;
    //float timeFinish; 

    float movX;
    float movY;
    float movZ;


    void Start()
    {
        positionStart = transform.position;
        positionFinish = new Vector3 (movX, movY, movZ);

        movX = Random.Range(-10f, 10f);
        movY = Random.Range(-5f, 5f);
        //Activar quan hi hagi sensor pujar el rang
        movZ = Random.Range(3f, 20f);

        startTime = Time.time; //dius que el float starttime serà de tipus Time per tant medirà amb frames

        journey = Vector3.Distance(positionStart, positionFinish); //Distance = és la totalitat del recorregut des del punt a al punt b

        /* timer = Time.time;
         timeFinish = 5.0f; */

        flag3 = false; 
    }


    void Update()
    {
        discoveret = (Time.time - startTime) / speed; // declarem que també és time i li restem el time incial
        fracjourney = discoveret / journey; //fraccionem la distància amb time / totalitat del camí 

        if (transform.position == positionStart)
        {
            if (flag2) //quan sigui true entrarà a la funió 
            {
                Reinicialitzar(); //només s'executarà un cop
                flag2 = false; //passarà a false
            }

            flag = true; //s'executarà la segona



        }

        if (transform.position == positionFinish)
        {

            if (!flag2)
            {
                Reinicialitzar();
                flag2 = true;
            }

            flag = false;

        }

        if (flag == true)
            transform.position = Vector3.Lerp(positionStart, positionFinish, fracjourney); //3 paràmetres incial, final, temps entre un i altre 
                                                                                           /*else
                                                                                               transform.localScale = Vector3.Lerp(cucaEnd, cucaStart, fracjourney); //3 paràmetres incial, final, temps entre un i altre*/

        //contador de temps en moviment seguir mirant
        /*timer += Time.deltaTime;
        if (timer >= timeFinish)
        {
            flag = false; 
        } */
        if (flag3 == true)
        {
            positionStart = transform.position;

            movX = Random.Range(-15f, 15f);
            movY = Random.Range(-10f, 10f);
            //flag = true;

            Debug.Log("hola");

            if (Input.GetAxis("Mouse X") > 0 | Input.GetAxis("Mouse X") < 0)
            {
                positionFinish = new Vector3(transform.position.x, movY, transform.position.z);

                transform.position = Vector3.Lerp(positionStart, positionFinish, fracjourney);

            }

            if (Input.GetAxis("Mouse Y") > 0 | Input.GetAxis("Mouse Y") < 0)
            {
                positionFinish = new Vector3(movX, transform.position.y, transform.position.z);

                transform.position = Vector3.Lerp(positionStart, positionFinish, fracjourney);

            }
        }
    }

    private void Reinicialitzar()
    {
        positionStart = transform.position;
        positionFinish = new Vector3(movX, movY, movZ);

        movX = Random.Range(-10f, 10f);
        movY = Random.Range(-5f, 5f);
        movZ = Random.Range(3f, 20f);

        //Debug.Log(cucaStart);
        speed = 5f;


        discoveret = 0.0f;
        fracjourney = 0.0f;
        startTime = Time.time; //dius que el float starttime serà de tipus Time per tant medirà amb frames

        journey = Vector3.Distance(positionStart, positionFinish); //Distance = és la totalitat del recorregut des del punt a al punt b


    }

    private void OnMouseEnter()
    {
        flag3 = true; 
    }
}
