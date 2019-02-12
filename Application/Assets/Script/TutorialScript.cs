using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialScript : MonoBehaviour {
    public GameObject MyVideos;
    public GameObject Window;
    public GameObject Activity;
    
	// Use this for initialization
	void Start () {
		
	}
    public void CloseWindow()
    {
        Activity.SetActive(true);
        Window.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void GoColor()
    {
        SceneManager.LoadScene("ColorIT");
    }
    public void GoTrace()
    {
        SceneManager.LoadScene("TraceMe");

    }
    public void GoWatch()
    {
        Window.SetActive(false);
        MyVideos.SetActive(true);
        Activity.SetActive(false);
    }
}
