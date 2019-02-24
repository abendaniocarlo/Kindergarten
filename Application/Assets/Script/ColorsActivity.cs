﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ColorsActivity : MonoBehaviour {
    public GameObject[] choice;
    public GameObject[] questions;
    public GameObject TutorialPanel;
    public GameObject Directions;
    public GameObject ScoreBoard;
    public GameObject[] Star;
    public GameObject wrong1;
    public GameObject wrong2;
    public GameObject wrong3;
    public GameObject correct1;
    public GameObject correct2;
    public GameObject correct3;
    
    int[] wrong = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
    int[] variable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
  int[] AnsVar = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
    int[] positionX = { -300, -118, 132, 311 };
    int[] positionY = { 236, 75, -75 };
    public static int keyLog = 0;
    public static int directionOnce;
    int answer;
    int[] Final;
    string color;
   public static int Total=0;
    int Key;
    int PreQuest;
    string MyAnswer;
    int Def;
    int[] PreValue = {31,50};
    int[] PreChoice;
    string result;
    string MyColor;
    string ColorIndex;
    int count;
    public static int GrandTotal;
	// Use this for initialization
	void Start () {
        int b = 0;
        int c = 0;

        if (directionOnce == 0 ) {
            StartCoroutine(DirectionShow());
            directionOnce++;
        }
        Time.timeScale = 1f;
        wrong1.SetActive(false);
        wrong2.SetActive(false);
        wrong3.SetActive(false);
        correct1.SetActive(false);
        correct2.SetActive(false);
        correct3.SetActive(false);

        variable = randomPos(variable);
        wrong = randomPos(wrong);
        positionX = randomPos(positionX);
        positionY = randomPos(positionY);
        List<int> FinChoice = new List<int>();
        List<int> ConvertChoice;
        Key = 0;
     
        {
         //   questions[0].SetActive(true);
            answer = 1;
            AnsVar = randomPos(AnsVar);
            MyAnswer = SceneManager.GetActiveScene().name;
            if (MyAnswer == "Colors Activities")
            {
                color = "TapClr Blue";
                questions[0].SetActive(true);
                answer = 1;
               PlayerPrefs.SetString("ColorIndex1", MyAnswer);
               MyColor = PlayerPrefs.GetString("ColorIndex1", "No Color");
              
                
                Def = 2;
            }
            else if (MyAnswer == "Colors Brown")
            {
                color = "TapClr Brown";
                questions[1].SetActive(true);
                answer = 2;
                PlayerPrefs.SetString("ColorIndex1", MyAnswer);
                Def = 5;
            }
            else if (MyAnswer == "Colors Green")
            {
                color = "TapClr Green";
                questions[2].SetActive(true);
                answer = 3;
                PlayerPrefs.SetString("ColorIndex1", MyAnswer);
                Def = 8;
            }
            else if (MyAnswer == "Colors Orange")
            {
                color = "TapClr Orange";
                questions[3].SetActive(true);
                answer = 4;
                PlayerPrefs.SetString("ColorIndex1", MyAnswer);
                Def = 11;
            }
            else if (MyAnswer == "Colors Pink")
            {
                color = "TapClr Pink";
                questions[4].SetActive(true);
                answer = 5;
                PlayerPrefs.SetString("ColorIndex1", MyAnswer);
                Def = 14;
            }
            else if (MyAnswer == "Colors Red")
            {
                color = "TapClr Red";
                questions[5].SetActive(true);
                answer = 6;
                PlayerPrefs.SetString("ColorIndex1", MyAnswer);
                Def = 17;
            }
            else if (MyAnswer == "Colors Yellow")
            {
                color = "TapClr Yellow";
                questions[6].SetActive(true);
                answer = 7;
                PlayerPrefs.SetString("ColorIndex1", MyAnswer);
                Def = 20;
            }
            else if (MyAnswer == "Colors Purple")
            {
                color = "TapClr Purple";
                questions[7].SetActive(true);
                answer = 8;
                PlayerPrefs.SetString("ColorIndex1", MyAnswer);
                Def = 23;
            }
         
            /*  
              if (keyLog == 0)
               {
                   AnsVar = randomPos(AnsVar);
                   answer = 0;

               }
               //Generate questions 
               if (AnsVar[keyLog] == 2)
               {
                   questions[0].SetActive(true);
                   answer = 1;
               }
               else if (AnsVar[keyLog] == 5)
               {
                   questions[1].SetActive(true);
                   answer = 2;
               }
               else if (AnsVar[keyLog] == 8)
               {
                   questions[2].SetActive(true);
                   answer = 3;
               }
               else if (AnsVar[keyLog] == 11)
               {
                   questions[3].SetActive(true);
                   answer = 4;
               }
               else if (AnsVar[keyLog] == 14)
               {
                   questions[4].SetActive(true);
                   answer = 5;
               }
               else if (AnsVar[keyLog] == 17)
               {
                   questions[5].SetActive(true);
                   answer = 6;
               }
               else if (AnsVar[keyLog] == 20)
               {
                   questions[6].SetActive(true);
                   answer = 7;
               }
               //end*/

            ConvertChoice = new List<int>(variable);
          //change d = "Def" to Ansvar[KeyLog] add all the asset from 0 to 30
            for (int d = 0; d != 3; d++)
            {
                FinChoice.Add(AnsVar[d]);
               // ConvertChoice.Remove(d);
            }

          PreValue = ConvertChoice.ToArray();
           // PreValue = randomPos(PreValue);
            for (int d = 0; d != 9; d++)
            {
                FinChoice.Add(wrong[d]);
            }

            Final = FinChoice.ToArray();
            Final = randomPos(Final);
            
            /*     if (keyLog != 0)
              {


       //           questions[PreQuest - 1].SetActive(false);
               for (int y = 0; y != 12; y++)
                  {
                      for (int x = 0; x != 12; x++)
                      {
                          if (Final[y] != PreChoice[x])
                          {
                              choice[PreChoice[x]].SetActive(false);
                          }
                      }

                  }

              }*/
            for (int a = 0; a != 12; a++)
            {

                Vector3 Temp = choice[Final[a]].transform.localPosition;
                Temp = new Vector3(positionX[b], positionY[c], 0);
                choice[Final[a]].SetActive(true);
                choice[Final[a]].transform.localPosition = Temp;
                b++;
                if (b == 4)
                {
                    c++;
                    b = 0;
                }

            }
            PreQuest = answer;
            PreChoice = Final;
        }

	}

    IEnumerator DirectionShow()
    {
        Directions.SetActive(true);
        yield return new WaitForSeconds(9f);
        Directions.SetActive(false);
    }

    public void blue()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 1)
        {
            //right answer
            Total++;
            if (Total == 3)
            {
                GrandTotal++;
                Total = 0;

            }
            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);

        }
        else
        {
            Debug.Log("Wrong");

            if (Key == 1) // checkbar if wrong
                wrong1.SetActive(true);
            else if (Key == 2)
                wrong2.SetActive(true);
            else if (Key == 3)
                wrong3.SetActive(true);
        }
        
        if (Key == 3)
        {
            keyLog++;
            StartCoroutine("RestartGame");
        }
        
    }
    public void brown()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 2)
        {
            //right answer
            Total++;
            if (Total == 3)
            {
                GrandTotal++;
                Total = 0;

            }

            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong");

            if (Key == 1) // checkbar if wrong
                wrong1.SetActive(true);
            else if (Key == 2)
                wrong2.SetActive(true);
            else if (Key == 3)
                wrong3.SetActive(true);
        }
        
        if (Key == 3)
        {
            keyLog++;
            StartCoroutine("RestartGame");
        }
    }

    public void green()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 3)
        {
            //right answer
            Total++;
            if (Total == 3)
            {
                GrandTotal++;
                Total = 0;

            }

            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong");

            if (Key == 1) // checkbar if wrong
                wrong1.SetActive(true);
            else if (Key == 2)
                wrong2.SetActive(true);
            else if (Key == 3)
                wrong3.SetActive(true);
        }
        
        if (Key == 3)
        {
            keyLog++;
            StartCoroutine("RestartGame");
        }
    }
    public void orange()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 4)
        {
            //right answer
            Total++;
            if (Total == 3)
            {
                GrandTotal++;
                Total = 0;

            }

            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
          

            if (Key == 1) // checkbar if wrong
                wrong1.SetActive(true);
            else if (Key == 2)
                wrong2.SetActive(true);
            else if (Key == 3)
                wrong3.SetActive(true);
        }
        
        if (Key == 3)
        {
            keyLog++;
            StartCoroutine("RestartGame");
        }
    }
    public void pink()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 5)
        {
            //right answer
            Total++;
            if (Total == 3)
            {
                GrandTotal++;
                Total = 0;

            }

            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
         

            if (Key == 1) // checkbar if wrong
                wrong1.SetActive(true);
            else if (Key == 2)
                wrong2.SetActive(true);
            else if (Key == 3)
                wrong3.SetActive(true);
        }
        
        if (Key == 3)
        {
            keyLog++;
            StartCoroutine("RestartGame");
        }
       
    }
    public void red()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 6)
        {
            //right answer
            Total++;
            if (Total == 3)
            {
                GrandTotal++;
                Total = 0;

            }

            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
    

            if (Key == 1) // checkbar if wrong
                wrong1.SetActive(true);
            else if (Key == 2)
                wrong2.SetActive(true);
            else if (Key == 3)
                wrong3.SetActive(true);
        }
        
        if (Key == 3)
        {
            keyLog++;
            StartCoroutine("RestartGame");
        }
    }
    public void yellow()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 7)
        {
            //right answer
            Total++;
            if (Total == 3)
            {
                GrandTotal++;
                Total = 0;

            }

            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
            if (Key == 1) // checkbar if wrong
                wrong1.SetActive(true);
            else if (Key == 2)
                wrong2.SetActive(true);
            else if (Key == 3)
                wrong3.SetActive(true);
        }
        
        if (Key == 3)
        {
            keyLog++;
            StartCoroutine("RestartGame");
        }
    }
    public void purple()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 8)
        {
            //right answer
            Total++;
            if (Total == 3)
            {
                GrandTotal++;
                Total = 0;

            }
            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
            if (Key == 1) // checkbar if wrong
                wrong1.SetActive(true);
            else if (Key == 2)
                wrong2.SetActive(true);
            else if (Key == 3)
                wrong3.SetActive(true);
        }

        if (Key == 3)
        {
            keyLog++;
            StartCoroutine("RestartGame");
        }
    }
	// Update is called once per frame
	void Update () {
		
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
        Time.timeScale = 1f;
        directionOnce = 0;
        SceneManager.LoadScene("Layout Activities Colors");
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
        Total = 0;
        if (keyLog != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
           PlayerPrefs.SetInt(PlayerPrefs.GetString(result)+" "+color,GrandTotal);
            StartCoroutine("ScoreWindow");
        }
        
    }
    IEnumerator ScoreWindow()
    {
        int temp=0;
        yield return new WaitForSeconds(1);
        ScoreBoard.SetActive(true);
        
    
        keyLog = 0;    
        while (temp != GrandTotal)
        {
            Star[temp].SetActive(true);
           temp++;
        }
        Total = 0;
        GrandTotal = 0;
    }
 /*   public void CloseDirection()
    {
        Directions.SetActive(false);
    }*/
    public void Tutorial()
    {
        Time.timeScale = 1f;
        TutorialPanel.SetActive(true);
    }
    public void Close()
    {

        TutorialPanel.SetActive(false);
    }
    public void ColorTutorial()
    {
        Time.timeScale = 1f;
        GrandTotal = 0;
        SceneManager.LoadScene("ColorIT");
    }
    public void TapColorTutorial()
    {
        Time.timeScale = 1f;
        GrandTotal = 0;
        SceneManager.LoadScene("TapTheColors");
    }
    public void HomeBtn()
    {
        Time.timeScale = 1f;
        GrandTotal = 0;
        SceneManager.LoadScene("Layout Activities Colors");
    }

}