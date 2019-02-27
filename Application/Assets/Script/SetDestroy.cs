using System.Collections;
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
    string result;
    public AudioSource SoundFx;
    public AudioClip CheckTone;
    public AudioClip WrongTone;
    void Start()
    {
        
        myButton.interactable = false;
      
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
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Submit()
    {
        KeyLog++;
        
            if (Apple == TApple && Bananas == TBananas && Grapes == TGrapes &&
          Orange == TOrange && Pineapple == TPineapple && Watermelon == TWatermelon && Cherry == TCherry)
            {
                Score++;
            SoundFx.PlayOneShot(CheckTone);
        }
            else
            {
                Debug.Log("false");
            SoundFx.PlayOneShot(WrongTone);
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

       // string current = "02/24";
      string current = System.DateTime.Now.ToString("MM/dd");
        string myDate;
        int MGScore, test;
        int FGScore;
        bool MyBool = true;

        if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MTDate0"))
        {
            // Date EXIST!

            while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MTDate" + xx))
            {
                xx++;
                // get the last stored date
                if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MTDate" + xx))
                {

                    //check if its equal to current date

                    if (PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MTDate" + (xx - 1)) == current)
                    {
                        //Same date of exam  
                        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSet" + zz))
                        {
                            // Get he last stored score for same date
                            zz++;

                            if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSet" + zz))
                            {
                                MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + (zz - 1));
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
                                PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGSet" + (zz - 1), FGScore);

                            }
                        }

                    }
                    else
                    {
                        // not equal to current date

                        PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MTDate" + xx, current);
                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGSet" + xx, Score);
                        break;
                    }
                }


            }
        }
        else
        {
            // No date & score yet
            Debug.Log("hey jude");
            PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MTDate0", current);
            PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGSet0", Score);
        }
        xx = 0;
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MTDate" + xx))
        {

            // PlayerPrefs.DeleteKey(PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MGSet" + xx));
            //   PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MTDate" + xx);
            Debug.Log("S = " + xx + "---" + PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MTDate" + xx));
            Debug.Log("x = " + xx + "---" + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + xx));
            xx++;
        }

    }//END
    public void EndBTN()
    {
        KeyLog = 0;
        Score = 0;
        Answer = false;
        SceneManager.LoadScene("Layout Games Sets");
    }
  
}
