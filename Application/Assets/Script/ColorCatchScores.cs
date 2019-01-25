using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ColorCatchScores : MonoBehaviour {
    private Text TextScore;
    public GameObject[] CatchObj;
    private int score = 0;
    private string[] myObj = { "DrawBlue", "DrawBrown", "DrawOrange", "DrawRed", "DrawYellow", "DrawGreen", "DrawPink" };
    string Shape;
    bool temp = true;
    int KeyLog = 0;
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
            }
            if (KeyLog < 7) {
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
        Debug.Log(Shape);
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
}
