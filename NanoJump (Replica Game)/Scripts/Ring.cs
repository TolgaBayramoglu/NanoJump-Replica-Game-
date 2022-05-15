using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public Transform ball;//TOPUN RÝGÝDBODYSÝ
    private GameManager gm;
   
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();//GM YE GAME MANAGER I ATA
    }

  
    void Update()
    {
        if (transform.position.y +12.5f >= ball.position.y)//HER DÝSKÝN 12.5 ALTINAGÝDÝNCE
        {
            Destroy(gameObject);//O DÝSKÝ SÝL
            gm.GameScore(25);//SKORA 25 PUAN EKLE
            SoundManagerScript.playSound("pass");//PASS SESÝNÝ ÇAL
        }
    }
}
