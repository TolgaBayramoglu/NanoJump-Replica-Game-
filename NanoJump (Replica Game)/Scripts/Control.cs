using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float rotateSpeed;//D�NME HIZI
    public float boost;//BOOST HIZI

    void Update()
    {

        if (Input.GetKey(KeyCode.A))//A YA BASINCA SOLA D�N
            transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
        if (Input.GetKey(KeyCode.D))//D YE BASINCA SA�A D�N
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        if (Input.GetKeyDown(KeyCode.Space)) //SPACE E BASILI TUTUNCA HIZLANDIR
                rotateSpeed *= boost;
        if (Input.GetKeyUp(KeyCode.Space))//SPACE DEN�EK�NCEESK� HIZA D�N
                rotateSpeed /= boost;
        


    }
}
