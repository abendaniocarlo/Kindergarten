using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShapesTapGames : MonoBehaviour
{
    public GameObject[] choice;
    public GameObject[] questions;
    // public GameObject TutorialPanel;
    // public GameObject Directions;
    public GameObject ScoreBoard;
    public GameObject[] Star;
    public GameObject wrong1;
    public GameObject wrong2;
    public GameObject wrong3;
    public GameObject correct1;
    public GameObject correct2;
    public GameObject correct3;

    int[] scircle = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    int[] ssquare = { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
    int[] striangle = { 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };
    int[] srectangle = { 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47 };
    int[] soval = { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59 };

    int[] endOfIndexes = { 11, 23, 35, 47, 59, };
    //  int[] wrong = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
    int[] variable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    int[] AnsVar = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
    int[] positionX = { -300, -118, 132, 311 };
    int[] positionY = { 110, -31, -157 };
    public static int keyLog = 0;
    int answer;
    int[] Final;
    string color;
    public static int Total = 0;
    public static int GrandTotal = 0;
    int Key;
    int PreQuest;
    string MyAnswer;
    int Def;
    int[] PreValue = { 31, 50 };
    int[] PreChoice;
    string result;
    string MyColor;
    string ColorIndex;
    int count;
    // Use this for initialization
    void Start()
    {
        int b = 0;
        int c = 0;

        //if (keyLog == 0)
        //    StartCoroutine(DirectionShow());

        wrong1.SetActive(false);
        wrong2.SetActive(false);
        wrong3.SetActive(false);
        correct1.SetActive(false);
        correct2.SetActive(false);
        correct3.SetActive(false);

        scircle = randomPos(scircle);
        ssquare = randomPos(ssquare);
        striangle = randomPos(striangle);
        srectangle = randomPos(srectangle);
        soval = randomPos(soval);
        endOfIndexes = randomPos(endOfIndexes);

        if (endOfIndexes[0] == 11)
        {
            questions[0].SetActive(true);
            answer = 11;
        }
        else if (endOfIndexes[0] == 23)
        {
            questions[1].SetActive(true);
            answer = 23;
        }
        else if (endOfIndexes[0] == 35)
        {
            questions[2].SetActive(true);
            answer = 35;
        }
        else if (endOfIndexes[0] == 47)
        {
            questions[3].SetActive(true);
            answer = 47;
        }
        else if (endOfIndexes[0] == 59)
        {
            questions[4].SetActive(true);
            answer = 59;
        }
       
        variable = randomPos(variable);
        positionX = randomPos(positionX);
        positionY = randomPos(positionY);
        List<int> FinChoice = new List<int>();
        List<int> ConvertChoice;
        Key = 0;

        {
            answer = 1;
            AnsVar = randomPos(AnsVar);
            MyAnswer = SceneManager.GetActiveScene().name;


            ConvertChoice = new List<int>(variable);
            //change d = "Def" to Ansvar[KeyLog] add all the asset from 0 to 30
            for (int d = endOfIndexes[0]; d != endOfIndexes[0] - 3; d--)
            {
                FinChoice.Add(d);
           
            }

            PreValue = ConvertChoice.ToArray();
            
            int yy = 1;
            int n = 0, z = 0;




            for (int d = endOfIndexes[1]; d != endOfIndexes[1] - 3; d--)
            {

                if (z == 3)
                {
                    z = 0;
                    yy++;
                

                }

                z++;
   
                FinChoice.Add(d);
                

            }
            for (int d = endOfIndexes[2]; d != endOfIndexes[2] - 3; d--)
            {

                if (z == 3)
                {
                    z = 0;
                    yy++;
               
                }

                z++;
            
                FinChoice.Add(d);
           

            }
            for (int d = endOfIndexes[3]; d != endOfIndexes[3] - 3; d--)
            {

                if (z == 3)
                {
                    z = 0;
                    yy++;
           

                }

                z++;

                FinChoice.Add(d);
         

            }
            Final = FinChoice.ToArray();
        
            Final = randomPos(Final);

      
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

    //IEnumerator DirectionShow()
    //{
    //    Directions.SetActive(true);
    //    yield return new WaitForSeconds(9f);
    //    Directions.SetActive(false);
    //}

    public void Circle()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many objects is pressed
        if (endOfIndexes[0] == 11)
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
        if (endOfIndexes[0] == 59)
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

    public void Rectangle()
    {

        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (endOfIndexes[0] == 47)
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
    public void Square()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (endOfIndexes[0] == 23)
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
    public void Triangle()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find(name).SetActive(false);
        Key++; //count how many how objects is pressed
        if (endOfIndexes[0] == 35)
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
    void Update()
    {

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
            //PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " " + color, GrandTotal);
        
           
            StartCoroutine("ScoreWindow");
           
        }

    }

    IEnumerator ScoreWindow()
    {
        int temp = 0;
        yield return new WaitForSeconds(0);
     
        ScoreBoard.SetActive(true);
        SaveScore();
        
        keyLog = 0;
    
        while (temp != GrandTotal)
        {
            Star[temp].SetActive(true);
            temp++;
        }
       GrandTotal = 0;
      
    }
    void SaveScore()
    {
        int xx = 0, zz = 0;
        string current = System.DateTime.Now.ToString("MM/dd/yy");
        string myDate;
        int MGScore, test;
        float FGScore;
        bool MyBool = true;
        if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MSDate"))
        {
            //meron

            myDate = PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MSDate");
        //    Debug.Log(GrandTotal);
            MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape");

            if (myDate == current)
            {
                // equal sa current date;

                while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + xx))
                {


                    xx++;
                    if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + xx) == false)
                    {
                        MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + (xx - 1));
                        
                        if (MGScore >= GrandTotal)
                        {
                            FGScore = MGScore;
                   //         Debug.Log("true");
                            
                        }
                        else
                        {
                          //  Debug.Log("false");
                            FGScore = GrandTotal;
                        }

                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGShape" + (xx - 1), Mathf.RoundToInt(FGScore));
                    }

                }

            }
            else
            {

                xx = 0;
                while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + xx) || MyBool == false)
                {
                    PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MSDate", current);
                    MGScore = MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + xx);
                    xx++;
                    if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + xx) == false)
                    {
                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGShape" + xx, GrandTotal);

                        MyBool = false;
                        break;
                    }
                }
            }

        }
        else
        {

            PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MSDate", current);
            PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGShape0", GrandTotal);
        }

        xx = 0;
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + xx))
        {
            //   Debug.Log("s");
            // PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MGShape" + xx);
            //PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MSDate" + xx);
          Debug.Log("x = "+xx +" - "+ PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + xx));
            xx++;
        }

    }
  
 
    public void backBtn()
    {
        GrandTotal = 0;
        keyLog = 0;
        SceneManager.LoadScene("Layout Games Shapes");
    }
    public void Done()
    {
        GrandTotal = 0;
        keyLog = 0;
        SceneManager.LoadScene("Layout Games Shapes");
    }

}