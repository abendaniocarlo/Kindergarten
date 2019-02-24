using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialScript : MonoBehaviour {
    public GameObject MyVideos;
    public GameObject Window;
    public GameObject Activity;
    public GameObject TutorialWindow;
    public GameObject PausedPane;
    //  public GameObject PauseCanvas;
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("ColorIT");
    }
    public void GoTrace()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TraceMe");

    }
    public void GoWatch()
    {
        Window.SetActive(false);
        MyVideos.SetActive(true);
        Activity.SetActive(false);
        PausedPane.SetActive(false);
    }
    public void GoWatch2()
    {
        Window.SetActive(false);
        MyVideos.SetActive(true);
        TutorialWindow.SetActive(false);
        PausedPane.SetActive(false);
    }
    public void closeVidPlayer()
    {
        PausedPane.SetActive(true);
    }
    public void VideoListClose()
    {
        MyVideos.SetActive(false);
        Activity.SetActive(true);
    }
    public void TutorialTab()
    {
        Time.timeScale = 1f;
        TutorialWindow.SetActive(true);
    }
    public void ExitTutorialWindow() // this for scene na walang window tutorial
    {
        TutorialWindow.SetActive(false);
    }
    public void ExitWindow()
    {
        Window.SetActive(false);
    }

    public void GoPatternOneTutorials()
    {
        SceneManager.LoadScene("PatternTutorial1");
    }
    public void GoPatternTwoTutorials()
    {
        SceneManager.LoadScene("PatternTutorial2");
    }
    public void ToPatternsLayout()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Layout Activities Patterns");
    }

    public void GoSetSort()
    {
        SceneManager.LoadScene("SetSort");
    }
}
