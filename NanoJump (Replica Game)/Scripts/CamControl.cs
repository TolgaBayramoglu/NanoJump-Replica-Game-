using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    private Vector3 offset;
    public Transform Ball;//TOPUN RÝGÝD BODYSÝ
    public float smoothSpeed;//YUMUÞATMAMÝKTARI
    void Start()
    {
        offset = transform.position - Ball.position;//TOPUN PEÞÝNDEN ÞU KADAR YAVAÞ GÝT
    }

    
    void Update()//KESKÝN BÝR KAMERA TAKÝBÝ OLMAMASI ÝÇÝN KAMERAYAYUMUÞAK BÝR ÞEKÝLDE TOPU TAKÝP ETTÝRMEK
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + Ball.position, smoothSpeed);
        transform.position = newPos;
    }
}
