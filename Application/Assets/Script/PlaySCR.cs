using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySCR : MonoBehaviour {

    public void ReturnBTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
        SceneManager.LoadScene("ColorsCatch");
    }
    public void GoSizes()
    {
        SceneManager.LoadScene("ShapesCatch");
    }

}
