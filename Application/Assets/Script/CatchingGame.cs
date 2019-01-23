using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingGame : MonoBehaviour {

	// Use this for initialization
    private float speed = 10f;
    private Rigidbody2D Owly;

	void Awake () {
        Owly = GetComponent<Rigidbody2D>();
	}
   /* void Update()
    {
        if (Input.touchCount > 0 && 
       Input.GetTouch(0).phase == TouchPhase.Moved) {
     
         // Get movement of the finger since last frame
         var touchDeltaPosition Vector2 = Input.GetTouch(0).deltaPosition;
         
         // Move object across XY plane
         transform.Translate (-touchDeltaPosition.x * speed, 
                     -touchDeltaPosition.y * speed, 0);
     }
    }*/
 
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 myVel = Owly.velocity;
        myVel.x = Input.GetAxis("Horizontal") * speed;
        Owly.velocity = myVel;
	}
}
