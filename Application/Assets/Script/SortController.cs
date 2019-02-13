using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortController : MonoBehaviour {
    [SerializeField]
   // private Transform DropPoint;
    public GameObject[] myObject;
    public int[] setIndex = { 0, 1, 2, 3, 4 };
    public int KeyLog;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    public static string answer;
    private Vector2 mousePosition;
    public string TagName;
 	// Use this for initialization
	void Start () {
        setIndex = randomPos(setIndex);
        initialPosition = transform.position;
          // Instantiate(myObject[setIndex[KeyLog]], new Vector3(0, -3.7f, 0), transform.rotation);
        
      ;
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
                    //if (Mathf.Abs(transform.position.x - DropPoint.position.x) <= 0.5f &&

                    //Mathf.Abs(transform.position.y - DropPoint.position.y) <= 0.5f)
                    //{
                    //    locked = true;
                    //    transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
                    //}

                    //else
                    //{
                    //    transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    //}
                    break;


            }



        }
	}
    private void OnMouseDown()
    {

        answer = GetComponent<Collider2D>().tag;
        
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
        Debug.Log(mousePosition); 
    }

    private void OnMouseUp()
    {
        if (Input.mousePosition.x < GetComponent<Collider2D>().)
        {

         
            transform.position = new Vector2(mousePosition.x, Input.mousePosition.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);

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
