using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {
    public GameObject[] Lines;
    GameObject[] target;
   // public GameObject Hand;
    public GameObject Window;
    int Keylog = 0;
    private float deltaX, deltaY;
    public static bool locked;
    private Vector2 mousePosition;
   
    
    private float speed = 10f;
    private Rigidbody2D Controller;
    public Camera cam;
    
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }
    void Awake()
    {
        Controller = GetComponent<Rigidbody2D>();

    }
    void OnTriggerEnter2D(Collider2D target)
    {
        
        if (target.name == "Dots (" + Keylog + ")")
        {
            Destroy(GameObject.Find("Dots (" + Keylog + ")"));
             
            Lines[Keylog].SetActive(true);
            Keylog++;
        }
        
        Debug.Log("entered");
    }
    void FixedUpdate()
    {
     
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, rawPosition.y, 0.23f);
            Controller.MovePosition(targetPosition);
        }

        if (Keylog == 8)
        {
            StartCoroutine("ShowWindow");
        }
    }
    IEnumerator ShowWindow()
    {
        yield return new WaitForSeconds(1.5f);
        Window.SetActive(true);
        
        Destroy(GameObject.Find("SwipeTrail"));
       
        Destroy(GameObject.Find("hand"));

    }
 
  
}
