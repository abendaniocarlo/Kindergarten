using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PatternsCategorySCR : MonoBehaviour {
    public GameObject[] Animals;
    public GameObject[] fruits;
    public GameObject[] category;
    public GameObject[] Stars;
    public GameObject[] questions;
    public Button QuestionAudio;
    public AudioClip QuestionPatterns;
    public GameObject PatternsCategory;
    int TotalScore;
    public GameObject ScoreWindow;
    int keyLog=0;
    int number=0;
    int current = 0;

    int Score=0;
    public AudioSource SoundFx;
    public AudioClip CheckTone;
    public AudioClip WrongTone;
    bool answer = false;
    int[] index = { 0, 1, 2, 3, 4 };
    string result = "";
    bool TimerLimit = false;
   public int timeLeft = 10; //Seconds Overall
    public Text countdown; //UI Text Object
	// Use this for initialization
	void Start () {
        QuestionAudio = GameObject.Find("QuestionAudio").GetComponent<Button>();
        current = PlayerPrefs.GetInt("TotalScore");
        if (keyLog == 0)
        {
            index = randomPos(index);
        }
       
        if (index[keyLog] <= 2)
        {
            answer = true;
        }
        else
        {
            answer = false;
        }
        questions[index[keyLog]].SetActive(true);

        QuestionAudio.onClick.AddListener(() => questionButton());
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
       
	}
    public void next()
    {
        
      SceneManager.LoadScene("Main Menu");

    }
    void Computation()
    {
        PlayerPrefs.SetString(PlayerPrefs.GetString(result), "done");

        TotalScore = (Score*2) + current;
        TotalScore = TotalScore / 5;
        PlayerPrefs.SetInt("TotalScore", TotalScore);
        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " Patterns", Score*2);
        /*  Debug.Log("Colors ="+PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Colors"));
          Debug.Log("Shapes ="+PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Shapes"));
          Debug.Log("Sizes ="+PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Sizes"));
          Debug.Log("Sets ="+PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Sets"));  */
        Debug.Log("Patterns ="+PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " Patterns"));
     
    }
    IEnumerator LoseTime()  //Timer Function
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

    }

    public void questionButton()
    {
        SoundFx.PlayOneShot(QuestionPatterns);
    }

    public void YesBTN()
    {
        questions[index[keyLog]].SetActive(false);
        keyLog++;
        if (answer == true)
        {
            Score++;

   
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
        else if(keyLog==5)
        {
            Computation();
            while (number != Score*2)
            {
            Stars[number].SetActive(true);

            number++;
             }
        }

        if (TimerLimit == false)
        {
            StartCoroutine("LoseTime");
            TimerLimit = true;
        }
    
    }
    public void NoBTN()
    {
        questions[index[keyLog]].SetActive(false);
        keyLog++;
        if (answer == false)
        {
            Score++;
         
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
        else if (keyLog == 5)
        {
            Computation();
            while (number != Score*2)
            {
                Stars[number].SetActive(true);
                number++;
            }
        }

        if (TimerLimit == false)
        {
            StartCoroutine("LoseTime");
            TimerLimit = true;
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
}
