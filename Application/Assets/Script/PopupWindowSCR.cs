using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PopupWindowSCR : MonoBehaviour {

    public static bool Paused = false;
    public GameObject PausedUI;
    string result = "";
    void Start()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(result)))
        {
            SceneManager.LoadScene("Diagnostic Game");
        }
     
    }
    public void ResumeBTN()
    {
        PausedUI.SetActive(false);
    }
     public void QuitBTN()
    {
        Application.Quit();
        Debug.Log("GAME EXIT");
    }
}
