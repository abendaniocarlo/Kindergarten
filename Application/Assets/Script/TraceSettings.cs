using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TraceSettings : MonoBehaviour {

    public GameObject[] Images;
    public GameObject Window;
    int KeyLog = 0;
 
    void Start()
    {
      
    }
    public void NextBtn()
    {

        KeyLog++;
        Images[KeyLog].SetActive(true);
        Images[KeyLog - 1].SetActive(false);
        if (KeyLog == 12)
        {
            Images[KeyLog].SetActive(false);
          
            KeyLog = 0;
            Images[KeyLog].SetActive(true);
        }
    }
    public void PrevBtn()
    {

        KeyLog--;
        Images[KeyLog].SetActive(true);
        Images[KeyLog + 1].SetActive(false);
        if (KeyLog == 0)
        {
            Images[KeyLog].SetActive(false);
            KeyLog = 12;
            Images[KeyLog].SetActive(true);
        }
    }
    public void Retry()
    {
        StartCoroutine("Restart");
        Debug.Log("restrt");
    }
    IEnumerator Restart()
    {

        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Window.SetActive(false);
    }
    public void Exit()  
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("ShapeIndex", "No Shape"));
    }


}
