using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ColorsCategorySCR : MonoBehaviour {

	// Use this for initialization
    public int timeLeft = 20; //Seconds Overall
    public Text countdown; //UI Text Object
    public GameObject[] choice;
    public GameObject[] questions;
    public GameObject[] right;
    public Button QuestionAudio;
    public GameObject check;
    public GameObject wrong;
    public GameObject[] Stars;
    int[] FinalValue=new int[10];
    public GameObject ColorsCategory;
    public GameObject ShapesCategory;
    public GameObject ScoreWindow;
    public AudioSource SoundFx;
    public AudioClip CheckTone;
    public AudioClip WrongTone;
    public AudioClip QuestionColor;
    int count = 0;
    int number = 0;
    int answer;
    int keyLog = 0;
    int positionY = 50;
    int positionX = -150;
    int[] questionsIndex;
    int TotalScore, current;
    bool TimerLimit = false;
    bool loop = false;
    bool myAnswer;
    bool wAnswer;
    int[] PreChoice = new int[3];
    string result;
    string builder;
 	void Start () {

        myAnswer = false;
        check.SetActive(false);
        wrong.SetActive(false);
        wAnswer = false;
        QuestionAudio = GameObject.Find("QuestionAudio").GetComponent<Button>();

        int[] Positions = {62,-49,-159};
        int[] value = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] value2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 
        int[] ChoicesKey = new int[10];
        int[] Choices = new int[10];
        int[] test = new int[10];
       List<int> FinChoice = new List<int>();
       List<int> ConvertChoice;
       int[] Var = new int[10];
        int[] key;
        int[] FINAL;
        
        int a = 0;
        PlayerPrefs.DeleteKey("TotalScore");
    
        if (loop!=true)
        {
          FinalValue = randomPos(value);   // for choices to shuffle
          loop = true;
       
        }
        Choices = randomPos(value2); //for position to shuffle
        key = randomPos(Positions); // for choices position
      
            FinChoice.Add(FinalValue[keyLog]);
       // add right answer
        //Convert to string to remove right answer
        ConvertChoice = new List<int>(Choices);
        ConvertChoice.Remove(FinalValue[keyLog]);
        ChoicesKey = ConvertChoice.ToArray();
             while(a != 2){
              FinChoice.Add(ChoicesKey[a]);
              a++;
             }
       
             FINAL = FinChoice.ToArray();

               //remove previous Choices
             if (keyLog != 0)
             {
                 
          
                   questions[FinalValue[keyLog-1]].SetActive(false);
                 for (int y = 0; y != 3; y++)
                 {
                     for (int x = 0; x != 3; x++)
                     {
                         if (FINAL[y] != PreChoice[x])
                         {
                             choice[PreChoice[x]].SetActive(false);
                         }
                     }

                 }

             }
             
             for (int z = 0; z != 3; z++)
             {
                 Vector3 Temp = choice[FinChoice[z]].transform.localPosition;
                 Temp = new Vector3(227, key[z], 0);
                 choice[FinChoice[z]].SetActive(true);
                 choice[FinChoice[z]].transform.localPosition = Temp;
             }
          Vector3 Quest = questions[FinalValue[keyLog]].transform.position;
          Quest = new Vector3(-251, -50, 0);
          questions[FinalValue[keyLog]].transform.localPosition = Quest;
          questions[FinalValue[keyLog]].SetActive(true);
          answer = FinalValue[keyLog];
          PreChoice = FINAL;

        
        QuestionAudio.onClick.AddListener(() => questionButton());
	}

    IEnumerator PicDelay()
    {
        yield return new WaitForSeconds(1);
        if (keyLog != 10)
        {
            Start();
        }
       
    }
  
  IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
            
    }
    void Computation()
     {
         PlayerPrefs.SetInt("TotalScore",count);
         PlayerPrefs.GetString(result);
         PlayerPrefs.SetInt(PlayerPrefs.GetString(result)+" Colors",count);
        
     }
     
    void Update()
    {
     
      
      countdown.text = ("" + timeLeft);
        if (timeLeft <= 10)
        {
            countdown.color = Color.red;
         
        }
        if (timeLeft < 0)
        {
            ScoreWindow.SetActive(true);
            Computation();
    
        }
        if (keyLog == 10)
        {
            ScoreWindow.SetActive(true);
            Computation();
        }
        if (myAnswer == true)
        {
         
            Vector3 tempCheck = check.transform.localPosition;
            tempCheck = new Vector3(-228,-50, 0);
            check.SetActive(true);
            check.transform.localPosition = tempCheck;
        }
        if (wAnswer == true)
        {
            
            Vector3 tempWrong = wrong.transform.localPosition;
            tempWrong = new Vector3(-228, -50, 0);
            wrong.SetActive(true);
            wrong.transform.localPosition = tempWrong;
        }
       while (number != count)
        {
            Stars[number].SetActive(true);
            number++;
        }
  
    }

    public void next()
    {
        ColorsCategory.SetActive(false);
        ShapesCategory.SetActive(true);
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

    public void questionButton()
    {
        SoundFx.PlayOneShot(QuestionColor);
    }

   public void ChoiceOne()
   {

     
       if (answer == 0)
       {
           right[0].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);

        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
     
           StartCoroutine("PicDelay");
       
    
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
    
    
       keyLog++;
       
    
      



   }
   public void ChoiceTwo()
   {
       if (answer == 1)
       {
           right[1].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
       
           StartCoroutine("PicDelay");
     
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
    
       keyLog++;
      
       
      
   }
   public void ChoiceThree()
   {
       if (answer == 2)
       {
           right[FinalValue[keyLog]].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
      
           StartCoroutine("PicDelay");
    
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
    
       keyLog++;
      

    
   }
   public void ChoiceFour()
   {
       if (answer == 3)
       {
           right[3].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
      
           StartCoroutine("PicDelay");
      
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
    
       keyLog++;
  
   }
   public void ChoiceFive()
   {
       if (answer == 4)
       {
           right[4].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
      
           StartCoroutine("PicDelay");
      
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
    
   
       keyLog++;
   

     
   }
   public void ChoiceSix()
   {
       if (answer == 5)
       {
           right[5].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
      
           StartCoroutine("PicDelay");
      
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
       keyLog++;
   }
   public void ChoiceSeven()
   {
       if (answer == 6)
       {
           right[6].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
      
           StartCoroutine("PicDelay");
      
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
    

       keyLog++;
     
   }
   public void ChoiceEight()
   {
       if (answer == 7)
       {
           right[FinalValue[keyLog]].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
      
           StartCoroutine("PicDelay");
       
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
    
      
    
       keyLog++;
      
   }
   public void ChoiceNine()
   {
       if (answer == 8)
       {
           right[8].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }
     
           StartCoroutine("PicDelay");
   
       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }
    
       keyLog++;
   }
   public void ChoiceTen()
   {
       if (answer == 9)
       {
           right[9].SetActive(true);
           myAnswer = true;
           count++;

            SoundFx.PlayOneShot(CheckTone);
        }
       else
       {
           right[FinalValue[keyLog]].SetActive(true);
           wAnswer = true;

            SoundFx.PlayOneShot(WrongTone);
        }

       StartCoroutine("PicDelay");

       if (TimerLimit == false)
       {
           StartCoroutine("LoseTime");
           TimerLimit = true;
       }

       keyLog++;
   }
}
