using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {
    Vector3[] Position;
    GameObject[] target;
    int Keylog = 0;
    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;

    void Start()
    {
      
      
            Position[Keylog] = GameObject.FindWithTag("Dots"+Keylog).transform.position;
      
   
 //       Debug.Log(Position);
    }
    void Update()
    {
       // Debug.Log("s");
        if (Input.GetButton("Fire1"))
        {
          //  Debug.Log("s");
            if (Mathf.Abs(Input.mousePosition.x) - Mathf.Abs(Position[Keylog].x) < 10 && Mathf.Abs(Input.mousePosition.y) - Mathf.Abs(Position[Keylog].y) < 10)
            {
            Destroy(GameObject.FindWithTag("Dots"+Keylog));
            Keylog++;

            }
        

        }
    }
}
