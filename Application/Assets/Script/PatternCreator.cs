﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PatternCreator : MonoBehaviour {
    public GameObject Panel;
    public GameObject[] Objects;
    public GameObject[] Objects1;
    public GameObject Board;
    public GameObject ScoreBoard;
    public GameObject Star;
    public GameObject[] myButton;
    public AudioSource SoundFx;
    public AudioClip willSpeak;
    public static int tune = 0;
    public Button[] Buttons;
    int[] YPosition = { 26, -64 };
    int[] Quest = { 0, 1 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    int[] Pattern = new int[12];
    int[] Pattern1 = new int[24];
    int[] PositionX = { -400, -250, -106, 43, 189, 335 };
    int[] PositionY = { 90, -73 };
    int[] PositionXX = { -421, -270,-126, 22, 168, 315 };
    int[] PositionYY = { 157, 32,-100, -229 };
    int[] PTwo = { 0, 2 };
    string result;
    public static int KeyLog;
    int answer;
    public static int Score;
    int[] Index = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    // Use this for initialization
    void Start()
    {
        if (tune ==0)
            SoundFx.PlayOneShot(willSpeak);

        Index = randomPos(Index);
        PositionY = randomPos(PositionY);
        
        Quest = randomPos(Quest);
        PTwo = randomPos(PTwo);
        if (PTwo[0] == 0)
        {
            answer = 0;

        }
        else
        {
            answer = 1;
        }
      //  Debug.Log(answer);
        if (Quest[0] == 0)
        {
            Creator();
        }
        else
        {
            Creator1();

        }

        tune++;
     //   Debug.Log(PTwo[0]);
     //   Debug.Log(PTwo[1]);

    }
    void Creator()
    {
        int a = 0, b = 0;
        while (a <= 11)
        {
            if (b == 2)
            {
                b = 0;


            }
            Pattern[a] = Index[b];

            b++;
            a++;
        }
        StartCoroutine("SpawnImages");
        StartCoroutine("SpawnImages1");
    }
    void Creator1()
    {
        int a = 0, b = 0,c=0,d=0,e=0;
        while (a <= 23)
        {
                while (d != 3)
                {
                    Pattern1[a] = Index[b];
                    c++;
                    d++;
                }
                e++;
                if (e==2)
                {
                    if (b == 0)
                    {
                        b = 1;
                    }
                    else if (b == 1)
                    {
                        b = 0;
                    }
                    e = 0;
                }
              
                d = 0;
                c = 0;
                //00 11 00 11 00 11    0011
                //01 23 45 67 89 1011
               // Debug.Log(Pattern1[a]);
              
                a++;
        }
      
       StartCoroutine("SpawnImages2");
        StartCoroutine("SpawnImages3");
    }
    IEnumerator SpawnImages()
    {
        yield return new WaitForSeconds(0);
        int c = 0, d = 0;

        for (int x = 0; x <= 5; x++)
        {
            yield return new WaitForSeconds(.1f);
            var createImage = Instantiate(Objects[Pattern[x]], new Vector3(PositionX[c], PositionY[d], 5), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Panel.transform, false);
            c++;


        }
    }



    IEnumerator SpawnImages1()
    {
        yield return new WaitForSeconds(0);
        int c = 0, d = 1;
        


        Vector3 Temp3 = myButton[0].transform.position;
        Temp3 = new Vector3(448, -79, 0);
        myButton[0].transform.localPosition = Temp3;
       
        for (int x = 3; x <= 8; x++)
        {
            yield return new WaitForSeconds(.1f);
            var createImage = Instantiate(Objects[x], new Vector3(PositionX[c], PositionY[d], 5), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Panel.transform, false);
            c++;
        }
    }
    IEnumerator SpawnImages2()
    {
        yield return new WaitForSeconds(0);
        int c = 0, d = 0,e=0;

        for (int x = 0; x <= 11; x++)
        {
            yield return new WaitForSeconds(.1f);
            var createImage = Instantiate(Objects1[Pattern1[e]], new Vector3(PositionXX[c], PositionYY[PTwo[0]], 5), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Panel.transform, false);
            c++;
            if (x == 5)
            {
                c = 0;
                if (PTwo[0] == 0)
                {
                    PTwo[0] = 1;
                   
                }
                else
                {
                    PTwo[0] = 3;
                }
                d = 1;
            }
            e++;
           


        }
    }
    IEnumerator SpawnImages3()
    {
        yield return new WaitForSeconds(0);
        int c = 0, d = 2, e=0;
      
      


        Vector3 Temp3 = myButton[0].transform.position;
        Temp3 = new Vector3(448, -159, 0);
        myButton[0].transform.localPosition = Temp3;
        for (int x = 0; x <= 11; x++)
        {
            yield return new WaitForSeconds(.1f);
            var createImage = Instantiate(Objects1[x], new Vector3(PositionXX[c], PositionYY[PTwo[1]], 5), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Panel.transform, false);
            c++;
            if (x == 5)
            {
                c = 0;

                if (PTwo[1] == 0)
                {
                    PTwo[1] = 1;
                }
                else
                {
                    PTwo[1] = 3;
                }
            }
            e++;
        }
    }
    public void ButtonOne()
    {
        KeyLog++;
        Buttons[0].interactable = false;
        Buttons[1].interactable = false;
        if (Quest[0] == 0)
        {
            if (PositionY[0] == 90)
            {
                Debug.Log("right");
                Score++;

            }
            else
            {
                Debug.Log("false");
            }
        }
        else
        {
            if (answer == 0)
            {
                Score++;
                Debug.Log("Right");
             //   Debug.Log(PTwo[0]);
            }
            else
            {
                Debug.Log("false");
            }
        }
        if (KeyLog != 10)
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            StartCoroutine("ScoreEval");
            KeyLog = 0; 
        }
    }
    public void ButtonTwo()
    {
        KeyLog++;
        Buttons[0].interactable = false;
        Buttons[1].interactable = false;
        if (Quest[0] == 0)
        {
            if (PositionY[1] == 90)
            {
                Debug.Log("right");
                Score++;

            }
            else
            {
                Debug.Log("false");
            }
        }
        else
        {
            
            if (answer == 1)
            {
                Score++;
                Debug.Log("Right");
            }
            else
            {
                Debug.Log("false");
                Debug.Log(PTwo[1]);
            }
        }
       
        if (KeyLog != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            StartCoroutine("ScoreEval");
            KeyLog = 0; 
        }
    }
    IEnumerator ScoreEval()
    {
        yield return new WaitForSeconds(0);
        // Debug.Log(Score);
        Board.SetActive(true);
       // Score = 2;
        SaveScore();
        
        int b = 0, c = 0;
        for (int a = 0; a < Score; a++)
        {
            yield return new WaitForSeconds(0.5f);
            var createImage = Instantiate(Star, new Vector3(XPosition[b], YPosition[c], 0), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(ScoreBoard.transform, false);
            b++;
            if (a == 4)
            {
                b = 0;
                c++;
            }
        }


    }
    void SaveScore()
    {
        int xx = 0, zz = 0;
        string current = System.DateTime.Now.ToString("MM/dd/yy");
        string myDate;
        int MGScore, test;
        float FGScore;
        bool MyBool = true;
        if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MPDate"))
        {
            //meron

            myDate = PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MPDate");
            //    Debug.Log(Score);
            MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern");
           // myDate = "02/22/19";  //test data
            if (myDate == current)
            {
                // equal sa current date;

                while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGPattern" + xx))
                {


                    xx++;
                    if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGPattern" + xx) == false)
                    {
                        MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + (xx - 1));

                        if (MGScore >= Score)
                        {
                            FGScore = MGScore;
                            //         Debug.Log("true");

                        }
                        else
                        {
                            //  Debug.Log("false");
                            FGScore = Score;
                        }

                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGPattern" + (xx - 1), Mathf.RoundToInt(FGScore));
                    }

                }

            }
            else
            {

                xx = 0;
                while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGPattern" + xx) || MyBool == false)
                {
                    PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MPDate", current);
                    MGScore = MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + xx);
                    xx++;
                    if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGPattern" + xx) == false)
                    {
                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGPattern" + xx, Score);

                        MyBool = false;
                        break;
                    }
                }
            }

        }
        else
        {

            PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MPDate", current);
            PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGPattern0", Score);
        }

        xx = 0;
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGPattern" + xx))
        {
            //   Debug.Log("s");
            // PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MGPattern" + xx);
            //PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MPDate" + xx);
            Debug.Log("x = " + xx + " - " + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + xx));
            xx++;
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

    public void Done()
    {
        tune = 0;
        KeyLog = 0; 
        SceneManager.LoadScene("Layout Games Patterns");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
