using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCompare : MonoBehaviour {
    public GameObject[] setObjects;
    public GameObject canvas;
    public GameObject Box1,Box2;
    public GameObject[] Questions;
    int[] setIndex = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    //Question Position
    int[] SetPosition = { 141, 85, 28, -23, -74};
   int[] YPosition = { -27, 25 };
    //box positions
   int[] BoxPositionX = { -62, -1, 54 };
   int[] BoxPositionY = { 56, 12, -27, -82 };
   int[] minValues = { 1, 2, 3};
   int[] Final = new int[2];
   int QuestVal;
   int keyLog;
   int[] Quest = { 0, 1, 2 };
   public static int Score;
   int choice;
   int MyVar;
	// Use this for initialization
	void Start () {
        if (keyLog == 0)
        {
            setIndex = randomPos(setIndex);
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
            var createImage = Instantiate(setObjects[setIndex[keyLog]], new Vector3(YPosition[c], SetPosition[b], 0), Quaternion.identity) as GameObject;
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
        StartCoroutine("RestartGame");
        if (choice == 0)
        {
            Score++;
            Debug.Log(Score);
            
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
    public void SetTwo()
    {
        StartCoroutine("RestartGame");
        if (choice ==1)
        {
            Score++;
            Debug.Log(Score);
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(keyLog!=10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("Game Ended"); // Score Board pop out
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
	// Update is called once per frame
	void Update () {
		
	}
}
