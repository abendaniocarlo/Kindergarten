using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MatchController : MonoBehaviour {
    [SerializeField]
    private Transform DropPoint;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    public static string answer;
    private Vector2 mousePosition;
    public string TagName;
    public static int myScore;
    public GameObject ScoreBoard;
    public GameObject PanelBoard;
    int[] YPosition = { 26, -64 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    int keyLog;
    public GameObject Star;
	// Use this for initialization
	void Start () {
        initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        TagName = ShapeMatch.myTag;
       
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {

                        deltaX = touchPos.x - transform.position.x;

                        deltaY = touchPos.y - transform.position.y;

                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {

                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 0.5f &&

                    Mathf.Abs(transform.position.y - DropPoint.position.y) <= 0.5f)
                    {
                        locked = true;
                       ShapeMatch.keyLog++;
                        transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
                       
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
                        if (ShapeMatch.keyLog != 10)
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
                    break;


            }



        }
	}
    private void OnMouseDown()
    {
        
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
        if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 0.5f &&
         Mathf.Abs(transform.position.y - DropPoint.position.y) <= 0.5f)
        {

            ShapeMatch.keyLog++;
           transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
           locked = true;
           answer = GetComponent<Collider2D>().tag;
           Debug.Log(answer);
           Debug.Log(TagName);
           if (answer == TagName)
           {
               myScore++;
               Debug.Log(myScore);
           }
           else
           {
               Debug.Log("Wrong");
           }
           if (ShapeMatch.keyLog != 2)
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
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
        keyLog = ShapeMatch.keyLog;
        if (keyLog != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            //PlayerPrefs.SetInt(PlayerPrefs.GetString(result) + " " + DragOne, myScore);
            Debug.Log("ScoreBoard");
        }

        locked = false;

    }
    IEnumerator ScoreWindow()
    {
        int b = 0, c = 0;
        yield return new WaitForSeconds(1);
        ScoreBoard.SetActive(true);
        for (int a = 0; a < myScore; a++)
        {
            yield return new WaitForSeconds(.3f);
            var createImage = Instantiate(Star, new Vector3(XPosition[b], YPosition[c], 0), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(PanelBoard.transform, false);
            b++;
          
            if (a == 4)
            {
                b = 0;
                c++;
            }
        }
    }
}
