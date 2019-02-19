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

    // papunta sa layout ng games
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

    // pabalik sa layout ng minigames
    public void GoBackMiniGames()
    {
        SceneManager.LoadScene("Layout Mini Games");
    }

    // game sets
    public void GoFillTheBasket()
    {
        SceneManager.LoadScene("SetGame");
    }

    // game sizes
    public void GoSizesShuffle()
    {
        SceneManager.LoadScene("SizesGame");
    }

    // game colors
    public void GoColorCatch()
    {
        SceneManager.LoadScene("ColorsCatch");
    }

    // game shapes
    public void GoShapesCatch()
    {
        SceneManager.LoadScene("ShapesCatch");
    }

    // game patterns
    public void GoPatterns()
    {
        SceneManager.LoadScene("PatternGame");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
