using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// ////////////////////////////////�S�MLER�YLE G�STER�LD��� �EK�LDE SES EFEKTLER�N� BARINDIRAN VE �ALI�MASINI SA�LAYAN SCR�PT

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jump,over,win,pass,gem;
    static AudioSource AudioSrc;
    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        over = Resources.Load<AudioClip>("over");
        win = Resources.Load<AudioClip>("win");
        pass = Resources.Load<AudioClip>("pass");
        gem = Resources.Load<AudioClip>("gem");
        AudioSrc = GetComponent<AudioSource>();

    }

    
    void Update()
    {
        
    }

    public static void playSound(string clip) 
    {
        switch (clip) 
        {
            case "jump":
                AudioSrc.PlayOneShot(jump);
                break;
            case "over":
                AudioSrc.PlayOneShot(over);
                break;
             case "win":
                AudioSrc.PlayOneShot(win);
                break;
            case "pass":
                AudioSrc.PlayOneShot(pass);
                break;
            case "gem":
                AudioSrc.PlayOneShot(gem);
                break;
           
        }
    }
}
