using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShapesController : MonoBehaviour {
    string result;
    public GameObject[] LockedIcon;
	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Circle", 0) != 0)
        {
            Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Circle"));
            LockedIcon[0].SetActive(false);
        }
        //if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Oblong", 0) != 0)
        //{
        //    LockedIcon[1].SetActive(true);
        //}
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Square", 0) != 0)
        {
            LockedIcon[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Triangle", 0) != 0)
        {
            LockedIcon[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Rectangle", 0) != 0)
        {
            LockedIcon[3].SetActive(false);
        }

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
