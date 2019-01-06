using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginMenuUI : MonoBehaviour {
    string result;
    public GameObject[] KImage;
    string user0 = "Element 0";
    string user1 = "Element 1";
    string user2 = "Element 2";
    string user3 = "Element 3";
    string kinderCH;
    public GameObject ConfirmWindow;
    void Start()
    {
        for (int a = 0; a != 4; a++)
        {
            kinderCH = PlayerPrefs.GetString(result);

            if (kinderCH == "Kinder" + a)
            {
                KImage[a].SetActive(true);


            }
            else
            {
                KImage[a].SetActive(false);
            }
        }
    }
    void update()
    {
       


    }

    public void ConfirmUser()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           
    }
    public void CloseWin()
    {
       
            ConfirmWindow.SetActive(false);
       
   
        
    }

    public void Kinder1()
    {
        PlayerPrefs.SetString(user0, "Kinder0");
        PlayerPrefs.SetString(result, PlayerPrefs.GetString(user0));
        ConfirmWindow.SetActive(true);
      //  CloseWin("user0",PlayerPrefs.GetString(user0));
  //      KImage[0].SetActive(true);
     
        Start();
    }

    public void Kinder2()
    {
        PlayerPrefs.SetString(user1, "Kinder1");
        PlayerPrefs.SetString(result,PlayerPrefs.GetString(user1));
        ConfirmWindow.SetActive(true);
      //  KImage[1].SetActive(true);
        Start();
    }

    public void Kinder3()
    {
        PlayerPrefs.SetString(user2, "Kinder2");
     //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetString(result, PlayerPrefs.GetString(user2));
        ConfirmWindow.SetActive(true);
      //  KImage[2].SetActive(true);
        Start();
    }
    public void Kinder4()
    {
        PlayerPrefs.SetString(user3, "Kinder3");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetString(result, PlayerPrefs.GetString(user3));
        ConfirmWindow.SetActive(true);
      //  KImage[3].SetActive(true);
        Start();

    }

}
