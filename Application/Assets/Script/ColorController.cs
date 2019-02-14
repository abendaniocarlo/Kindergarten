using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorController : MonoBehaviour {
    string result;
    string myUser;
	// Use this for initialization
	void Start () {
      myUser =  PlayerPrefs.GetString(result);
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
