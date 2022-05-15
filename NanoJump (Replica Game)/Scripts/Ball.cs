using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gm;
    public Rigidbody rb;//BALL R�G�DBODY
    public float jumpForce;//ZIPLAMA G�C�
    public float maxSpeed;//MAX HIZ
    public GameObject SplashPrefab;//�ATLAMA EFEKT�
    public GameObject gem1, gem2, gem3;// GEM OBJELER�
    public GameObject diemenu;//�L�M MEN�S�
    public GameObject nextlevelmenu;//SONRAK� SEV�YE MEN�S�
    public GameObject mutemenu;//MUTE MENUSU
    public GameObject vericekme;//B�R D��ER SCR�PTTEN VER� �EKME

    void Start()
    {
        gm = GameManager.FindObjectOfType<GameManager>();  //GM YE GAME MANAGER I ATAMA
    }

 
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = Vector3.up * jumpForce * Time.deltaTime;//OPT�M�ZE ZIPLAMA
        //rb.AddForce(Vector3.up * jumpForce);//hatal� dengesiz z�pl�yor
        GameObject splash = Instantiate(SplashPrefab, transform.position + new Vector3(0f,-0.21f,0f), Quaternion.Euler(new Vector3(90, 10, 0)));//HER YERE DE�D���NDE �ARPMA EFEKT�N� �O�ALTIR
        splash.transform.SetParent(other.gameObject.transform);
        Destroy(splash, 3f);//EFEKT� YOK EDER
        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;//MATERYAL ADINI �EKER
        Debug.Log("materyal ad�:" + materialName);//MATERYAL ADINI YAZDIRIR
        if (materialName == "Safe Color (Instance)")//MATERYAL ADI SAFE COLORSA
        {
            SoundManagerScript.playSound("jump");//ZIPLAMA SES� �AL
        }
        else if (materialName == "Unsafe Color (Instance)")//MATERYAL ADI UNSAFE COLORSA 
        {
            SoundManagerScript.playSound("over");//�L�M SES� �AL
            diemenu.SetActive(true);//�L�M MENUSUNU AKT�VE ET
            mutemenu.SetActive(true);//MUTE MENUSUNUAKT�VE ET
            Time.timeScale = 0.0f;//ZAMANI DURDUR
            vericekme.GetComponent<GameManager>().kontrol2 = false;//GAME MANAGERDAN ESC YE BASILIP BASILAMAYACA�INI SA�LAYAN KONTROL VER�S�N� �EKME.(BUNUN SAYES�NDE �L�MVEYA B�T�� MENUSUNDEESC MENUSU A�ILAMAZ)
        }
        else if (materialName == "Last Ring (Instance)") //MATERYAL ADI LASR�NGSE
        {
            SoundManagerScript.playSound("win");//KAZANMA SES� �AL
            nextlevelmenu.SetActive(true);//NEXT LEVEL MENUSUNU AKT�VE ET
            mutemenu.SetActive(true);//MUTE MENUSUNUAKT�VE ET
            Time.timeScale = 0.0f;//ZAMANI DURDUR
            vericekme.GetComponent<GameManager>().kontrol2 = false;//GAME MANAGERDAN ESC YE BASILIP BASILAMAYACA�INI SA�LAYAN KONTROL VER�S�N� �EKME(BUNUN SAYES�NDE �L�MVEYA B�T�� MENUSUNDEESC MENUSU A�ILAMAZ)
        }
    }
    private void OnTriggerEnter(Collider other)//GEMLER�N TRIGGER EYLEM�
    {
        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;//MATERYAL ADINI �EK
        Debug.Log("materyal ad�:" + materialName);//MATERYAL ADINI YAZDIR
        if (materialName == "gem1 (Instance)")//MATERYAL ADI GEM1 �SE
        {
            SoundManagerScript.playSound("gem");//GEM SES�N� �AL
            GameObject.FindWithTag("purple").GetComponent<MeshRenderer>().enabled = false;//PURPLE TAGL� OBJEN�N MESHRENDERER INI DEAKT�VE ET
            GameObject.FindWithTag("purple").GetComponent<MeshCollider>().enabled = false;//PURPLE TAGL� OBJEN�N MESH COLL�DER INI DEAKT�VE ET
            gem1.SetActive(true);//GEM1 G�RSEL�N� ARAY�ZDE AKT�VE ET
        }
        if (materialName == "gem2 (Instance)")//MATERYAL ADI GEM2 �SE
        {
            SoundManagerScript.playSound("gem");//GEM SES�N� �AL
            GameObject.FindWithTag("black").GetComponent<MeshRenderer>().enabled = false;//BLACK TAGL� OBJEN�N MESHRENDERER INI DEAKT�VE ET
            GameObject.FindWithTag("black").GetComponent<MeshCollider>().enabled = false;//BLACK TAGL� OBJEN�N MESH COLL�DER INI DEAKT�VE ET
            gem2.SetActive(true);//GEM2 G�RSEL�N� ARAY�ZDE AKT�VE ET
        }
        if (materialName == "gem3 (Instance)")//MATERYAL ADI GEM3 �SE
        {
            SoundManagerScript.playSound("gem");//GEM SES�N� �AL
            GameObject.FindWithTag("green").GetComponent<MeshRenderer>().enabled = false;//GREEN TAGL� OBJEN�N MESHRENDERER INI DEAKT�VE ET
            GameObject.FindWithTag("green").GetComponent<MeshCollider>().enabled = false;//GREEN TAGL� OBJEN�N MESH COLL�DER INI DEAKT�VE ET
            gem3.SetActive(true);//GEM3 G�RSEL�N� ARAY�ZDE AKT�VE ET
        }
    }
    public void FixedUpdate()//OBJEN�N FAZLA HIZLANMASINI ENGELLEMEK ���N HIZ SINIRLANDIRMA
    {
        if (rb.velocity.magnitude > maxSpeed)//OBJEN�N HIZI MAX SPEEDDEN HIZLIYSA
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;//HIZI MAX SPEEDE E��TLE
        }
    }
}
