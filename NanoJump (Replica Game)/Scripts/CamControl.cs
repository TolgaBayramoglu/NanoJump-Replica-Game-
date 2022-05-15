using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    private Vector3 offset;
    public Transform Ball;//TOPUN R�G�D BODYS�
    public float smoothSpeed;//YUMU�ATMAM�KTARI
    void Start()
    {
        offset = transform.position - Ball.position;//TOPUN PE��NDEN �U KADAR YAVA� G�T
    }

    
    void Update()//KESK�N B�R KAMERA TAK�B� OLMAMASI ���N KAMERAYAYUMU�AK B�R �EK�LDE TOPU TAK�P ETT�RMEK
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + Ball.position, smoothSpeed);
        transform.position = newPos;
    }
}
