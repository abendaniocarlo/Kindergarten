using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatchScore : MonoBehaviour {

	// Use this for initialization
    private Text TextScore;
    public GameObject scorewindow;
    public GameObject spawnarea;
    public GameObject owlie;
    public GameObject[] CatchObj;
    private int score = 0;
    private string[] myObj = {"Circle","Triangle","Square","Rectangle","Oblong"};
    string Shape;
    bool temp = true;
    int KeyLog = 0;
    int count = 0;
    int number = 0;
    public GameObject[] Stars;
    float finalScore = 0;
    string result;
    void Start () {
        Shape = myObj[KeyLog];
        CatchObj[KeyLog].SetActive(true);
           //  StartCoroutine("myShape");
	}
    void Awake() {
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
                CatchObj[KeyLog-1].SetActive(false);
                Shape = myObj[KeyLog];
                
                
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

        if (score == 25)
            StartCoroutine(RestartGame());

       // Debug.Log(Shape);
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        finalScore = score / 2.5f;
        owlie.SetActive(false);
        spawnarea.SetActive(false);
        scorewindow.SetActive(true);
      //  int count = (int)finalScore;
        SaveScore();
        for (int x = 0; x != Mathf.RoundToInt(finalScore); x++)
            Stars[x].SetActive(true);
    }
    void SaveScore()
    {
        //  =myDate = "02/24";
        int xx = 0, zz = 0, d = 0;
       string current = System.DateTime.Now.ToString("MM/dd");
  //   string current = "02/24"; // test data
        string myDate;
        int MGScore, test;
        int FGScore;
        bool MyBool = true;

        if (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MSDate0"))
        {
            // Date EXIST!

            while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MSDate" + xx))
            {
                xx++;
                // get the last stored date
                if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MSDate" + xx))
                {

                    //check if its equal to current date

                    if (PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MSDate" + (xx - 1)) == current)
                    {
                        //Same date of exam  
                        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + zz))
                        {
                            // Get he last stored score for same date
                            zz++;

                            if (!PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MGShape" + zz))
                            {
                                MGScore = PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + (zz - 1));
                                //check which is higher
                                if (MGScore >= Mathf.RoundToInt(finalScore))
                                {
                                    FGScore = MGScore;
                                }
                                else
                                {
                                    FGScore = Mathf.RoundToInt(finalScore);
                                }
                                //set the score which is higher on two;
                                PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGShape" + (zz - 1), FGScore);

                            }
                        }

                    }
                    else
                    {
                        // not equal to current date

                        PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MSDate" + xx, current);
                        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGShape" + xx, Mathf.RoundToInt(finalScore));
                        break;
                    }
                }


            }
        }
        else
        {
            // No date & score yet
            Debug.Log("hey jude");
            PlayerPrefs.SetString(PlayerPrefs.GetString(result) + " MSDate0", current);
            PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " MGShape0", Mathf.RoundToInt(finalScore));
        }
        xx = 0;
        while (PlayerPrefs.HasKey(PlayerPrefs.GetString(result) + " MSDate" + xx))
        {

            //  PlayerPrefs.DeleteKey(PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MGShape" + xx));
            //    PlayerPrefs.DeleteKey(PlayerPrefs.GetString(result) + " MSDate" + xx);
            Debug.Log("S = " + xx + "---" + PlayerPrefs.GetString(PlayerPrefs.GetString(result) + " MSDate" + xx));
            Debug.Log("x = " + xx + "---" + PlayerPrefs.GetInt(PlayerPrefs.GetString(result) + " MGShape" + xx));
            xx++;
        }

    }

    public void backbtn()
    {
        SceneManager.LoadScene("Layout Games Shapes");

    }
    public void retrybtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
