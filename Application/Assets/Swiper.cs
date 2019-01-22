using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour {

    public GameObject[] trailPrefab;
    public GameObject[] Images;
    public GameObject nextBTN;
    GameObject thisTrail;
    Vector3 startPos;
    Plane objPlane;
    int KeyLog = 0;
    void Start()
    {
      
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);

        Images[KeyLog].SetActive(true);
        trailPrefab[KeyLog].SetActive(true);
       
    }


    void Update()
    {
    
    if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||
            Input.GetMouseButtonDown(0))
        {

            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
                startPos = mRay.GetPoint(rayDistance);
            thisTrail = (GameObject)Instantiate(trailPrefab[KeyLog],
                                                            startPos,
                                                        Quaternion.identity);
        }
        else if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            || Input.GetMouseButton(0)))
        {

            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
                thisTrail.transform.position = mRay.GetPoint(rayDistance);
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) ||
            Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(thisTrail.transform.position, startPos) < 0.1)
                Destroy(thisTrail);
        }
    }
    public void next()
    {
        
        Images[KeyLog].SetActive(false);
        trailPrefab[KeyLog].SetActive(false);
        foreach ( obj in trailPrefab[KeyLog])
        {
            Destroy(obj);
        }
      
        KeyLog++;
        Start();
       
     
    }
}
