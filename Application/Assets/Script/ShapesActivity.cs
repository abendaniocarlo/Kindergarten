using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ShapesActivity : MonoBehaviour {

    public GameObject[] choice;
    public GameObject[] questions;
    public GameObject wrong1;
    public GameObject wrong2;
    public GameObject wrong3;
    public GameObject correct1;
    public GameObject correct2;
    public GameObject correct3;
    int[] variable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
    int[] AnsVar = { 2, 5, 8, 11, 14};
    int[] positionX = { -300, -118, 132, 311 };
    int[] positionY = { 236, 75, -75 };
    int keyLog = 0;
    int answer;
    int[] Final;
    int Total = 0;
    int Key;
    int PreQuest;

    int[] PreValue;
    int[] PreChoice;
    // Use this for initialization
    void Start()
    {
        int b = 0;
        int c = 0;

        wrong1.SetActive(false);
        wrong2.SetActive(false);
        wrong3.SetActive(false);
        correct1.SetActive(false);
        correct2.SetActive(false);
        correct3.SetActive(false);

        variable = randomPos(variable);
        positionX = randomPos(positionX);
        positionY = randomPos(positionY);
        List<int> FinChoice = new List<int>();
        List<int> ConvertChoice;
        Key = 0;
        if (keyLog != 5)
        {
            if (keyLog == 0)
            {
                AnsVar = randomPos(AnsVar);
                answer = 0;
                

            }
            Debug.Log("a"+AnsVar[keyLog]);
            
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
           
            //end

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
            Debug.Log("B" + answer);
            PreQuest = answer;
            PreChoice = Final;
        }
        else
        {
            Debug.Log("Eng Game");
        }
    }
    public void Circle()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 1)
        {
            //right answer
            Total++;
            Debug.Log(Total);

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
            Start();
        }

    }
    public void Oblong()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 2)
        {
            //right answer
            Total++;
            Debug.Log(Total);

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
            Start();
        }
    }

    public void Rectangle()
    {
        
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 5)
        {
            //right answer
            Total++;
            Debug.Log(Total);

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
            Start();
        }
    }
    public void Square()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 3)
        {
            //right answer
            Total++;
            Debug.Log(Total);

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
            Start();
        }
    }
    public void Triangle()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 4)
        {
            //right answer
            Total++;
            Debug.Log(Total);

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
            Start();
        }

    }
    
    // Update is called once per frame
    void Update()
    {

    }
    public void HomeBtn()
    {
        SceneManager.LoadScene("Main Menu");
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
