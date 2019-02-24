﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SizeShuffle : MonoBehaviour {
    public GameObject[] Small;
    public GameObject[] Medium;
    public GameObject[] Large;
    public GameObject[] GQuest;
    public GameObject Board;
    public GameObject Panel;
    public GameObject Star;
    string result;
    int[] YPosition = { 26, -64 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    public static int KeyLog=0;
    int[] PositionX = { -265, -16, 266 };
    int[] Cindex = { 0, 1 , 2 };
    int[] Cindex1 = { 2,1,0 };
    int[] PIndex = new int[3];
    int Value = 0;
    public static int Score;
    int[] Question = { 0 ,1 };
    bool PVal = false;
    public static int[] AIndex = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };
	// Use this for initialization

	void Start () {
        if (KeyLog == 0)
        {
            AIndex = randomPos(AIndex);
        }
     Question = randomPos(Question);
        if (Question[0] == 0)
        {
            GQuest[0].SetActive(true);
        }
        else
        {
            GQuest[1].SetActive(true);
        }
        Shuffle();
     
	}
    void Shuffle()
    {
       int x=0;
        Cindex = randomPos(Cindex);
  
   
        Vector3 Temp1 = Small[AIndex[KeyLog]].transform.position;
        Temp1 = new Vector3(PositionX[Cindex[0]], -116, 0);
        Small[AIndex[KeyLog]].transform.localPosition = Temp1;


            Vector3 Temp2 = Medium[AIndex[KeyLog]].transform.position;
            Temp2 = new Vector3(PositionX[Cindex[1]], -76, 0);
            Medium[AIndex[KeyLog]].transform.localPosition = Temp2;


            Vector3 Temp3 = Large[AIndex[KeyLog]].transform.position;
            Temp3 = new Vector3(PositionX[Cindex[2]], -46, 0);
            Large[AIndex[KeyLog]].transform.localPosition = Temp3;
            PIndex = Cindex;
            Value = 0;
     
    }
    public void ShuffleBtn()
    {
        
        Shuffle();
    }
    public void GoBtn()
    {
        KeyLog++;
        if (Question[0] == 0)
        {
            for (int a = 0; a != 3; a++)
            {
                if (Cindex[a] == a)
                {

                    Value++;

                }
            }
        }
        else
       {
        //    foreach (int temp in Cindex)
        //    {
        //        Debug.Log(temp);
        //    }
           int xz = 2;
            for (int b = 0; b <= 2; b++)
            {
             //   Debug.Log(a);
               
                if (Cindex[b] == xz)
                {
                    Value++;
                }
                xz--;

              //  Debug.Log(a);
            //  Debug.Log(Cindex[b]);
            }
        }
            
            if (Value == 3)
            {
                Score++;
                Debug.Log(Score);
            }
            else
            {
                Debug.Log("false");
            }
            Restart();
  
       
       


    }
    void Restart()
    {
        Value = 0;
        if (KeyLog != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
      
            StartCoroutine("ScoreEval");
           

        }
    }
    public int[] randomPos(int[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            int tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
        return array;
    }
    IEnumerator ScoreEval()
    {
        yield return new WaitForSeconds(0);
        // Debug.Log(Score);
        Board.SetActive(true);
        KeyLog = 0;
        SaveScore();
 
        int b = 0, c = 0;
        for (int a = 0; a != Score; a++)
        {
            yield return new WaitForSeconds(0.5f);
            var createImage = Instantiate(Star, new Vector3(XPosition[b], YPosition[c], 0), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Panel.transform, false);
            b++;
            if (a == 4)
            {
                b = 0;
                c++;
            }
        }

        Score = 0;

    }
    void SaveScore()
    {
        //  =myDate = "02/24";
        int xx = 0, zz = 0, d = 0;

         string current = "02/24";
       // string current = System.DateTime.Now.ToString("MM/dd");
        string myDate;
        int MGScore, test;
        int FGScore;
        bool MyBool = true;

        if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MZDate0"))
        {
            // Date EXIST!

            while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MZDate" + xx))
            {
                xx++;
                // get the last stored date
                if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MZDate" + xx))
                {

                    //check if its equal to current date

                    if (PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MZDate" + (xx - 1)) == current)
                    {
                        //Same date of exam  
                        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSize" + zz))
                        {
                            // Get he last stored score for same date
                            zz++;

                            if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSize" + zz))
                            {
                                MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + (zz - 1));
                                //check which is higher
                                if (MGScore >= Score)
                                {
                                    FGScore = MGScore;
                                }
                                else
                                {
                                    FGScore = Score;
                                }
                                //set the score which is higher on two;
                                PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGSize" + (zz - 1), FGScore);

                            }
                        }

                    }
                    else
                    {
                        // not equal to current date

                        PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MZDate" + xx, current);
                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGSize" + xx, Score);
                        break;
                    }
                }


            }
        }
        else
        {
            // No date & score yet
            Debug.Log("hey jude");
            PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MZDate0", current);
            PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGSize0", Score);
        }
        xx = 0;
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MZDate" + xx))
        {

            // PlayerPrefs.DeleteKey(PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MGSize" + xx));
            //   PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MZDate" + xx);
            Debug.Log("S = " + xx + "---" + PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MZDate" + xx));
            Debug.Log("x = " + xx + "---" + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + xx));
            xx++;
        }

    }//END
    public void Done()
    {
        Score = 0;
        KeyLog = 0;

        SceneManager.LoadScene("Layout Games Sizes");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
