using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float rotateSpeed;//DÖNME HIZI
    public float boost;//BOOST HIZI

    void Update()
    {

        if (Input.GetKey(KeyCode.A))//A YA BASINCA SOLA DÖN
            transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
        if (Input.GetKey(KeyCode.D))//D YE BASINCA SAÐA DÖN
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        if (Input.GetKeyDown(KeyCode.Space)) //SPACE E BASILI TUTUNCA HIZLANDIR
                rotateSpeed *= boost;
        if (Input.GetKeyUp(KeyCode.Space))//SPACE DENÇEKÝNCEESKÝ HIZA DÖN
                rotateSpeed /= boost;
        


    }
}
