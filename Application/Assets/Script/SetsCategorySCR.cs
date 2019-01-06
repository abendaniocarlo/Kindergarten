using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetsCategorySCR : MonoBehaviour {
    int[] values = { 8, 17, 26, 35, 44 };
  
    public GameObject[] Animals;
    public GameObject[] fruits;
    public GameObject[] category;
    public GameObject[] Stars;
    public GameObject[] questions;
    public GameObject SetsCategory;
    public GameObject PatternsCategory;
    public GameObject ScoreWindow;
    public AudioSource SoundFx;
    public AudioClip CheckTone;
    public AudioClip WrongTone;
    public Button QuestionAudio;
    public AudioClip QuestionSetsBigger;
    public AudioClip QuestionSetsSmaller;
    int[] Quest = { 0, 1 };
    int[] Position = { 1, 2 };
    int count = 0;
    int number = 0;
    int TotalScore, current;
    int answer;
    int keyLog = 0;
   string setAnswer;
    int setValue1;
    int setValue2;
    int score = 0;
    int PreValue1;
    int PreValue2;
    int PreObjects1;
    int PreObjects2;
    string result;
    bool TimerLimit = false;
   public int timeLeft = 10; //Seconds Overall
    public Text countdown; //UI Text Object
	void Start () {
        QuestionAudio = GameObject.Find("QuestionAudio").GetComponent<Button>();

        bool type = false;
        int[] box = { -370, 130 };
        int boxy1 = 130;
        int boxy2 = 130;
        int[] min = {1,2,3};
        int[] index = { 4, 5, 6, 7, 9 };
        int subTotal1,subTotal2;
        int temp;
        int a = 0;
        int b = 0;
        if (keyLog == 0) 
        {
            values = randomPos(values);
        }
      
        min = randomPos(min);
        box = randomPos(box);
        index = randomPos(index);
        Position = randomPos(Position);
        Quest = randomPos(Quest);
        questions[Quest[0]].SetActive(true);
        subTotal1 = values[keyLog] - min[0];
        subTotal2 = values[keyLog] - min[1];
        temp = values[keyLog] - index[keyLog];
        if (box[0] == -370)
        {
            type = true;

        }
        if (min[0] > min[1] && Quest[0] == 0)
        {
            setAnswer = "set2";
          
        }
        else if (min[0] < min[1] && Quest[0] == 0)
        {
            setAnswer = "set1";
        }
        else if (min[0] > min[1] && Quest[0] == 1)
        {
            setAnswer = "set1";
        }
        else if (min[0] < min[1] && Quest[0] == 1)
        {
            setAnswer = "set2";
        }
        
        //remove previous objects on screen
        if (keyLog != 0)
        {
        
            for (int z = PreValue1; z != PreObjects1 - PreObjects2; z--)
            {

                Animals[z].SetActive(false);
               
            }
            for (int z = PreValue2; z != PreObjects1 - PreObjects2; z--)
            {
                fruits[z].SetActive(false);
            }
        }
        if (type == false && setAnswer =="set2")
        {
            setAnswer = "set1";
        }
        else if(type == false && setAnswer == "set1")
        {
            setAnswer = "set2";
        }

   
        
        for (int z = subTotal1; z != temp; z--)
        {

            Vector3 Temp = Animals[z].transform.localPosition;
            Temp = new Vector3(box[0], boxy1, 0);
            Animals[z].SetActive(true);
            Animals[z].transform.localPosition = Temp;
            box[0] = box[0] - (-100);
           
            a++;
            if (a == 3 || a==6)
            {
                boxy1 = boxy1 - 100;
               
                if (type == true)
                {
                   
                    box[0] = -370;
                }
                else
                {
                    box[0] = 130;
                }
               
            }

        }
     
        for (int x = subTotal2; x != temp; x--)
        {

            Vector3 Temp2 = fruits[x].transform.localPosition;
            Temp2 = new Vector3(box[1], boxy2, 0);
            fruits[x].SetActive(true);
            fruits[x].transform.localPosition = Temp2;
            box[1] = box[1] - (-100);
            b++;
            if (b == 3 || b == 6)
            {
                boxy2 = boxy2 -100;
                if (type == false)
                {
                    box[1] = -370;
                }
                else
                {
                    box[1] = 130;
                }
               
            }

        }
     

        PreValue1 = subTotal1;
        PreValue2 = subTotal2;
        PreObjects1 = values[keyLog];
        PreObjects2 = index[keyLog];

        QuestionAudio.onClick.AddListener(() => questionButton());
    }
    IEnumerator LoseTime()  //Timer Function
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

    }
    public void set1()
    {
        keyLog++;
        questions[Quest[0]].SetActive(false);
        if (setAnswer == "set1")
        {
            score++;

            SoundFx.PlayOneShot(CheckTone);
        }
        else
        {
            SoundFx.PlayOneShot(WrongTone);
        }

        if (keyLog != 5)
        {
            Start();
        }

        if (TimerLimit == false)
        {
            StartCoroutine("LoseTime");
            TimerLimit = true;
        }
    
    }
    public void set2()
    {
        keyLog++;
        questions[Quest[0]].SetActive(false);
        if (setAnswer == "set2")
        {
            score++;

            SoundFx.PlayOneShot(CheckTone);
        }
        else
        {
            SoundFx.PlayOneShot(WrongTone);
        }

        if (keyLog != 5)
        {
            Start();
        }

        if (TimerLimit == false)
        {
            StartCoroutine("LoseTime");
            TimerLimit = true;
        }
    
    }
	// Update is called once per frame
	void Update () {
        countdown.text = ("" + timeLeft);
        if (timeLeft <= 5)
        {
            countdown.color = Color.red;

        }
        if (timeLeft < 0)
        {
            ScoreWindow.SetActive(true);
        }
        if (keyLog == 5)
        {
            ScoreWindow.SetActive(true);
          
        }
        while (number != score*2)
        {
            Stars[number].SetActive(true);
            number++;
        }
	}

    public void questionButton()
    {
        if (Quest[0] == 0)
        {
            SoundFx.PlayOneShot(QuestionSetsBigger);
        }
        else if (Quest[0] == 1)
        {
            SoundFx.PlayOneShot(QuestionSetsSmaller);
        }
    }

    public void next()
    {
      
        SetsCategory.SetActive(false);
        PatternsCategory.SetActive(true);
        current = PlayerPrefs.GetInt("TotalScore");
        TotalScore = (score*2) + current;
        PlayerPrefs.SetInt("TotalScore", TotalScore);
        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " Sets", score*2);
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
