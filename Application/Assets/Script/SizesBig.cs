using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SizesBig : MonoBehaviour {

	 public GameObject[] Small;
    public GameObject[] Biggest;
    public GameObject TutorialWin;
    string SceneName;
    int TotalScore, current;
    int[] Indexes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] myIndex = { -320, 320 };
    int myKey;
    int[] key = { -200, 200 };
    public static int total;
    int FinTotal;
    int number = 0;
    string result;
    string size;
    bool TimerLimit = false;
   public int timeLeft = 20; //Seconds Overall
    public Text countdown; //UI Text Object
    string myMode;
    int[] YPosition = { 26, -64 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    public static int keyLog;
    public GameObject ScoreBoard;
    public GameObject PanelBoard;
    public AudioSource SoundFx;
    public AudioClip CheckTone;
    public AudioClip WrongTone;
    public static int myScore;
    public GameObject Star;

    void Start()
    {
       // QuestionAudio = GameObject.Find("QuestionAudio").GetComponent<Button>();
       SceneName = SceneManager.GetActiveScene().name;
       if (SceneName == "Sizes Big")
       {
           size = "Size Big";
           myMode = "SizeBig";
       }
       else if(SceneName == "Sizes Small")
       {
           size = "Size Small";
           myMode = "SizeSmall";
       }
            myKey = 0;
            if (keyLog == 0)
            {
                Indexes = randomPos(Indexes);
               // current = PlayerPrefs.GetInt("TotalScore");
            }

            key = randomPos(key);
            if (keyLog != 0)
            {
                Small[Indexes[keyLog - 1]].SetActive(false);
             //   Medium[Indexes[keyLog - 1]].SetActive(false);
                Biggest[Indexes[keyLog - 1]].SetActive(false);
            }
            Vector3 Temp = Small[Indexes[keyLog]].transform.localPosition;
            Temp = new Vector3(key[0], 100, 0);
            Small[Indexes[keyLog]].SetActive(true);
            Small[Indexes[keyLog]].transform.localPosition = Temp;

        

            Vector3 Temp3 = Biggest[Indexes[keyLog]].transform.localPosition;
            Temp3 = new Vector3(key[1], 100, 0);
            Biggest[Indexes[keyLog]].SetActive(true);
            Biggest[Indexes[keyLog]].transform.localPosition = Temp3;

        
    }
    public void TutorialWindow()
    {
        TutorialWin.SetActive(true);
    }
    public void GoBig()
    {
       
        PlayerPrefs.SetString("SizeMode", "BigSize");
        SceneManager.LoadScene("SizeTutorial1");
    }
    public void GoSmall()
    {
      
        PlayerPrefs.SetString("SizeMode", "SmallSize");
        SceneManager.LoadScene("SizeTutorial1");
    }
    public void returnbtn()
    {
        myScore = 0;
        keyLog = 0;
        total = 0;
        SceneManager.LoadScene("Layout Activities Sizes");
    }
    public void BigBTN()
    {
        if (SceneName == "Sizes Big")
        {
            // right answer
            total++;
            SoundFx.PlayOneShot(CheckTone);
            //      Debug.Log("Big");
        }
        else
        {
            Debug.Log("Wrong");
            SoundFx.PlayOneShot(WrongTone);
        }
      
        keyLog++;
        StartCoroutine("RestartGame");

        
    }
    public void SmallBTN()
    {
        if (SceneName == "Sizes Small")
        {
            // right answer 
            total++;
            SoundFx.PlayOneShot(CheckTone);
            //      Debug.Log("Small");
        }
        else
        {
            Debug.Log("Wrong");
            SoundFx.PlayOneShot(WrongTone);
        }
        keyLog++;
        StartCoroutine("RestartGame");
        
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


          IEnumerator ScoreWindow()
          {
              int b = 0, c = 0;
              yield return new WaitForSeconds(1);
              ScoreBoard.SetActive(true);
              PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " "+myMode, total);
              for (int a = 0; a < total; a++)
              {
                  yield return new WaitForSeconds(0.5f);
                  var createImage = Instantiate(Star, new Vector3(XPosition[b], YPosition[c], 0), Quaternion.identity) as GameObject;
                  createImage.transform.SetParent(PanelBoard.transform, false);
                  b++;
                  if (a == 4)
                  {
                      b = 0;
                      c++;
                  }
              }
          }
          IEnumerator RestartGame()
          {
              yield return new WaitForSeconds(1);

              if (keyLog != 10)
              {
                  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
              }
              else
              {

                  StartCoroutine("ScoreWindow");
              }
          }

          public void Done()
          {
              myScore = 0;
              keyLog = 0;
              total = 0;
            SceneManager.LoadScene("Layout Activities Sizes");
          }
}
