using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DragObject : MonoBehaviour {
    [SerializeField]
    private Transform DropPoint;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    string result;
    string shape;
    public GameObject Star;
    private Vector2 mousePosition;
    public string TagName;
    public static string answer;
    int[] YPosition = {26,-64};
    int[] XPosition = { -143, -71, 0, 74, 146 };
    public static int keyLog;
    public GameObject ScoreBoard;
    public GameObject PanelBoard;
    public static int myScore;
    public static bool locked;
    string value;
   
	// Use this for initialization
	void Start () {

        initialPosition = transform.position;
      //  TagName = PatternOne.TagName;

	}
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
        if (keyLog != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("ScoreBoard");
        }

        locked = false;

    }
    public void Done()
    {
        SceneManager.LoadScene("Layout Activities Patterns");
    }
	// Update is called once per frame
   private void Update()
    {
        TagName = PatternOne.TagName;
   //   Debug.Log(PatternOne.TagName);
       
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
            if (keyLog != 2)
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
    IEnumerator ScoreWindow()
   {
       int b=0, c=0;
       yield return new WaitForSeconds(1);
       ScoreBoard.SetActive(true);
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
   }

}
