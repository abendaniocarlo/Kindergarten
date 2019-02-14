using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatternsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void GoOne()
    {
        SceneManager.LoadScene("DragTry");
    }
    public void GoTwo()
    {
        SceneManager.LoadScene("PatternTwo");
    }
    public void GoPattern()
    {
        SceneManager.LoadScene("PatternTwo");
    }
    public void GoReturn()
    {
        SceneManager.LoadScene("Play Menu");
    }


    // Update is called once per frame
    void Update () {
		
	}
}
