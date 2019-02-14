using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamesController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public void GoColorGames()
    {
        SceneManager.LoadScene("Layout Games Colors");
    }
    public void GoPatternsGames()
    {
        SceneManager.LoadScene("Layout Games Patterns");
    }
    public void GoSetsGames()
    {
        SceneManager.LoadScene("Layout Games Sets");
    }
    public void GoSizesGames()
    {
        SceneManager.LoadScene("Layout Games Sizes");
    }
    public void GoShapesGames()
    {
        SceneManager.LoadScene("Layout Games Shapes");
    }
    public void GoReturn()
    {
        SceneManager.LoadScene("Play Menu");
    }


    public void GoBackMiniGames()
    {
        SceneManager.LoadScene("Layout Mini Games");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
