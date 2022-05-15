using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image bar;//HER D�SKTE ARTACAK BAR
    private float barmax = 300.0f;//BARIN MAX DE�ER�
    private int score = 0;//BA�LANGI� DE�ER�
    public Text scoreText;//SKOR YAZISI
    private bool kontrol;//ESC KONTROL�
    public bool kontrol2 = true;//VER� CEKME �LE �LET�LECEK, D��ER MENULER A�IKKEN ESC MENUSUNUN A�ILMASINI ENGELLEYECEK KONTROL
    public GameObject mutemenu;//MUTE MENU
    public GameObject escmenu;//ESC MENUSU
    void Start()
    {
        
    }


    void Update()//
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&kontrol2)//ESC BASINCA MENUYU A�ACAK KOD
        {
            if (kontrol)//MEN� KAPALIYSA
            {
                escmenu.SetActive(true);//ESCMENU AK�F ET
                mutemenu.SetActive(true);//MUTE MENU AKT�F ET
                Time.timeScale = 0.0f;//ZAMANI DURDUR
                kontrol = false;//A�IK KAPALI KONTROL�
            }
            else if (!kontrol)//MENU A�IKSA
            {
                escmenu.SetActive(false);//ESC MENU DEAKT�VE ET
                mutemenu.SetActive(false);//MUTE MENU DEAKT�VE ET
                Time.timeScale = 1.0f;//ZAMANI DURDUR
                kontrol = true;//A�IK KAPALI KONTROL�
            }
        }
    }

    public void GameScore(int ringScore)//SKOR DA�RES�N�N EYLEM�N� SA�LAYAN FONKS�YON
    {
        score += ringScore;//SKORU R�NG SKORE KADAR ARTTIR
        scoreText.text = score.ToString();//TEXT �STR�NGE �EV�R
        bar.fillAmount = score / barmax;  //SKORUN TAMAMLANMA ORANI
    }
    public void Exit()//EX�T TU� FONKS�YONU
    {
        Application.Quit();//�IKI�
        Debug.Log("Quit");
    }
    public void MainMenu()//MA�N MENU TU� FONKS�YONU
    {
        SceneManager.LoadScene("Scenes/mainmenu");//MA�N MENU SAHNES�N� Y�KLE
    }
    public void Restart()//RESTART TU� FONKS�YONU
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//RESTART SAHNES�N� Y�KLE
        Time.timeScale = 1.0f;//ZAMANI NORMAL YAP
    }
    public void tutorial()//TUTOR�AL TU� FONKS�YONU
    {
        SceneManager.LoadScene("Scenes/tutorial");//TUTOR�AL SAHNES�N� Y�KLE
    }
    public void credit()//CRED�T TU� FONKS�YONU
    {
        SceneManager.LoadScene("Scenes/credit");//CRED�T SAHNES�N� Y�KLE
    }
    public void levels()//LEVELS TU� FONKS�YONU
    {
        SceneManager.LoadScene("Scenes/levels");//LEVELS SAHNES�N� Y�KLE
    }
    public void tolevel1()//LEVEL1 TU� FONKS�YONU
    {
        SceneManager.LoadScene("Scenes/level1");//LEVEL 1 SAHNES�N� Y�KLE
        Time.timeScale = 1.0f;//ZAMANI NORMAL YAP
    }
    public void tolevel2()//LEVEL2 TU� FONKS�YONU
    {
        SceneManager.LoadScene("Scenes/level2");//LEVEL2 SAHNES�N� Y�KLE
        Time.timeScale = 1.0f;//ZAMANI NORMAL YAP
    }
    public void tolevel3()//LEVEL3 TU� FONKS�YONU
    {
        SceneManager.LoadScene("Scenes/level3");//LEVEL3 SAHNES�N� Y�KLE
        Time.timeScale = 1.0f;//ZAMANI NORMAL YAP
    }

}
