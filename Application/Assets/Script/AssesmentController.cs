using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AssesmentController : MonoBehaviour {
    string result;
    int index = 0;
    public GameObject[] PreTestBar;
    public GameObject[] GraphBox;
    public Font myFont;
    public GameObject[] Buttons;
    public GameObject[] textBox;
    public GameObject[] Canvas;
    int[] PositionY = { -151, -81, -19, 54, 116 };
    int[] ButtonsX = { -279, -109, 62, 233, 406 };
    int KeyLog = 0;
    int ScoreBar;
    int ColorsScore;
     int ShapesScore;
     int SizesScore;
     int SetsScore;
     int Value;
     int PatternsScore;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;

        ColorsScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Colors");
        ShapesScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Shapes");
        SizesScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Sizes");
        SetsScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Sets");
        PatternsScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Patterns");
        if (KeyLog == 0)
        {
            myOverAll();
           
        }

     
       
	}
    void myOverAll()
    {
        int count = 0;
        
        int current = -371;
        float[] GrandTotal = new float[5];
        int x = 0, y = 0, z = 0, a = 0, b = 0,yy=0;
        int ColorCurrent = 0, ShapesCurrent = 0, SizesCurrent = 0, SetsCurrent = 0, PatternsCurrent = 0;
      
        
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGColor" + x))
        {
           
            ColorCurrent =ColorCurrent + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGColor" + x);
            
            x++;
        }
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + y))
        {
            ShapesCurrent = ShapesCurrent + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + y);
            y++;
        }
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGPattern" + z))
        {
            PatternsCurrent = PatternsCurrent + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + z);
            z++;
        }
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSet" + a))
        {
            SetsCurrent =SetsCurrent + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + a);
            a++;
        }
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSize" + b))
        {
            SizesCurrent = SizesCurrent + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + b);
            b++;
        }

        Mathf.RoundToInt(GrandTotal[0] = (ColorCurrent + ColorsScore)/(x+1));
        Mathf.RoundToInt(GrandTotal[1] = (ShapesCurrent + ShapesScore) / (y+1));
        Mathf.RoundToInt(GrandTotal[2] = (SizesCurrent + SizesScore) / (b+1));
        Mathf.RoundToInt(GrandTotal[3] = (SetsCurrent + SetsScore) / (a+1));
        Mathf.RoundToInt(GrandTotal[4] = (PatternsCurrent + PatternsScore) / (z+1));

       
        while (count != 5)
        {
            for (int aa = 0; aa < Mathf.RoundToInt(GrandTotal[count]/2); aa++)
            {
                if (Mathf.RoundToInt(GrandTotal[count] / 2) <= 1)
                {
                    index = 0;
                }
                else if(Mathf.RoundToInt(GrandTotal[count] / 2) == 2)
                {
                    index = 1;
                }
                else if (Mathf.RoundToInt(GrandTotal[count] / 2) == 3)
                {
                    index = 2;
                }
                else if (Mathf.RoundToInt(GrandTotal[count] / 2) == 4)
                {
                    index = 3;
                }
                else if (Mathf.RoundToInt(GrandTotal[count] / 2) == 5)
                {
                    index = 4;
                }
                var createImage = Instantiate(PreTestBar[index], new Vector3(current, PositionY[yy], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox[0].transform, false);
               
                yy++;
            }
            Vector3 Temp3 = Buttons[count].transform.position;
            Temp3 = new Vector3(ButtonsX[count], PositionY[yy-1], 0);
            Buttons[count].transform.localPosition = Temp3;

            current = current + 171;

            yy = 0;
            x++;
            count++;
        }
    }
    void PreTest()
    {
        int y = 0, x = 0, b = 0;
        int current = -371;
        GameObject ngo = new GameObject("myTextGO");
        ngo.transform.SetParent(textBox[KeyLog-1].transform);
        Vector3 tempCheck = ngo.transform.localPosition;
        tempCheck = new Vector3(-350, -13, 0);
        ngo.transform.localPosition = tempCheck;
        Text myText = ngo.AddComponent<Text>();
        myText.font = myFont;
        myText.color = Color.black;
        myText.text = PlayerPrefs.GetString(PlayerPrefs.GetString(result)+" PreTestDate");


        GameObject ngo1 = new GameObject("myTextGO");
        ngo1.transform.SetParent(textBox[KeyLog-1].transform);
        Vector3 tempCheck1 = ngo1.transform.localPosition;
        tempCheck1 = new Vector3(-350, -33, 0);
        ngo1.transform.localPosition = tempCheck1;
        Text myText1 = ngo1.AddComponent<Text>();
        myText1.font = myFont;
        myText1.color = Color.black;
        myText1.text = "PreTest";
        
            for (int a = 0; a < ScoreBar; a++)
            {
                if (ScoreBar <= 1)
                {
                    index = 0;
                }
                else if (ScoreBar == 2)
                {
                    index = 1;
                }
                else if (ScoreBar == 3)
                {
                    index = 2;
                }
                else if (ScoreBar == 4)
                {
                    index = 3;
                }
                else if (ScoreBar == 5)
                {
                    index = 4;
                }
                var createImage = Instantiate(PreTestBar[index], new Vector3(current, PositionY[y], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox[KeyLog].transform, false);
                y++;
            }
            b++;
            y = 0;
      
       
      
    }
    void myColor()
    {
        int x=0,b=0,y=0;
        int current = -371;
        int Date = -350;
        foreach (GameObject temp in Canvas)
        {
            if (temp.name != "Colors")
            {
                temp.SetActive(false);
            }
            else
            {
                temp.SetActive(true);
            }
        }
        while(PlayerPrefs.HasKey(PlayerPrefs.GetString(result) +" MGColor"+x))
        {
             current = current + 75;
             Date = Date + 83;
            
            for (int a = 0; a < PlayerPrefs.GetInt(PlayerPrefs.GetString(result)+ " MGColor"+x)/2; a++)
            {
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGColor" + x) / 2 <= 1)
                {
                    index = 0;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGColor" + x) / 2 == 2)
                {
                    index = 1;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGColor" + x) / 2 == 3)
                {
                    index = 2;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGColor" + x) / 2 == 4)
                {
                    index = 3;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGColor" + x) / 2 == 5)
                {
                    index = 4;
                }
                var createImage = Instantiate(PreTestBar[index], new Vector3(current, PositionY[y], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox[1].transform, false);
                y++;
            }
            GameObject ngo = new GameObject("myTextGO");
            ngo.transform.SetParent(textBox[0].transform);
            Vector3 tempCheck = ngo.transform.localPosition;
            tempCheck = new Vector3(Date, -13, 0);
            ngo.transform.localPosition = tempCheck;
            Text myText = ngo.AddComponent<Text>();
            myText.font = myFont;
            myText.color = Color.black;
            myText.text = PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MCDate" + x);
            b++;
            y = 0;

            x++;
         
        }
    }
    void myShapes()
    {
        int x = 0, b = 0, y = 0;
        int current = -371;
        int Date = -350;
        foreach (GameObject temp in Canvas)
        {
            if (temp.name != "Shapes")
            {
                temp.SetActive(false);
            }
            else
            {
                temp.SetActive(true);
            }
        }
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + x))
        {
            current = current + 75;
            Date = Date + 83;
            for (int a = 0; a < PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + x) / 2; a++)
            {
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + x) / 2 <= 1)
                {
                    index = 0;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + x) / 2 == 2)
                {
                    index = 1;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + x) / 2 == 3)
                {
                    index = 2;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + x) / 2 == 4)
                {
                    index = 3;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + x) / 2 == 5)
                {
                    index = 4;
                }
                var createImage = Instantiate(PreTestBar[index], new Vector3(current, PositionY[y], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox[2].transform, false);

                y++;
            }
            GameObject ngo = new GameObject("myTextGO");
            ngo.transform.SetParent(textBox[1].transform);
            Vector3 tempCheck = ngo.transform.localPosition;
            tempCheck = new Vector3(Date, -13, 0);
            ngo.transform.localPosition = tempCheck;
            Text myText = ngo.AddComponent<Text>();
            myText.font = myFont;
            myText.color = Color.black;
            myText.text = PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MSDate" + x);
            b++;
            y = 0;
            x++;

        }
    }
    void myPattern()
    {
        int x = 0, b = 0, y = 0;
        int current = -371;
        int Date = -350;
        foreach (GameObject temp in Canvas)
        {
            if (temp.name != "Patterns")
            {
                temp.SetActive(false);
            }
            else
            {
                temp.SetActive(true);
            }
        }
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGPattern" + x))
        {
            current = current + 75;
            Date = Date + 83;
            for (int a = 0; a < PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + x) / 2; a++)
            {
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + x) / 2 <= 1)
                {
                    index = 0;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + x) / 2 == 2)
                {
                    index = 1;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + x) / 2 == 3)
                {
                    index = 2;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + x) / 2 == 4)
                {
                    index = 3;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGPattern" + x) / 2 == 5)
                {
                    index = 4;
                }
                var createImage = Instantiate(PreTestBar[index], new Vector3(current, PositionY[y], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox[5].transform, false);

                y++;
            }
            GameObject ngo = new GameObject("myTextGO");
            ngo.transform.SetParent(textBox[4].transform);
            Vector3 tempCheck = ngo.transform.localPosition;
            tempCheck = new Vector3(Date, -13, 0);
            ngo.transform.localPosition = tempCheck;
            Text myText = ngo.AddComponent<Text>();
            myText.font = myFont;
            myText.color = Color.black;
            myText.text = PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MPDate" + x);
            b++;
            y = 0;
            x++;

        }
    }
    void mySets()
    {
        int x = 0, b = 0, y = 0;
        int current = -371;
        int Date = -350;
        foreach (GameObject temp in Canvas)
        {
            if (temp.name != "Sets")
            {
                temp.SetActive(false);
            }
            else
            {
                temp.SetActive(true);
            }
        }
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSet" + x))
        {
            current = current + 75;
            Date = Date + 83;
            for (int a = 0; a < PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + x) / 2; a++)
            {
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + x) / 2 <= 1)
                {
                    index = 0;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + x) / 2 == 2)
                {
                    index = 1;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + x) / 2 == 3)
                {
                    index = 2;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + x) / 2 == 4)
                {
                    index = 3;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSet" + x) / 2 == 5)
                {
                    index = 4;
                }
                var createImage = Instantiate(PreTestBar[index], new Vector3(current, PositionY[y], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox[4].transform, false);

                y++;
            }
            GameObject ngo = new GameObject("myTextGO");
            ngo.transform.SetParent(textBox[3].transform);
            Vector3 tempCheck = ngo.transform.localPosition;
            tempCheck = new Vector3(Date, -13, 0);
            ngo.transform.localPosition = tempCheck;
            Text myText = ngo.AddComponent<Text>();
            myText.font = myFont;
            myText.color = Color.black;
            myText.text = PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MTDate" + x);
            b++;
            y = 0;
            x++;

        }
    }
    void mySize()
    {
        int x = 0, b = 0, y = 0;
        int current = -371;
        int Date = -350;
        foreach (GameObject temp in Canvas)
        {
            if (temp.name != "Size")
            {
                temp.SetActive(false);
            }
            else
            {
                temp.SetActive(true);
            }
        }
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGSize" + x))
        {
            current = current + 75;
            Date = Date + 83;
            for (int a = 0; a < PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + x) / 2; a++)
            {
                if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + x) / 2 <= 1)
                {
                    index = 0;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + x) / 2 == 2)
                {
                    index = 1;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + x) / 2 == 3)
                {
                    index = 2;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + x) / 2 == 4)
                {
                    index = 3;
                }
                else if (PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGSize" + x) / 2 == 5)
                {
                    index = 4;
                }
                var createImage = Instantiate(PreTestBar[index], new Vector3(current, PositionY[y], 0), Quaternion.identity) as GameObject;
                createImage.transform.SetParent(GraphBox[3].transform, false);

                y++;
            }
            GameObject ngo = new GameObject("myTextGO");
            ngo.transform.SetParent(textBox[2].transform);
            Vector3 tempCheck = ngo.transform.localPosition;
            tempCheck = new Vector3(Date, -13, 0);
            ngo.transform.localPosition = tempCheck;
            Text myText = ngo.AddComponent<Text>();
            myText.font = myFont;
            myText.color = Color.black;
            myText.text = PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MZDate" + x);
            b++;
            y = 0;
            x++;

        }
    }

    public void ColorBTN()
    {
        KeyLog = 1;
        Value = 0;
        ScoreBar = ColorsScore / 2;
        myColor();
        PreTest();
       
       
     
    }
  
    public void ShapesBTN()
    {
        KeyLog = 2;
        ScoreBar = ShapesScore / 2;
        myShapes();
        PreTest();
    }
    public void SizesBTN()
    {
        KeyLog = 3;
        ScoreBar = SizesScore / 2;
        mySize();
        PreTest();
   
     
    }
    public void SetsBTN()
    {
        KeyLog = 4;
        ScoreBar = SetsScore / 2;
       
        mySets();
        PreTest();
 
    }
    public void PatternBTN()
    {
        KeyLog = 5;
        ScoreBar = PatternsScore / 2;
        myPattern();
        PreTest();
        
    }
    public void ReturnBTN()
    {
        foreach (GameObject temp in Canvas)
        {
            if (temp.name != "Overall")
            {
                temp.SetActive(false);
            }
            else
            {
                temp.SetActive(true);
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
