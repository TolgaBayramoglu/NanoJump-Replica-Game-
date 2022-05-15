using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gm;
    public Rigidbody rb;//BALL RÝGÝDBODY
    public float jumpForce;//ZIPLAMA GÜCÜ
    public float maxSpeed;//MAX HIZ
    public GameObject SplashPrefab;//ÇATLAMA EFEKTÝ
    public GameObject gem1, gem2, gem3;// GEM OBJELERÝ
    public GameObject diemenu;//ÖLÜM MENÜSÜ
    public GameObject nextlevelmenu;//SONRAKÝ SEVÝYE MENÜSÜ
    public GameObject mutemenu;//MUTE MENUSU
    public GameObject vericekme;//BÝR DÝÐER SCRÝPTTEN VERÝ ÇEKME

    void Start()
    {
        gm = GameManager.FindObjectOfType<GameManager>();  //GM YE GAME MANAGER I ATAMA
    }

 
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = Vector3.up * jumpForce * Time.deltaTime;//OPTÝMÝZE ZIPLAMA
        //rb.AddForce(Vector3.up * jumpForce);//hatalý dengesiz zýplýyor
        GameObject splash = Instantiate(SplashPrefab, transform.position + new Vector3(0f,-0.21f,0f), Quaternion.Euler(new Vector3(90, 10, 0)));//HER YERE DEÐDÝÐÝNDE ÇARPMA EFEKTÝNÝ ÇOÐALTIR
        splash.transform.SetParent(other.gameObject.transform);
        Destroy(splash, 3f);//EFEKTÝ YOK EDER
        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;//MATERYAL ADINI ÇEKER
        Debug.Log("materyal adý:" + materialName);//MATERYAL ADINI YAZDIRIR
        if (materialName == "Safe Color (Instance)")//MATERYAL ADI SAFE COLORSA
        {
            SoundManagerScript.playSound("jump");//ZIPLAMA SESÝ ÇAL
        }
        else if (materialName == "Unsafe Color (Instance)")//MATERYAL ADI UNSAFE COLORSA 
        {
            SoundManagerScript.playSound("over");//ÖLÜM SESÝ ÇAL
            diemenu.SetActive(true);//ÖLÜM MENUSUNU AKTÝVE ET
            mutemenu.SetActive(true);//MUTE MENUSUNUAKTÝVE ET
            Time.timeScale = 0.0f;//ZAMANI DURDUR
            vericekme.GetComponent<GameManager>().kontrol2 = false;//GAME MANAGERDAN ESC YE BASILIP BASILAMAYACAÐINI SAÐLAYAN KONTROL VERÝSÝNÝ ÇEKME.(BUNUN SAYESÝNDE ÖLÜMVEYA BÝTÝÞ MENUSUNDEESC MENUSU AÇILAMAZ)
        }
        else if (materialName == "Last Ring (Instance)") //MATERYAL ADI LASRÝNGSE
        {
            SoundManagerScript.playSound("win");//KAZANMA SESÝ ÇAL
            nextlevelmenu.SetActive(true);//NEXT LEVEL MENUSUNU AKTÝVE ET
            mutemenu.SetActive(true);//MUTE MENUSUNUAKTÝVE ET
            Time.timeScale = 0.0f;//ZAMANI DURDUR
            vericekme.GetComponent<GameManager>().kontrol2 = false;//GAME MANAGERDAN ESC YE BASILIP BASILAMAYACAÐINI SAÐLAYAN KONTROL VERÝSÝNÝ ÇEKME(BUNUN SAYESÝNDE ÖLÜMVEYA BÝTÝÞ MENUSUNDEESC MENUSU AÇILAMAZ)
        }
    }
    private void OnTriggerEnter(Collider other)//GEMLERÝN TRIGGER EYLEMÝ
    {
        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;//MATERYAL ADINI ÇEK
        Debug.Log("materyal adý:" + materialName);//MATERYAL ADINI YAZDIR
        if (materialName == "gem1 (Instance)")//MATERYAL ADI GEM1 ÝSE
        {
            SoundManagerScript.playSound("gem");//GEM SESÝNÝ ÇAL
            GameObject.FindWithTag("purple").GetComponent<MeshRenderer>().enabled = false;//PURPLE TAGLÝ OBJENÝN MESHRENDERER INI DEAKTÝVE ET
            GameObject.FindWithTag("purple").GetComponent<MeshCollider>().enabled = false;//PURPLE TAGLÝ OBJENÝN MESH COLLÝDER INI DEAKTÝVE ET
            gem1.SetActive(true);//GEM1 GÖRSELÝNÝ ARAYÜZDE AKTÝVE ET
        }
        if (materialName == "gem2 (Instance)")//MATERYAL ADI GEM2 ÝSE
        {
            SoundManagerScript.playSound("gem");//GEM SESÝNÝ ÇAL
            GameObject.FindWithTag("black").GetComponent<MeshRenderer>().enabled = false;//BLACK TAGLÝ OBJENÝN MESHRENDERER INI DEAKTÝVE ET
            GameObject.FindWithTag("black").GetComponent<MeshCollider>().enabled = false;//BLACK TAGLÝ OBJENÝN MESH COLLÝDER INI DEAKTÝVE ET
            gem2.SetActive(true);//GEM2 GÖRSELÝNÝ ARAYÜZDE AKTÝVE ET
        }
        if (materialName == "gem3 (Instance)")//MATERYAL ADI GEM3 ÝSE
        {
            SoundManagerScript.playSound("gem");//GEM SESÝNÝ ÇAL
            GameObject.FindWithTag("green").GetComponent<MeshRenderer>().enabled = false;//GREEN TAGLÝ OBJENÝN MESHRENDERER INI DEAKTÝVE ET
            GameObject.FindWithTag("green").GetComponent<MeshCollider>().enabled = false;//GREEN TAGLÝ OBJENÝN MESH COLLÝDER INI DEAKTÝVE ET
            gem3.SetActive(true);//GEM3 GÖRSELÝNÝ ARAYÜZDE AKTÝVE ET
        }
    }
    public void FixedUpdate()//OBJENÝN FAZLA HIZLANMASINI ENGELLEMEK ÝÇÝN HIZ SINIRLANDIRMA
    {
        if (rb.velocity.magnitude > maxSpeed)//OBJENÝN HIZI MAX SPEEDDEN HIZLIYSA
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;//HIZI MAX SPEEDE EÞÝTLE
        }
    }
}
