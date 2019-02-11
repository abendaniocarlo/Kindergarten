using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {
    Vector3[] Position = new Vector3[5]; 
    GameObject[] target;
    int Keylog = 0;
    
    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;
    bool checker = false;
    int key=0;
    //List<int> index = new List<int>();
    void Start()
    {
        if (key!= 0)
        {
            Keylog++;
            Debug.Log("ss");
            key = 0;
        }
        
        target = GameObject.FindGameObjectsWithTag("Dots");
        Debug.Log(target.Length);
        foreach (GameObject temp in target)
        {
            Position[Keylog] = temp.transform.localPosition;
            Debug.Log(Position[Keylog]);    
            Keylog++;
           
        }
         
         
         //   Debug.Log("Dots (" + Keylog + ")");
      
   
 //       Debug.Log(Position);
    }
    void Update()
    {
        



        //if (Input.GetMouseButton(0) && Mathf.Abs(Input.mousePosition.x) - Mathf.Abs(Position.x) < 3 && Mathf.Abs(Input.mousePosition.y) - Mathf.Abs(Position.y) < 3)
        //{
        //     Destroy(GameObject.Find("Dots (" + Keylog + ")"));
        //}

    }
    void OnMouseDown()
    {
        // load a new scene
        Debug.Log("SGIT");
    }
    void Controller()
    {
      
      
     
    }
  
}
