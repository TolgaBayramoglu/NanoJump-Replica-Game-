using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public Transform ball;//TOPUN R�G�DBODYS�
    private GameManager gm;
   
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();//GM YE GAME MANAGER I ATA
    }

  
    void Update()
    {
        if (transform.position.y +12.5f >= ball.position.y)//HER D�SK�N 12.5 ALTINAG�D�NCE
        {
            Destroy(gameObject);//O D�SK� S�L
            gm.GameScore(25);//SKORA 25 PUAN EKLE
            SoundManagerScript.playSound("pass");//PASS SES�N� �AL
        }
    }
}
