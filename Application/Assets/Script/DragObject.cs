using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
    [SerializeField]
    private Transform DropPoint;
    private Vector2 InitialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    string value;
	// Use this for initialization
	void Start () {
        InitialPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
     
            value = PatternOne.TagName;
        
        Debug.Log(value);
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
  
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x = transform.position.x;
                        deltaY = touchPos.y = transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;
                case TouchPhase.Ended:
                    if(Mathf.Abs(transform.position.x - DropPoint.position.x)<=0.5f &&
                        Mathf.Abs(transform.position.y - DropPoint.position.x)<=0.5f)
                    {
                        transform.position = new Vector2(DropPoint.position.x, DropPoint.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(InitialPosition.x, InitialPosition.y);
                    }
                    break;

            }
        }
	}
}
