using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundkeep : MonoBehaviour
{
    public static Soundkeep instance; 

    private void Awake() //ARKA PLAN M�Z��� SAHNEDEN SAHNEYE GE��NCE B�RDEN FAZLAKEZ A�ILMASIN D�YE KULLANILAN SCR�PT.
    {
        DontDestroyOnLoad(this.gameObject); //Y�KLEMEDE OBJEY� S�LME

        if (instance == null) //BU ONBJEDEN DAHA ONCE YOKSA �AL
        {
            instance = this; 
        }
        else //BU OBJEDEN DAHA �NCE VARSA ��MD�K�N� S�L
        {
            Destroy(gameObject); 
        }
    }
}
