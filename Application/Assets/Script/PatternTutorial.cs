using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatternTutorial : MonoBehaviour {
    [SerializeField]
    private Transform DropPoint;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    string result;
    string shape;
    public GameObject Star;
    public GameObject Board;
    public GameObject[] Circles;
    public GameObject[] Stars;
    public GameObject[] SGuide;
    public GameObject[] LGuide;
    public GameObject[] DropEffect;
    private Vector2 mousePosition;
    public string TagName;
    public static string answer;
    int[] YPosition = { 26, -64 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    public static int keyLog;
    public GameObject ScoreBoard;
    public GameObject PanelBoard;
    public static int myScore;
    public static bool locked;
    
    string value;
   
    void Start()
    {

        initialPosition = transform.position;
        //  TagName = PatternOne.TagName;

    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        locked = false;

    }
    public void Done()
    {
        SceneManager.LoadScene("DragTry");
    }
    public void Retry()
    {
        StartCoroutine("RestartGame");
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
                    answer = GetComponent<Collider2D>().tag;

       
                    if (answer == "DrawBlue")
                    {
                        SGuide[0].SetActive(true);
                        LGuide[0].SetActive(true);
           
                    }
                    else if (answer == "DrawBrown")
                    {
                        SGuide[1].SetActive(true);
                        LGuide[2].SetActive(true);
                    }
                    else if (answer == "DrawGreen")
                    {
                        SGuide[2].SetActive(true);
                        LGuide[4].SetActive(true);
                    }

                    if (answer == "DrawOrange")
                    {
                        SGuide[3].SetActive(true);
                        LGuide[1].SetActive(true);
     
                    }
                    else if (answer == "DrawRed")
                    {
                        SGuide  [4].SetActive(true);
                        LGuide[3].SetActive(true);
                    }
                    else if (answer == "DrawViolet")
                    {
                        SGuide[5].SetActive(true);
                        LGuide[5].SetActive(true);
                    }
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
                    if (answer == "DrawBlue")
                        {
                            SGuide[0].SetActive(false);
                            LGuide[0].SetActive(false);
                            DropEffect[0].SetActive(false);
                        }
                        else if (answer == "DrawBrown")
                        {
                            SGuide[1].SetActive(false);
                            LGuide[2].SetActive(false);
                            DropEffect[2].SetActive(false);
                        }
                        else if (answer == "DrawGreen")
                        {
                            SGuide[2].SetActive(false);
                            LGuide[4].SetActive(false);
                            DropEffect[4].SetActive(false);
                        }

                        if (answer == "DrawOrange")
                        {
                            SGuide[3].SetActive(false);
                            LGuide[1].SetActive(false);
                            DropEffect[2].SetActive(false);
                        }
                        else if (answer == "DrawRed")
                        {
                            SGuide[4].SetActive(false);
                            LGuide[3].SetActive(false);
                            DropEffect[4].SetActive(false);
                        }
                        else if (answer == "DrawViolet")
                        {
                            SGuide[5].SetActive(false);
                            LGuide[5].SetActive(false);
                            DropEffect[5].SetActive(false);
                        }
                    if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 0.5f &&

                    Mathf.Abs(transform.position.y - DropPoint.position.y) <= 0.5f)
                    {
                        if (answer == "DrawBlue")
                        {

                            Stars[0].SetActive(true);

                        }
                        else if (answer == "DrawBrown")
                        {

                            Stars[1].SetActive(true);

                        }
                        else if (answer == "DrawGreen")
                        {

                            Stars[2].SetActive(true);

                        }

                        if (answer == "DrawOrange")
                        {

                            Circles[1].SetActive(true);

                        }
                        else if (answer == "DrawRed")
                        {

                            Circles[2].SetActive(true);

                        }
                        else if (answer == "DrawViolet")
                        {
                            Circles[2].SetActive(true);
                            Board.SetActive(true);

                        }
                        keyLog++;
                        transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
                        locked = true;
                        answer = GetComponent<Collider2D>().tag;

                        locked = false;


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
        answer = GetComponent<Collider2D>().tag;

       
        if (answer == "DrawBlue")
        {
            SGuide[0].SetActive(true);
            LGuide[0].SetActive(true);
           
        }
        else if (answer == "DrawBrown")
        {
            SGuide[1].SetActive(true);
            LGuide[2].SetActive(true);
        }
        else if (answer == "DrawGreen")
        {
            SGuide[2].SetActive(true);
            LGuide[4].SetActive(true);
        }

        if (answer == "DrawOrange")
        {
            SGuide[3].SetActive(true);
            LGuide[1].SetActive(true);
     
        }
        else if (answer == "DrawRed")
        {
            SGuide  [4].SetActive(true);
            LGuide[3].SetActive(true);
        }
        else if (answer == "DrawViolet")
        {
            SGuide[5].SetActive(true);
            LGuide[5].SetActive(true);
        }
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
        if (answer == "DrawBlue")
        {
            SGuide[0].SetActive(false);
            LGuide[0].SetActive(false);
            DropEffect[0].SetActive(false);
        }
        else if (answer == "DrawBrown")
        {
            SGuide[1].SetActive(false);
            LGuide[2].SetActive(false);
            DropEffect[2].SetActive(false);
        }
        else if (answer == "DrawGreen")
        {
            SGuide[2].SetActive(false);
            LGuide[4].SetActive(false);
            DropEffect[4].SetActive(false);
        }

        if (answer == "DrawOrange")
        {
            SGuide[3].SetActive(false);
            LGuide[1].SetActive(false);
            DropEffect[2].SetActive(false);
        }
        else if (answer == "DrawRed")
        {
            SGuide[4].SetActive(false);
            LGuide[3].SetActive(false);
            DropEffect[4].SetActive(false);
        }
        else if (answer == "DrawViolet")
        {
            SGuide[5].SetActive(false);
            LGuide[5].SetActive(false);
            DropEffect[5].SetActive(false);
        }
        if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 0.5f &&
         Mathf.Abs(transform.position.y - DropPoint.position.y) <= 0.5f)
        {

            if (answer == "DrawBlue")
            {
               
                Stars[0].SetActive(true);
              
            }
            else if (answer == "DrawBrown")
            {
                
                Stars[1].SetActive(true);
              
            }
            else if (answer == "DrawGreen")
            {
              
                Stars[2].SetActive(true);
            
            }

            if (answer == "DrawOrange")
            {
                
                Circles[1].SetActive(true);
              
            }
            else if (answer == "DrawRed")
            {
               
                Circles[2].SetActive(true);
             
            }
            else if (answer == "DrawViolet")
            {
                Circles[2].SetActive(true);
                Board.SetActive(true);
                
            }
            keyLog++;
            transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
            locked = true;
            answer = GetComponent<Collider2D>().tag;
           
            locked = false;
           
            

        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);

        }


    }
    IEnumerator ScoreWindow()
    {
        int b = 0, c = 0;
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
