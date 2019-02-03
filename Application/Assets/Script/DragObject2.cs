using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DragObject2 : MonoBehaviour {

    [SerializeField]
    private Transform DropPoint;
    public GameObject[] Object1;
    public GameObject[] Object2;
    public GameObject[] FillMe;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    private Vector2 mousePosition;
    public static string answer;
    public string TagName;
    public static int myScore;
    public static bool locked;
    public static bool locked2;
    public static bool right;
    string value;
    int keyLog,key;
    
    // Use this for initialization
    void Start()
    {
        locked = false;
        initialPosition = transform.position;


    }
    IEnumerator RestartGame()
    {
        
        yield return new WaitForSeconds(1);
        right = false;
        if (keyLog != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("ScoreBoard");
        }

      
    }
    // Update is called once per frame
    private void Update()
    {
        TagName = PatternTwo.TagName;
        
       // Debug.Log(PatternOne.TagName);

        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                      foreach (GameObject temp in Object2)
                        {
                            temp.SetActive(true);
                        }
                        FillMe[0].SetActive(true);
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
                    FillMe[0].SetActive(false);
                    foreach (GameObject temp in Object1)
                    {
                        temp.SetActive(false);
                    }
                    if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 1 &&

                    Mathf.Abs(transform.position.y - DropPoint.position.y) <= 1)
                    {
                        keyLog++;
                        transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
                       // locked = true;
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
                        StartCoroutine("RestartGame");


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
      //  Debug.Log(PatternTwo.TagName);
             if (!locked)
            {
            foreach(GameObject temp in Object2){
                temp.SetActive(true);
            }
            FillMe[0].SetActive(true);
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
        if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 1.5f &&
         Mathf.Abs(transform.position.y - DropPoint.position.y) <= 1.5f)
        {
            //GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject temp in Object1)
            {
                if (temp.tag != GetComponent<Collider2D>().tag)
                {
                    temp.SetActive(false);
                }
            }
            transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
          //  locked = true;
            answer = GetComponent<Collider2D>().tag;
            if (answer == TagName)
            {
                //myScore++;
                right = true;
              //  Debug.Log(myScore);
            }
            else
            {
                Debug.Log("Wrong");
            }
         //   StartCoroutine("RestartGame");
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
            foreach (GameObject temp in Object2)
            {
                temp.SetActive(false);
            }
        }

    }
}
