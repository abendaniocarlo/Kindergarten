using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SetCompare : MonoBehaviour {
    public GameObject[] setObjects;
    public GameObject canvas;
    public AudioSource SoundFx;
    public AudioClip CheckTone;
    public AudioClip WrongTone;
    public GameObject Box1,Box2;
    public GameObject[] Questions;
    public GameObject TutorialBox;
    string result;
    int[] setIndex = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    //Question Position
    int[] SetPosition = { 202, 112, 21, -68, -142};
   int[] ZPosition = { -65, 35 };
    //box positions
    int[] BoxPositionX = { -116, 5, 115 };
    int[] BoxPositionY = { 146, 47, -44, -380 };
    int[] minValues = { 1, 2, 3};
   int[] Final = new int[2];
   int QuestVal;
   int[] Quest = { 0, 1, 2 };
   public static int Score;
   int choice;
   int MyVar;

   int[] YPosition = { 26, -64 };
   int[] XPosition = { -143, -71, 0, 74, 146 };
   public static int keyLog;
    public static int directionOnce;
    public GameObject ScoreBoard;
   public GameObject PanelBoard;
    public GameObject directions;
    public GameObject other;
    public static int myScore;
   public GameObject Star;
	// Use this for initialization
	void Start () {
        if (keyLog == 0)
        {
            setIndex = randomPos(setIndex);
        }
        if (directionOnce == 0)
        {
            StartCoroutine(DirectionPlay());
            directionOnce++;
        }

        int b = 0, c=0 ,x=0,y=0;
        minValues = randomPos(minValues);
        Final[0] = 9 - minValues[0];
        Final[1] = 9 - minValues[1];
        Quest = randomPos(Quest);

        Questions[Quest[0]].SetActive(true);
        if (Quest[0] == 0)
        {
           
            MyVar = Random.Range(0, 100);
          
            if (MyVar >= 50)
            {
                MyVar = 1;
                choice = 1;
            }
            else
            {
                MyVar = 0;
                choice = 0;
            }
          
        }
        //question Loop
        if (Quest[0] == 0)
        {
            QuestVal = Final[MyVar];
           
        }
        else if (Quest[0] == 1)
        {
            if (Final[0] > Final[1])
            {
                QuestVal = Final[1];
                choice = 0;
            }
            else
            {
                QuestVal = Final[0];
                choice = 1;
            }
        }
        else if (Quest[0] == 2)
        {
            if (Final[0] > Final[1])
            {
                QuestVal = Final[0];
                choice = 1;
            }
            else
            {
                QuestVal = Final[1];
                choice = 0;
            }
        }
        for (int a = 0; a <= QuestVal;a++)
        {
            var createImage = Instantiate(setObjects[setIndex[keyLog]], new Vector3(ZPosition[c], SetPosition[b], 0), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(canvas.transform, false);
            b++;
            if (a ==4)
            {
                b = 0;
                c++;
            }
        }
        //choice1 Loop
        for (int a = 0; a <= Final[0]; a++)
        {
            var createImage = Instantiate(setObjects[setIndex[keyLog]], new Vector3(BoxPositionX[x], BoxPositionY[y], 0), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Box1.transform, false);
            x++;
            if (a==2||a==5)
            {
                x=0;
                y++;
            }
            else if(a==8)
            {
                x = 1;
                y = 3;
            }
        }
        x = 0; y = 0;
        for (int a = 0; a <= Final[1]; a++)
        {
            var createImage = Instantiate(setObjects[setIndex[keyLog]], new Vector3(BoxPositionX[x], BoxPositionY[y], 0), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Box2.transform, false);
            x++;
            if (a == 2 || a == 5)
            {
                x = 0;
                y++;
            }
            else if (a == 8)
            {
                x = 1;
                y = 3;
            }
        }
           
	}
    public void SetOne()
    {
        keyLog++;
        StartCoroutine("RestartGame");
        if (choice == 0)
        {
            Score++;
            Debug.Log(Score);
            SoundFx.PlayOneShot(CheckTone);

        }
        else
        {
            Debug.Log("Wrong");
            SoundFx.PlayOneShot(WrongTone);
        }
    }
    public void SetTwo()
    {
        keyLog++;
        StartCoroutine("RestartGame");
        if (choice ==1)
        {
            Score++;
            Debug.Log(Score);
            SoundFx.PlayOneShot(CheckTone);
        }
        else
        {
            Debug.Log("Wrong");
            SoundFx.PlayOneShot(WrongTone);
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
    IEnumerator DirectionPlay()
    {
        other.SetActive(false);
        directions.SetActive(true);
        yield return new WaitForSeconds(6f);
        other.SetActive(true);
        directions.SetActive(false);
    }
    public void TutorialWindow()
    {
        Time.timeScale = 1f;
        TutorialBox.SetActive(true);
        PlayerPrefs.SetString("SetIndex", "Set2");
    }
    public void returnbtn()
    {
        Score = 0;
        keyLog = 0;
        myScore = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Layout Activities Sets");
    }
    IEnumerator ScoreWindow()
    {
        int b = 0, c = 0;
        yield return new WaitForSeconds(1);
        ScoreBoard.SetActive(true);
      
        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " SetTwo", Score);
        for (int a = 0; a < Score; a++)
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
        Score = 0;
        keyLog = 0;
        myScore = 0;
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
        directionOnce = 0;
        Score = 0;
        keyLog = 0;
        myScore = 0;
        SceneManager.LoadScene("Layout Activities Sets");
    }
}
