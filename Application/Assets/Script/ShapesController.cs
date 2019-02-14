using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShapesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void Triangle()
    {
        SceneManager.LoadScene("Shapes Triangle");
    }
    public void Circle()
    {
        SceneManager.LoadScene("Shapes Activities");
    }
    public void Oblong()
    {
        SceneManager.LoadScene("Shapes Oblong");
    }
    public void Rectangle()
    {
        SceneManager.LoadScene("Shapes Rectangle");
    }
      public void Square()
    {
        SceneManager.LoadScene("Shapes Square");
    }
    public void GoReturn()
    {
        SceneManager.LoadScene("Play Menu");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
