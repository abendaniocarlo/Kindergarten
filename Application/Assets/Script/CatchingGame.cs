using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingGame : MonoBehaviour {

	// Use this for initialization
    private float speed = 10f;
    private Rigidbody2D Owly;
    public Camera cam;
    void Start()
    {
        Time.timeScale = 1f;
        if (cam == null)
        {
            cam = Camera.main;
        }
    }
	void Awake () {
        Owly = GetComponent<Rigidbody2D>();
	}
 
 
	// Update is called once per frame
	void FixedUpdate () {
       /*Vector2 myVel = Owly.velocity;
        myVel.x = Input.GetAxis("Horizontal") * speed;
        Owly.velocity = myVel;*/
        if (Input.GetMouseButton(0))
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, -7.61f, 0.23f);
            Owly.MovePosition(targetPosition);
        }
      
      
	}
}
