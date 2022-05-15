using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// //////////////////////////////////////////SES KAPATIP A�MAK(MUTE/UNMUTE) ���N KULLANILAN SCR�PT. SES�N SON HAL�N� HATIRLAYIP SAHNELER ARASI GE���TE A�/KAPA YAPMAYI SA�LIYOR

public class soundcontrol : MonoBehaviour
{
    [SerializeField] Image soundon;
    [SerializeField] Image soundoff;
    private bool muted=false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        updatebutton();
        AudioListener.pause = muted;
    }
    private void updatebutton()
    {
        if (muted == false)
        {
            soundon.enabled = true;
            soundoff.enabled = false;
        }
        else
        {
            soundon.enabled = false;
            soundoff.enabled = true;
        }

    }
    public void onbuttonpress()//TU�A BASINCA GER�EKLE�ECEK EYLEM
    { 
        if(muted==false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else 
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        updatebutton();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1; 
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

}
