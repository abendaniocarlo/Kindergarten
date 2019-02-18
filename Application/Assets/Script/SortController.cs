using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortController : MonoBehaviour {
    [SerializeField]
   // private Transform DropPoint;
    public GameObject[] myObject;
  //  public GameObject[] Camel;
    Transform Parent;
    public GameObject[] Objects;
    public GameObject[] setObjects;
    public GameObject[] Boxes;
    
    public int[] setIndex = { 0, 1, 2, 3, 4 };
    public int KeyLog;
    int myIndex;
    int Camel;
    int Elephant;
    int Walrus;
    int Lion;
    int Count;
    int donkey;
    int current;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    public static string answer;
    private Vector2 mousePosition;
    public static string TagName;
    int number = 0;
    int Animal;
    int[] PositionY = { 134, 75, 9, -57, -125 };
    public static Rigidbody2D Controller;
    
 	// Use this for initialization
	void Start () {

        setIndex = randomPos(setIndex);
        initialPosition = transform.position;

      
	}
    //void OnTriggerEnter2D(Collider2D target)
    //{
    //    ////Debug.Log(Controller.tag);
    //    ////Debug.Log(target.tag);
    //    //if (target.tag == Controller.tag)
    //    //{
    //    //    Destroy(Controller.gameObject);
    //    //    locked = true;
    //    //}
        

      
    //}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            //foreach (GameObject Temp in GameObject.FindGameObjectsWithTag("Bomb"))
            //{
            //    Destroy(Temp);
            //}
        }
       
        if (Count == 20)
        {
            Debug.Log("Desigh Here");
        }
        if (Input.touchCount > 0 && !locked)
        {
           
            Controller = GetComponent<Rigidbody2D>();
            TagName = GetComponent<Rigidbody2D>().tag;
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                     answer = GetComponent<Collider2D>().tag;
                     Controller = GetComponent<Rigidbody2D>();
                    TagName = GetComponent<Rigidbody2D>().tag;
              
                    // Parent = GameObject.Find("Panel").transform;
                    //if (Controller.tag == "Camel")
                    //{

                    //  GameObject InstantiatedGameObject =  Instantiate(Boxes[0], new Vector3(-6.5f, 0, 0), transform.rotation);
                    //  InstantiatedGameObject.transform.SetParent(Parent);   
          
                    //}
                    //else if (Controller.tag == "Donkey")
                    //{

                    //    GameObject InstantiatedGameObject = Instantiate(Boxes[1], new Vector3(-3, 0, 0), transform.rotation);
                    //    InstantiatedGameObject.transform.SetParent(Parent);
                    //}
                    //else if (Controller.tag == "Elephant")
                    //{
                    //    GameObject InstantiatedGameObject = Instantiate(Boxes[2], new Vector3(1f, 0, 0), transform.rotation);
                    //    InstantiatedGameObject.transform.SetParent(Parent);
          
                    //}
                    //else if (Controller.tag == "Lion")
                    //{

                    //    GameObject InstantiatedGameObject = Instantiate(Boxes[3], new Vector3(3.7f, 0, 0), transform.rotation);
                    //    InstantiatedGameObject.transform.SetParent(Parent);
                    //}
                    //else if (Controller.tag == "Walrus")
                    //{

                    //    GameObject InstantiatedGameObject = Instantiate(Boxes[4], new Vector3(6.5f, 0, 0), transform.rotation);
                    //    InstantiatedGameObject.transform.SetParent(Parent);
                    //}
                
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
                    //foreach (GameObject Temp in GameObject.FindGameObjectsWithTag("Bomb"))
                    //{
                    //    Destroy(Temp);
                    //}
                    if (!locked)
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    else
                    {
                        locked = false;
                        number++;
                    }
                    break;


            }



        }
	}
    void OnTriggerEnter2D(Collider2D target)
    {
     if(target.tag == Controller.tag)
     {
        // locked = true;
             
         if (Controller.tag == "Camel")
         {
             Animal = 0;
             current =Camel;
             Camel++;
             
          
         }
         if (Controller.tag == "Donkey")
         {
             Animal = 1;
             current = donkey;
             donkey++;
             
            
         }
         if (Controller.tag == "Elephant")
         {
             Animal = 2;
             current = Elephant;
             Elephant++;
           
         
         }
         if (Controller.tag == "Lion")
         {
             Animal = 3;
            
             current = Lion;
             Lion++;
            
         }
         if (Controller.tag == "Walrus")
         {
             Animal = 4;
             current = Walrus;
             Walrus++;
        
         
         }
         var createImage = Instantiate(setObjects[Animal], new Vector3(0, PositionY[current], 5), Quaternion.identity) as GameObject;
         createImage.transform.SetParent(GameObject.Find(Controller.tag+"Drp").transform, false);
         //Instantiate(myObject[0], new Vector3(0, -4.3f, 0), transform.rotation);
     }


    }
 
    private void OnMouseDown()
    {

        answer = GetComponent<Collider2D>().tag;
        Controller = GetComponent<Rigidbody2D>();
        TagName = GetComponent<Rigidbody2D>().tag;
        Parent = GameObject.Find("Panel").transform;
        //if (Controller.tag == "Camel")
        //{

        //  GameObject InstantiatedGameObject =  Instantiate(Boxes[0], new Vector3(-6.5f, 0, 0), transform.rotation);
        //  InstantiatedGameObject.transform.SetParent(Parent);   
          
        //}
        //else if (Controller.tag == "Donkey")
        //{

        //    GameObject InstantiatedGameObject = Instantiate(Boxes[1], new Vector3(-3, 0, 0), transform.rotation);
        //    InstantiatedGameObject.transform.SetParent(Parent);
        //}
        //else if (Controller.tag == "Elephant")
        //{
        //    GameObject InstantiatedGameObject = Instantiate(Boxes[2], new Vector3(1f, 0, 0), transform.rotation);
        //    InstantiatedGameObject.transform.SetParent(Parent);
          
        //}
        //else if (Controller.tag == "Lion")
        //{

        //    GameObject InstantiatedGameObject = Instantiate(Boxes[3], new Vector3(3.7f, 0, 0), transform.rotation);
        //    InstantiatedGameObject.transform.SetParent(Parent);
        //}
        //else if (Controller.tag == "Walrus")
        //{

        //    GameObject InstantiatedGameObject = Instantiate(Boxes[4], new Vector3(6.5f, 0, 0), transform.rotation);
        //    InstantiatedGameObject.transform.SetParent(Parent);
        //}
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
       
        //Debug.Log(mousePosition); 
    }

   private void OnMouseUp()
    {
       
        if (!locked)
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
        else
        {
            locked = false;
            number++; 
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
