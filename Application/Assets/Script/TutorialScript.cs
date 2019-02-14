using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialScript : MonoBehaviour {
    public GameObject MyVideos;
    public GameObject Window;
    public GameObject Activity;
    public GameObject TutorialWindow;
	// Use this for initializastion
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
    public void GoWatch2()
    {
        
        Window.SetActive(false);
        MyVideos.SetActive(true);
        TutorialWindow.SetActive(false);
      
    }
    public void VideoListClose()
    {
        MyVideos.SetActive(false);
        Activity.SetActive(true);
    }
    public void TutorialTab()
    {
        TutorialWindow.SetActive(true);
    }
    public void ExitWindow()
    {
        Window.SetActive(false);

    }

    public void BackToPatterns()
    {
        SceneManager.LoadScene("Layout Activities Patterns");
    }
}
