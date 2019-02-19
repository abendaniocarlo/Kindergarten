using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ShapesActivity : MonoBehaviour {

    public GameObject[] choice;
    public GameObject[] questions;
    public GameObject Directions;
    public GameObject wrong1;
    public GameObject wrong2;
    public GameObject wrong3;
    public GameObject correct1;
    public GameObject correct2;
    public GameObject correct3;
    public GameObject TutorialPanel;
    int[] wrong = { 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
    int[] variable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
    int[] AnsVar = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
    int[] positionX = { -300, -118, 132, 311 };
    int[] positionY = { 236, 75, -75 };

    int[] YPosition = { 26, -64 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    public static int keyLog;
    public GameObject ScoreBoard;
    public GameObject PanelBoard;
    public static int myScore;
    public GameObject Star;
    string result;
    string Shapes;
    int answer;
    int[] Final;
    public static int Total = 0;
    int Key;
    int PreQuest;
    string MyAnswer;
    int Def;
    int[] PreValue;
    int[] PreChoice;
    // Use this for initialization
    void Start()
    {
        int b = 0;
        int c = 0;

        if (keyLog == 0)
            StartCoroutine(DirectionShow());

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
    
                AnsVar = randomPos(AnsVar);
            MyAnswer = SceneManager.GetActiveScene().name;
            if (MyAnswer == "Shapes Activities")
            {
                Shapes = "Shp Circle";
                questions[0].SetActive(true);
                PlayerPrefs.SetString("ShapeIndex", MyAnswer);
                answer = 1;
                Def = 2;
            }
            else if (MyAnswer == "Shapes Oblong")
            {
                Shapes = "Shp Oblong";
                questions[1].SetActive(true);
                PlayerPrefs.SetString("ShapeIndex", MyAnswer);
                answer = 2;
                Def = 5;
            }
            else if (MyAnswer == "Shapes Square")
            {
                Shapes = "Shp Square";
                questions[3].SetActive(true);
                PlayerPrefs.SetString("ShapeIndex", MyAnswer);
                answer = 3;
                Def = 8;
            }
            else if (MyAnswer == "Shapes Triangle")
            {
                Shapes = "Shp Triangle";
                questions[4].SetActive(true);
                PlayerPrefs.SetString("ShapeIndex", MyAnswer);
                answer = 4;
                Def = 11;
            }
            else if (MyAnswer == "Shapes Rectangle")
            {
                Shapes = "Shp Rectangle";
                questions[2].SetActive(true);
                PlayerPrefs.SetString("ShapeIndex", MyAnswer);
                answer = 5;
                Def = 14;
            }
            Debug.Log(MyAnswer);
         
            //Debug.Log("a"+AnsVar[keyLog]);
            
      

            ConvertChoice = new List<int>(variable);
            //change d = "Def" to Ansvar[KeyLog] add all the asset from 0 to 30
            for (int d = Def; d != Def - 3; d--)
            {
                FinChoice.Add(AnsVar[d]);
                //ConvertChoice.Remove(d);
            }

            PreValue = ConvertChoice.ToArray();

            for (int d = 0; d != 9; d++)
            {
                FinChoice.Add(wrong[d]);

            }

            Final = FinChoice.ToArray();
            Final = randomPos(Final);
            if (keyLog != 0)
            {


            //    questions[PreQuest - 1].SetActive(false);
          /*      for (int y = 0; y != 12; y++)
                {
                    for (int x = 0; x != 12; x++)
                    {
                        if (Final[y] != PreChoice[x])
                        {
                            choice[PreChoice[x]].SetActive(false);
                        }
                    }

                }*/

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

    IEnumerator DirectionShow()
    {
        Directions.SetActive(true);
        yield return new WaitForSeconds(9f);
        Directions.SetActive(false);
    }

    public void Circle()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many objects is pressed
        if (answer == 1)
        {
            //right answer
            Total++;
         
            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
           // Debug.Log("Wrong");

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
    public void Oblong()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (answer == 2)
        {
            //right answer
            Total++;
       //     Debug.Log(Total);

            if (Key == 1) // checkbar if correct
                correct1.SetActive(true);
            else if (Key == 2)
                correct2.SetActive(true);
            else if (Key == 3)
                correct3.SetActive(true);
        }
        else
        {
      //      Debug.Log("Wrong");

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
            StartCoroutine("RestartGame");
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
            StartCoroutine("RestartGame");
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
            StartCoroutine("RestartGame");
        }

    }

    IEnumerator ScoreWindow()
    {
        int b = 0, c = 0;
        yield return new WaitForSeconds(1);
        ScoreBoard.SetActive(true);
       PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " " + Shapes, Total/3);
        for (int a = 0; a < Total/3; a++)
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
        myScore = 0;
        Total = 0;
        keyLog = 0;
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

    public void HomeBtn()
    {
        SceneManager.LoadScene("Layout Activities Shapes");
        myScore = 0;
        Total = 0;
        keyLog = 0;
    }
    public void TapShapes()
    {
        SceneManager.LoadScene("Tap Shapes");
    }
    public void Tutorial()
    {
        TutorialPanel.SetActive(true);
    }
    public void Close()
    {
        TutorialPanel.SetActive(false);
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
