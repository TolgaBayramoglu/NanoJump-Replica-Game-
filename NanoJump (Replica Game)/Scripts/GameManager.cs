using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image bar;//HER DÝSKTE ARTACAK BAR
    private float barmax = 300.0f;//BARIN MAX DEÐERÝ
    private int score = 0;//BAÞLANGIÇ DEÐERÝ
    public Text scoreText;//SKOR YAZISI
    private bool kontrol;//ESC KONTROLÜ
    public bool kontrol2 = true;//VERÝ CEKME ÝLE ÝLETÝLECEK, DÝÐER MENULER AÇIKKEN ESC MENUSUNUN AÇILMASINI ENGELLEYECEK KONTROL
    public GameObject mutemenu;//MUTE MENU
    public GameObject escmenu;//ESC MENUSU
    void Start()
    {
        
    }


    void Update()//
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&kontrol2)//ESC BASINCA MENUYU AÇACAK KOD
        {
            if (kontrol)//MENÜ KAPALIYSA
            {
                escmenu.SetActive(true);//ESCMENU AKÝF ET
                mutemenu.SetActive(true);//MUTE MENU AKTÝF ET
                Time.timeScale = 0.0f;//ZAMANI DURDUR
                kontrol = false;//AÇIK KAPALI KONTROLÜ
            }
            else if (!kontrol)//MENU AÇIKSA
            {
                escmenu.SetActive(false);//ESC MENU DEAKTÝVE ET
                mutemenu.SetActive(false);//MUTE MENU DEAKTÝVE ET
                Time.timeScale = 1.0f;//ZAMANI DURDUR
                kontrol = true;//AÇIK KAPALI KONTROLÜ
            }
        }
    }

    public void GameScore(int ringScore)//SKOR DAÝRESÝNÝN EYLEMÝNÝ SAÐLAYAN FONKSÝYON
    {
        score += ringScore;//SKORU RÝNG SKORE KADAR ARTTIR
        scoreText.text = score.ToString();//TEXT ÝSTRÝNGE ÇEVÝR
        bar.fillAmount = score / barmax;  //SKORUN TAMAMLANMA ORANI
    }
    public void Exit()//EXÝT TUÞ FONKSÝYONU
    {
        Application.Quit();//ÇIKIÞ
        Debug.Log("Quit");
    }
    public void MainMenu()//MAÝN MENU TUÞ FONKSÝYONU
    {
        SceneManager.LoadScene("Scenes/mainmenu");//MAÝN MENU SAHNESÝNÝ YÜKLE
    }
    public void Restart()//RESTART TUÞ FONKSÝYONU
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//RESTART SAHNESÝNÝ YÜKLE
        Time.timeScale = 1.0f;//ZAMANI NORMAL YAP
    }
    public void tutorial()//TUTORÝAL TUÞ FONKSÝYONU
    {
        SceneManager.LoadScene("Scenes/tutorial");//TUTORÝAL SAHNESÝNÝ YÜKLE
    }
    public void credit()//CREDÝT TUÞ FONKSÝYONU
    {
        SceneManager.LoadScene("Scenes/credit");//CREDÝT SAHNESÝNÝ YÜKLE
    }
    public void levels()//LEVELS TUÞ FONKSÝYONU
    {
        SceneManager.LoadScene("Scenes/levels");//LEVELS SAHNESÝNÝ YÜKLE
    }
    public void tolevel1()//LEVEL1 TUÞ FONKSÝYONU
    {
        SceneManager.LoadScene("Scenes/level1");//LEVEL 1 SAHNESÝNÝ YÜKLE
        Time.timeScale = 1.0f;//ZAMANI NORMAL YAP
    }
    public void tolevel2()//LEVEL2 TUÞ FONKSÝYONU
    {
        SceneManager.LoadScene("Scenes/level2");//LEVEL2 SAHNESÝNÝ YÜKLE
        Time.timeScale = 1.0f;//ZAMANI NORMAL YAP
    }
    public void tolevel3()//LEVEL3 TUÞ FONKSÝYONU
    {
        SceneManager.LoadScene("Scenes/level3");//LEVEL3 SAHNESÝNÝ YÜKLE
        Time.timeScale = 1.0f;//ZAMANI NORMAL YAP
    }

}
