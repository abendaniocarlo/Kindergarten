﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SetDestroy : MonoBehaviour {
    int number;
    int[] objCount;
    int[] QIndex;
    int x=0,z=0;
    int[] Fruit = new int[6];
    int[] TFruit = new int[6];
    bool[] BFruit ;
    int[] Target = new int[6];
    public GameObject Board;
    public GameObject Panel;
    public GameObject Star;
    public Button myButton;
    int[] value;
    public static bool Answer = false;
    int[] YPosition = { 26, -64 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    int Apple;
    int Bananas;
    int Grapes;
    int Orange;
    int Pineapple;
    int Watermelon;
    int Cherry;
    int TApple;
    int TBananas;
    int TGrapes;
    int TOrange;
    int TPineapple;
    int TWatermelon;
    int TCherry;
    public static int KeyLog;
    public static int Score;
    void Start()
    {
        
        myButton.interactable = false;
      //  Debug.Log("hi");

    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
     // Debug.Log(number);

        if (number == 0)
        {
            number = SetSpawn.number[0];
            objCount = SetSpawn.Obj;//fruits
            QIndex = SetSpawn.question;// value of fruit
         
            StartCoroutine("MyGame");
        }
        myButton.interactable = true;
        if (col.tag=="Apple")
        {
            TApple++;
          //  Debug.Log(TApple);
        }
        else if (col.tag == "Banana")
        {
            TBananas++;
         //   Debug.Log(TBananas);
        }
        else if (col.tag == "Grapes")
        {
            TGrapes++;
         //   Debug.Log(TGrapes);
        }
        else if (col.tag == "Orange")
        {
            TOrange++;
      //      Debug.Log(TOrange);

        }
        else if (col.tag == "Pineapple")
        {
            TPineapple++;
        //    Debug.Log(TPineapple);
        }
        else if (col.tag == "Watermelon")
        {
            TWatermelon++;
        //    Debug.Log(TWatermelon);
        }
        else if (col.tag == "Cherry")
        {
            TCherry++;
          //  Debug.Log(TCherry);
        }
        // Destroy(col.gameObject);
    }
    IEnumerator MyGame()
    {
        yield return new WaitForSeconds(0);
   
        while (x != number)
        {
            Fruit[x] = objCount[x]; // What fruit 
            TFruit[x] = QIndex[x];  // Number of Fruit
          
            x++;
        }
        while (z != number)
        {
            if (Fruit[z] == 0)
            {
                Apple = TFruit[z];
                z++;

            }
            else if (Fruit[z] == 1)
            {
                Bananas = TFruit[z];
                z++;
            }
            else if (Fruit[z] == 2)
            {
                Grapes = TFruit[z];
                z++;
            }
            else if (Fruit[z] == 3)
            {
                Orange = TFruit[z];
                z++;
            }
            else if (Fruit[z] == 4)
            {
                Pineapple = TFruit[z];
                z++;

            }
            else if (Fruit[z] == 5)
            {
                Watermelon = TFruit[z];
                z++;
            }
            else if (Fruit[z] == 6)
            {
                Cherry = TFruit[z];
                z++; 
            }

        }

      
       
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Submit()
    {
        KeyLog++;
        
            if (Apple == TApple && Bananas == TBananas && Grapes == TGrapes &&
          Orange == TOrange && Pineapple == TPineapple && Watermelon == TWatermelon && Cherry == TCherry)
            {
                Score++;
                Debug.Log(Score);
              
            }
            else
            {
                Debug.Log("false");
            }

            if (KeyLog != 10)
            {
                StartCoroutine("RestartGame");
            }
            else
            {
                StartCoroutine("ScoreEval");
            }
       
        
      
    }
    IEnumerator ScoreEval()
    {
        yield return new WaitForSeconds(0);
       // Debug.Log(Score);
        KeyLog = 0;
        Board.SetActive(true);
        Answer = true;
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


    }
    void Update()
    {
      
    }
}
