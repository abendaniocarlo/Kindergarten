using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatisticsScript : MonoBehaviour {
    int ColorsScore = 0;
    int ShapesScore = 0;
    int SizesScore = 0;
    int SetsScore = 0;
    int PatternsScore = 0;
    public GameObject[] Stars;
    public GameObject[] ColorsStars;
    public GameObject[] ShapesStars;
    public GameObject[] SizesStars;
    public GameObject[] SetsStars;
    public GameObject[] PatternsStars;
    int number1 = 0;
    int number2 = 0;
    int number3 = 0;
    int number4 = 0;
    int number = 0;
    string result = "";
    // Use this for initialization
    void Start()
    {
        ColorsScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Colors");
        ShapesScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Shapes");
        SizesScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Sizes");
        SetsScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Sets");
        PatternsScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Patterns");
        Debug.Log(ColorsScore);
        Debug.Log(ShapesScore);
        Debug.Log(SizesScore);
        Debug.Log(SetsScore);
        Debug.Log(PatternsScore);
        while (number != PatternsScore)
        {
            PatternsStars[number].SetActive(true);
            number++;
        }

        while (number1 != ColorsScore)
        {
            ColorsStars[number1].SetActive(true);
            number1++;
        }

        while (number2 != ShapesScore)
        {
            ShapesStars[number2].SetActive(true);
            number2++;
        }

        while (number3 != SizesScore)
        {
            SizesStars[number3].SetActive(true);
            number3++;
        }

      while (number4 != SetsScore)
        {
            SetsStars[number4].SetActive(true);
            number4++;
        }
    }
    public void BackBtn()
    {
        SceneManager.LoadScene("Main Menu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
