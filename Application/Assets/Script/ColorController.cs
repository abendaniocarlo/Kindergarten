using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorController : MonoBehaviour {
    string result;
    string myUser;
    int count;
    public GameObject[] LockedIcons;
	// Use this for initialization
    void Start()
    {
        myUser = PlayerPrefs.GetString(result);

        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Red", 0) != 0)
        {
            LockedIcons[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Orange", 0) != 0)
        {
            LockedIcons[1].SetActive(false);


        }
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Yellow", 0) != 0)
        {
            LockedIcons[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Green", 0) != 0)
        {
            LockedIcons[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Blue", 0) != 0)
        {
            LockedIcons[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Purple", 0) != 0)
        {
            LockedIcons[5].SetActive(false);
        }
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Brown", 0) != 0)
        {
            LockedIcons[6].SetActive(false);
        }
        //if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Pink", 0) != 0)
        //{
        //    LockedIcons[7].SetActive(false);
        //}
    }
    public void Red()
    {
        SceneManager.LoadScene("Colors Red");
    }
    public void Brown()
    {
        SceneManager.LoadScene("Colors Brown");
    }
    public void Orange()
    {
        SceneManager.LoadScene("Colors Orange");
    }
    public void Pink()
    {
        SceneManager.LoadScene("Colors Pink");
    }
    public void Yellow()
    {
        SceneManager.LoadScene("Colors Yellow");
    }
    public void Green()
    {
        SceneManager.LoadScene("Colors Green");
    }
    public void Blue()
    {
        SceneManager.LoadScene("Colors Activities");
    }
    public void Purple()
    {
        SceneManager.LoadScene("Colors Purple");
    }
    public void GoReturn()
    {
        SceneManager.LoadScene("Play Menu");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
