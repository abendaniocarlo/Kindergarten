using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBounds : MonoBehaviour {
    private float minX, maxX;
	// Use this for initialization
	void Start () {
        Vector3 cor = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        minX = -cor.x + 0.8f;
        maxX = cor.x - 0.8f;
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
            temp.x = maxX;

        if (temp.x < minX)
            temp.x = minX;

        transform.position = temp;
	}
}
