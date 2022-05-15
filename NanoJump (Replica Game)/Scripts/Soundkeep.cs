using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundkeep : MonoBehaviour
{
    public static Soundkeep instance; 

    private void Awake() //ARKA PLAN MÜZÝÐÝ SAHNEDEN SAHNEYE GEÇÝNCE BÝRDEN FAZLAKEZ AÇILMASIN DÝYE KULLANILAN SCRÝPT.
    {
        DontDestroyOnLoad(this.gameObject); //YÜKLEMEDE OBJEYÝ SÝLME

        if (instance == null) //BU ONBJEDEN DAHA ONCE YOKSA ÇAL
        {
            instance = this; 
        }
        else //BU OBJEDEN DAHA ÖNCE VARSA ÞÝMDÝKÝNÝ SÝL
        {
            Destroy(gameObject); 
        }
    }
}
