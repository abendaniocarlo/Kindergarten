using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetsController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public void GoSet1VSet2()
    {
        SceneManager.LoadScene("Sets Activity");
    }
    public void GoSetsMatch()
    {
        SceneManager.LoadScene("Sets Compare");
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
