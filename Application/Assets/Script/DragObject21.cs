using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DragObject21 : MonoBehaviour {
    [SerializeField]
    private Transform DropPoint;
    //public GameObject[] Object1;
    public GameObject[] FillMe;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    private Vector2 mousePosition;
    public static string answer;
    public string TagName;
    string result;
    public static bool locked;
  //  public static bool locked2;
    public static bool Unlock;
    string value;
    int key;
    int[] YPosition = { 26, -64 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    public static int keyLog;
    public GameObject ScoreBoard;
    public GameObject PanelBoard;
    public static int myScore;
    public GameObject Star;
    // Use this for initialization
    void Start()
    {

        initialPosition = transform.position;
      

    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
        locked = false;
    
        if (keyLog != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            //PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " " + DragTwo, myScore);
            Debug.Log("ScoreBoard");
        }

       
       
    }
    // Update is called once per frame
    private void Update()
    {
        TagName = PatternTwo.TagName;
        //   Debug.Log(PatternOne.TagName);

        //if (Input.touchCount > 0 && !locked)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            FillMe[0].SetActive(true);
        //            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
        //            {

        //                deltaX = touchPos.x - transform.position.x;

        //                deltaY = touchPos.y - transform.position.y;

        //            }
        //            break;

        //        case TouchPhase.Moved:
        //            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
        //            {

        //                transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
        //            }
        //            break;
        //        case TouchPhase.Ended:
        //            FillMe[0].SetActive(false);
        //            if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 2 &&

        //            Mathf.Abs(transform.position.y - DropPoint.position.y) <= 2)
        //            {
        //                keyLog++;
        //                transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
        //                locked = true;
        //                answer = GetComponent<Collider2D>().tag;
        //                if (answer == TagName)
        //                {
        //                    myScore++;
        //                    Debug.Log(myScore);
        //                }
        //                else
        //                {
        //                    Debug.Log("Wrong");
        //                }
        //                if (keyLog != 10)
        //                {
        //                    StartCoroutine("RestartGame");
        //                }
        //                else
        //                {

        //                    StartCoroutine("ScoreWindow");
        //                }
        //            }

        //            else
        //            {
        //                transform.position = new Vector2(initialPosition.x, initialPosition.y);
        //            }
        //            break;


        //    }



        //}
    }
    private void OnMouseDown()
    {
        FillMe[0].SetActive(true);
        if (!locked)
        {

            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        FillMe[0].SetActive(false);
        if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 2 &&
         Mathf.Abs(transform.position.y - DropPoint.position.y) <= 2)
        {

            keyLog++;

            transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
                locked = true;
            answer = GetComponent<Collider2D>().tag;
            if (answer == TagName)
            {
                myScore++;
                Debug.Log(myScore);
            }
            else
            {
                Debug.Log("Wrong");
            }
            if (keyLog != 10)
            {
                StartCoroutine("RestartGame");
            }
            else
            {

                StartCoroutine("ScoreWindow");
            }

        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);

        }

    }
    public void Done()
    {
        SceneManager.LoadScene("Layout Activities Patterns");
        locked = false;
        
    }
    IEnumerator ScoreWindow()
    {
        int b = 0, c = 0;
        yield return new WaitForSeconds(1);
        ScoreBoard.SetActive(true);
        PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " PatternTwo", myScore);
        for (int a = 0; a < myScore; a++)
        {
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
        keyLog = 0;
        locked = false;
    }
}
