using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SizesCategorySCR : MonoBehaviour {
    public GameObject[] Small;
    public GameObject[] Medium;
    public GameObject[] Biggest;
    public GameObject[] Stars;
    public GameObject SizesCategory;
    public GameObject SetsCategory;
    public GameObject ScoreWindow;
    public AudioSource SoundFx;
    public AudioClip CheckTone;
    public AudioClip WrongTone;
    public Button QuestionAudio;
    public AudioClip QuestionSizes;
    int TotalScore, current;
    int[] Indexes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] myIndex = { -320, 0, 320 };
    int myKey;
    int[] key = { -200, 0, 200 };
    int keyLog = 0;
    int total;
    int FinTotal;
    int number = 0;
    string result;
    bool TimerLimit = false;
   public int timeLeft = 20; //Seconds Overall
    public Text countdown; //UI Text Object
	void Start () {
        QuestionAudio = GameObject.Find("QuestionAudio").GetComponent<Button>();

        if (keyLog <= 9)
        {
            myKey = 0;
            if (keyLog == 0)
            {
                Indexes = randomPos(Indexes);
                current = PlayerPrefs.GetInt("TotalScore");
            }

            key = randomPos(key);
            if (keyLog != 0)
            {
                Small[Indexes[keyLog - 1]].SetActive(false);
                Medium[Indexes[keyLog - 1]].SetActive(false);
                Biggest[Indexes[keyLog - 1]].SetActive(false);
            }
            Vector3 Temp = Small[Indexes[keyLog]].transform.localPosition;
            Temp = new Vector3(key[0], 100, 0);
            Small[Indexes[keyLog]].SetActive(true);
            Small[Indexes[keyLog]].transform.localPosition = Temp;

            Vector3 Temp2 = Medium[Indexes[keyLog]].transform.localPosition;
            Temp2 = new Vector3(key[1], 100, 0);
            Medium[Indexes[keyLog]].SetActive(true);
            Medium[Indexes[keyLog]].transform.localPosition = Temp2;

            Vector3 Temp3 = Biggest[Indexes[keyLog]].transform.localPosition;
            Temp3 = new Vector3(key[2], 100, 0);
            Biggest[Indexes[keyLog]].SetActive(true);
            Biggest[Indexes[keyLog]].transform.localPosition = Temp3;

        }

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
	// Update is called once per frame
	void Update () {
        countdown.text = ("" + timeLeft);
        if (timeLeft <= 10)
        {
            countdown.color = Color.red;

        }
        if (timeLeft < 0)
        {
            ScoreWindow.SetActive(true);
        }
        if (keyLog == 10)
        {
            ScoreWindow.SetActive(true);
        
            FinTotal = total / 3;

        }
        while (number != FinTotal)
        {
            Stars[number].SetActive(true);
            number++;
        }
      
	}
    public void next()
    {
        SizesCategory.SetActive(false);
        SetsCategory.SetActive(true);
     
            TotalScore = current + FinTotal;
            PlayerPrefs.SetInt("TotalScore", TotalScore);
            PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " Sizes", FinTotal);
       
    }

    public void questionButton()
    {
        SoundFx.PlayOneShot(QuestionSizes);
    }

    public void SmallBTN()
    {
        Vector3 Sm = Small[Indexes[keyLog]].transform.localPosition;
        Sm = new Vector3(myIndex[myKey], -170, 0);
        Small[Indexes[keyLog]].SetActive(true);
        Small[Indexes[keyLog]].transform.localPosition = Sm;

        if (myKey == 0)
        {
            total++;

            SoundFx.PlayOneShot(CheckTone);
        }
        else {
            SoundFx.PlayOneShot(WrongTone);
        }
        myKey++;
        if (myKey == 3)
        {
            keyLog++;
            Start();
            
        }

        if (TimerLimit == false)
        {
            StartCoroutine("LoseTime");
            TimerLimit = true;
        }
    

    }
    public void MediumBTN()
    {
        Vector3 Temp3 = Medium[Indexes[keyLog]].transform.localPosition;
        Temp3 = new Vector3(myIndex[myKey], -170, 0);
        Medium[Indexes[keyLog]].SetActive(true);
        Medium[Indexes[keyLog]].transform.localPosition = Temp3;

        if (myKey == 1)
        {
            total++;
            SoundFx.PlayOneShot(CheckTone);
        }
        else
        {
            SoundFx.PlayOneShot(WrongTone);
        }
        myKey++;
        if (myKey == 3)
        {
            keyLog++;
            Start();

        }

        if (TimerLimit == false)
        {
            StartCoroutine("LoseTime");
            TimerLimit = true;
        }
    

    }
    public void BigBTN()
    {
        Vector3 Temp3 = Biggest[Indexes[keyLog]].transform.localPosition;
        Temp3 = new Vector3(myIndex[myKey], -170, 0);
        Biggest[Indexes[keyLog]].SetActive(true);
        Biggest[Indexes[keyLog]].transform.localPosition = Temp3;
    
        if (myKey == 2)
        {
            total++;
            SoundFx.PlayOneShot(CheckTone);
        }
        else
        {
            SoundFx.PlayOneShot(WrongTone);
        }
        myKey++;
        if (myKey == 3)
        {
            keyLog++;
            Start();
           
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
