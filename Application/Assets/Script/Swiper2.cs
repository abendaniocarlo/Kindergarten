using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper2 : MonoBehaviour {
    public GameObject Brush;
    public float BrushSize = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
          || Input.GetMouseButton(0)))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit))
            {
                //instanciate a brush
                var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize;
            }
        }
	}
}
