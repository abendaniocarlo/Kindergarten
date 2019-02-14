using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SizesController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public void GoBIG()
    {
        SceneManager.LoadScene("Sizes Big");
    }
    public void GoSMALL()
    {
        SceneManager.LoadScene("Sizes Small");
    }
    public void GoReturn()
    {
        SceneManager.LoadScene("Play Menu");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
