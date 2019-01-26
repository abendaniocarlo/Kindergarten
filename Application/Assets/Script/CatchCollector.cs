using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCollector : MonoBehaviour {

	// Use this for initialization
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Square" || target.tag == "Rectangle" || target.tag == "Circle" || target.tag == "Oblong" || target.tag == "Triangle")
        {
            target.gameObject.SetActive(false);
        }
        if (target.tag == "DrawBlue" || target.tag == "DrawRed" || target.tag == "DrawYellow" || target.tag == "DrawPink" || target.tag == "DrawBrown" || target.tag == "DrawGreen" || target.tag == "DrawOrange")
        {
            target.gameObject.SetActive(false);
        }
    }
}
