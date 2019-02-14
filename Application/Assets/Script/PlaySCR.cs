using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySCR : MonoBehaviour {

    public void ReturnBTN()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void GoColor()
    {
        SceneManager.LoadScene("Layout Activities Colors");
    }
    public void GoShapes()
    {
        SceneManager.LoadScene("Layout Activities Shapes");
    }
    public void GoPatterns()
    {
        SceneManager.LoadScene("Layout Activities Patterns");
    }
    public void GoSizes()
    {
        SceneManager.LoadScene("Layout Activities Sizes");
    }
    public void GoSets()
    {
        SceneManager.LoadScene("Layout Activities Sets");
    }
    public void GoMiniGames()
    {
        SceneManager.LoadScene("Layout Mini Games");
    }
    public void GoJingles()
    {
        SceneManager.LoadScene("Jingles Layout");
    }

}
