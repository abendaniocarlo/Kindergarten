using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracePicker : MonoBehaviour {
    string myShape;
    public GameObject[] ShapesPicker;
	// Use this for initialization
	void Start () {
        myShape = PlayerPrefs.GetString("ShapeIndex", "No Shape");
        if (myShape == "Shapes Activities")
        {
            ShapesPicker[0].SetActive(true);
        }
        else if (myShape == "Shapes Oblong")
        {
            ShapesPicker[1].SetActive(true);
        }
        else if (myShape == "Shapes Rectangle")
        {
            ShapesPicker[2].SetActive(true);
        }
        else if (myShape == "Shapes Square")
        {
            ShapesPicker[3].SetActive(true);
        }
        else if (myShape == "Shapes Triangle")
        {
            ShapesPicker[4].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
