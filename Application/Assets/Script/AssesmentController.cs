using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssesmentController : MonoBehaviour {
    string result;
    int ColorsScore = 0;
    public GameObject PreTestBar;
    public GameObject GraphBox;
    int[] PositionY = { -137, -67, -5, 65, 134 };
    int KeyLog = 0;
    int ScoreBar;
	// Use this for initialization
	void Start () {
        PreTest();
        myColor();
        Time.timeScale = 1f;
    }
    void PreTest()
    {
        int y = 0, x = 0, b = 0;
        int current = -480;

        if (KeyLog == 0)
        {
            ScoreBar = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Colors") / 2;
        }

       
        

            for (int a = 0; a < ScoreBar; a++)
            {
                var createImage = Instantiate(PreTestBar, new Vector3(current, PositionY[y], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox.transform, false);
                y++;
            }
            b++;
            y = 0;
      
       
      
    }
    void myColor()
    {
        int x=0,b=0,y=0;
        int current = -480;
        
        while(PlayerPrefs.HasKey(PlayerPrefs.GetString(result) +" MGColor"+x))
        {
             current = current + 71;
            for (int a = 0; a < PlayerPrefs.GetInt(PlayerPrefs.GetString(result)+ " MGColor"+x)/2; a++)
            {
                var createImage = Instantiate(PreTestBar, new Vector3(current, PositionY[y], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox.transform, false);
                y++;
            }
            b++;
            y = 0;
            x++;
        }
        //while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSet" + xx))
        //{
        //    //   Debug.Log("s");
        //    // PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MGSet" + xx);
        //    //PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MTDate" + xx);
        //    Debug.Log("x = " + xx + " - " + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + xx));
        //    xx++;
        //}




    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
