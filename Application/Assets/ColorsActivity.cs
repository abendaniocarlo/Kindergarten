using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ColorsActivity : MonoBehaviour {
    public GameObject[] choice;
    public GameObject[] questions;
    int[] variable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    int[] AnsVar = { 2, 5, 8, 11, 14, 17, 20 };
    int[] positionX = { -300, -118, 132, 311 };
    int[] positionY = { 236, 75, -75 };
    int keyLog = 0;
    int answer;
    int[] Final;
    int Total=0;
    int Key;
    int PreQuest;
   
    int[] PreValue;
    int[] PreChoice;
	// Use this for initialization
	void Start () {
        int b = 0;
        int c = 0;
       
		variable = randomPos(variable);
        positionX = randomPos(positionX);
        positionY = randomPos(positionY);
        List<int> FinChoice = new List<int>();
        List<int> ConvertChoice;
        Key = 0;
        if (keyLog != 7)
        {
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
            //end
            Debug.Log(keyLog);
            ConvertChoice = new List<int>(variable);
            for (int d = AnsVar[keyLog]; d != AnsVar[keyLog] - 3; d--)
            {
                FinChoice.Add(d);
                ConvertChoice.Remove(d);
            }

            PreValue = ConvertChoice.ToArray();

            for (int d = 0; d != 9; d++)
            {
                FinChoice.Add(PreValue[d]);

            }

            Final = FinChoice.ToArray();
            Final = randomPos(Final);
            if (keyLog != 0)
            {


                questions[PreQuest - 1].SetActive(false);
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

            }
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
        else
        {
            Debug.Log("Eng Game");
        }
	}
    public void blue()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        if (answer == 1)
        {
            //right answer
            Total++;
           
        }
        else
        {
            Debug.Log("Wrong");
        }
        Key++; //count how many how objects is pressed
        if (Key == 3)
        {
            keyLog++;
            Start();
        }
        
    }
    public void brown()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        if (answer == 2)
        {
            //right answer
            Total++;
      
        }
        else
        {
            Debug.Log("Wrong");
        }
        Key++; //count how many how objects is pressed
        if (Key == 3)
        {
            keyLog++;
            Start();
        }
    }

    public void green()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        if (answer == 3)
        {
            //right answer
            Total++;

        }
        else
        {
            Debug.Log("Wrong");
        }
        Key++; //count how many how objects is pressed
        if (Key == 3)
        {
            keyLog++;
            Start();
        }
    }
    public void orange()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        if (answer == 4)
        {
            //right answer
            Total++;
          
        }
        else
        {
            Debug.Log("Wrong");
        }
        Key++; //count how many how objects is pressed
        if (Key == 3)
        {
            keyLog++;
            Start();
        }
    }
    public void pink()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        if (answer == 5)
        {
            //right answer
            Total++;
            
        }
        else
        {
            Debug.Log("Wrong");
        }
        Key++; //count how many how objects is pressed
        if (Key == 3)
        {
            keyLog++;
            Start();
        }
       
    }
    public void red()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        if (answer == 6)
        {
            //right answer
            Total++;
        
        }
        else
        {
            Debug.Log("Wrong");
        }
        Key++; //count how many how objects is pressed
        if (Key == 3)
        {
            keyLog++;
            Start();
        }
    }
    public void yellow()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        if (answer == 7)
        {
            //right answer
            Total++;

        }
        else
        {
            
            Debug.Log("Wrong");
        }
        Key++; //count how many how objects is pressed
        if (Key == 3)
        {
            keyLog++;
            Start();
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
}