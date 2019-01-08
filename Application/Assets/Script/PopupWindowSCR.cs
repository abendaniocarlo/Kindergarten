using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PopupWindowSCR : MonoBehaviour {

    public static bool Paused = false;
    public GameObject PausedUI;
    public GameObject DiagnosticUI;
    string result = "";
    void Start()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(result)))
        {
            DiagnosticUI.SetActive(true);
            Debug.Log("True");
        }
        else
        {
            DiagnosticUI.SetActive(false);
            Debug.Log("false");
        }
     
    }
    public void GoBtn()
    {
        SceneManager.LoadScene("Diagnostic Game");
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
