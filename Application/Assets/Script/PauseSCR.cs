using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSCR : MonoBehaviour {

    public GameObject PausedPanel;
    public GameObject PauseBTNPanel;
    string SceneName;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1f;
        SceneName = SceneManager.GetActiveScene().name;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resume()
    {
        Time.timeScale = 1f;
        PausedPanel.SetActive(false);
        PauseBTNPanel.SetActive(true);
    }
    public void Pause()
    {
        //if(SceneName == "ColorsCatch")
        //    Time.timeScale = 0f;
        //else if (SceneName == "ShapesCatch")
        //    Time.timeScale = 0f;

        Time.timeScale = 0f;
        PausedPanel.SetActive(true);
        PauseBTNPanel.SetActive(false);
    }
}
