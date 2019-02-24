using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamesController : MonoBehaviour
{
    string result;
    public GameObject[] LockedIcons; //color
    public GameObject[] LockedIcons1;// shapes
    public GameObject[] LockedIcons2; // pattern
    public GameObject[] LockedIcons3; // Sizes
    public GameObject[] LockedIcons4; // Sets
    public GameObject[] LockedPick;
    public GameObject[] Buttons;
    public GameObject[] PBar;
    // Use this for initialization
    void Start()
    {
      //  Screen.orientation = ScreenOrientation.LandscapeLeft;

        //Screen.autorotateToLandscapeLeft = true;
        //Screen.autorotateToLandscapeRight = true;
        //Screen.autorotateToPortrait = false;
        //Screen.autorotateToPortraitUpsideDown = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        if (SceneManager.GetActiveScene().name == "Layout Mini Games")
        {
            Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Oblong"));
       
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Blue", 0) != 0)
                {
                    LockedIcons[0].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Red", 0) != 0)
                {
                    LockedIcons[1].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Orange", 0) != 0)
                {
                    LockedIcons[2].SetActive(true);


                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Yellow", 0) != 0)
                {
                    LockedIcons[3].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Green", 0) != 0)
                {
                    LockedIcons[4].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Blue", 0) != 0)
                {
                    LockedIcons[5].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Purple", 0) != 0)
                {
                    LockedIcons[6].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "TapClr Brown", 0) != 0)
                {
                    foreach(GameObject temp in LockedIcons){
                        temp.SetActive(false);
                    }
                    LockedPick[0].SetActive(false);
                    Buttons[0].SetActive(true);
                    PBar[0].SetActive(false);
                }

            //shapes bar


                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Circle", 0) != 0)
                {
                   // Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Circle"));
                    LockedIcons1[0].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Triangle", 0) != 0)
                {
                    LockedIcons1[1].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Square", 0) != 0)
                {
                    LockedIcons1[2].SetActive(true);
                }
             
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Rectangle", 0) != 0)
                {
                    LockedIcons1[3].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "Shp Oblong", 0) != 0)
                {
                   
                    foreach (GameObject temp in LockedIcons1)
                    {
                        temp.SetActive(false);
                    }
                    LockedPick[1].SetActive(false);
                    Buttons[1].SetActive(true);
                    PBar[1].SetActive(false);
                   
                }
            //sets
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " SetOne", 0) != 0)
                {

                    LockedIcons4[0].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " SetTwo", 0) != 0)
                {
                   
              
                    foreach (GameObject temp in LockedIcons4)
                    {
                        temp.SetActive(false);
                    }
                    LockedPick[4].SetActive(false);
                    Buttons[4].SetActive(true);
                    PBar[4].SetActive(false);
                }
            //pattern
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " PatternOne", 0) != 0)
                {
                    LockedIcons2[0].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " PatternTwo", 0) != 0)
                {
                    LockedPick[2].SetActive(false);
                    LockedIcons2[0].SetActive(false);
                    Buttons[2].SetActive(true);
                    PBar[2].SetActive(false);
                }
            //size
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "SizeBig", 0) != 0)
                {
                    LockedIcons3[0].SetActive(true);
                }
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " " + "SizeSmall", 0) != 0)
                {
                    LockedPick[3].SetActive(false);
                    LockedIcons3[0].SetActive(false);
                    Buttons[3].SetActive(true);
                    PBar[3].SetActive(false);
                }
        }
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
    public void GoColorTap()
    {
        SceneManager.LoadScene("ColorsTapGame");
    }

    // game shapes
    public void GoShapesCatch()
    {
        SceneManager.LoadScene("ShapesCatch");
    }
    public void GoShapeTap()
    {
        SceneManager.LoadScene("ShapesTapGame");
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
