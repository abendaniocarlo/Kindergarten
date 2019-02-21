using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ColorCatchScores : MonoBehaviour {
    private Text TextScore;
    public GameObject scorewindow;
    public GameObject spawnarea;
    public GameObject owlie;
    public GameObject[] CatchObj;
    private int score = 0;
    private string[] myObj = { "DrawBlue", "DrawBrown", "DrawOrange", "DrawRed", "DrawYellow", "DrawGreen", "DrawPink" };
    string Shape;
    bool temp = true;
    int KeyLog = 0;
    int count = 0;
    int number = 0;
    public GameObject[] Stars;
    float finalScore = 0;
    string result;
    void Start()
    {
        Shape = myObj[KeyLog];
    
        CatchObj[KeyLog].SetActive(true);
        //  StartCoroutine("myShape");
    }
    void Awake()
    {
        TextScore = GameObject.Find("ScoreText").GetComponent<Text>();
        TextScore.text = "0";
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        /*   if (target.tag !=  Shape)
           {
               transform.position = new Vector2(0, 100);
               target.gameObject.SetActive(false);
               StartCoroutine(RestartGame());
           }*/
        if (target.tag == Shape)
        {
            target.gameObject.SetActive(false);
            score++;
            if (score % 5 == 0)
            {
               
                KeyLog++;
                CatchObj[KeyLog].SetActive(true);
                CatchObj[KeyLog - 1].SetActive(false);
                Shape = myObj[KeyLog];
            //    Debug.Log(KeyLog);
            }
            if (KeyLog >= 7)
            {
                KeyLog = 0;

            }
            TextScore.text = score.ToString();
        }
        else
        {
            transform.position = new Vector2(0, 100);
            target.gameObject.SetActive(false);
            StartCoroutine(RestartGame());


        }

        if (score == 35)
            StartCoroutine(RestartGame());

  //      Debug.Log(Shape);
    }
    IEnumerator RestartGame()
    {
       
        yield return new WaitForSecondsRealtime(0);
        finalScore = score / 3.5f;
        owlie.SetActive(false);
        spawnarea.SetActive(false);
        scorewindow.SetActive(true);
      
    
        for (int x = 0; x != Mathf.RoundToInt(finalScore); x++)
        {
            yield return new WaitForSecondsRealtime(.3f);
            Stars[x].SetActive(true);
        }
        SaveScore();

      
        
    }
    void SaveScore()
    {
        int xx = 0, zz = 0;
        string current = System.DateTime.Now.ToString("MM/dd/yy");
        string myDate;
        int MGScore, test;
        float FGScore;
        bool MyBool = true;
        // myDate = "02/21/19";
        if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MCDate"))
        {
            //meron
            myDate = PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MCDate");
            // myDate = "02/21/19";
            MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + "MGColor");

            if (myDate == current)
            {

                Debug.Log("Nandito");
                while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGColor" + xx))
                {

                    Debug.Log("Nandito");
                    xx++;
                    if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGColor" + xx) == false)
                    {
                        MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGColor" + (xx - 1));
                        test = 20;
                        FGScore = (MGScore + test) / 2;
                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGColor" + (xx - 1), Mathf.RoundToInt(FGScore));
                    }

                }

            }
            else
            {

                xx = 0;
                while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGColor" + xx) || MyBool == false)
                {

                    MGScore = MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGcolor" + xx);
                    test = 10;
                    FGScore = (MGScore + test) / 2;
                    //   PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MGColor" + xx);

                    Debug.Log(FGScore);
                    xx++;
                    if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGColor" + xx) == false)
                    {
                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGColor" + xx, Mathf.RoundToInt(FGScore));
                        Debug.Log("nice");
                        MyBool = false;
                        break;
                    }
                }
            }

        }
        else
        {

            PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MCDate", current);
            PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGColor0", count);
        }

        xx = 0;

        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGColor" + xx))
        {

            Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGColor" + xx));
            xx++;
        }

    }
    void Update()
    {
        //    print(Shape);

    }

    /*IEnumerator myShape()
    {
       
       while(true){
            yield return new WaitForSeconds(5.0f);
            if (KeyLog >= 4)
            {
                KeyLog = 0;
            }

         
            Shape = myObj[Random.Range(0,4)];
            Debug.Log(Shape);
        }
    }*/

    public void backbtn()
    {
        SceneManager.LoadScene("Layout Games Colors");
    }
    public void retrybtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
