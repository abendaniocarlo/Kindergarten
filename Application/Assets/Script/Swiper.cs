using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Swiper : MonoBehaviour {

    public GameObject[] trailPrefab;
    public GameObject[] Images;
    public GameObject nextBTN;
    public GameObject Final;
    public GameObject DoneBtn;
    public GameObject[] FinalImg;
    GameObject thisTrail;
    Vector3 startPos;
    Plane objPlane;
    int KeyLog = 0;
    string myName;
    void Start()
    {
      
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
        DoneBtn.SetActive(true);
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
        Final.SetActive(false);
        FinalImg[KeyLog].SetActive(false);
        Images[KeyLog].SetActive(false);
        trailPrefab[KeyLog].SetActive(false);
        if (KeyLog == 0)
        {
            
            myName = "DrawBlue";
        }
        else if (KeyLog == 1)
        {
            myName = "DrawBrown";
        }
        else if (KeyLog == 2)
        {
            myName = "DrawGreen";
        }
        else if (KeyLog == 3)
        {
            myName = "DrawOrange";
        }
        else if (KeyLog == 4)
        {
            myName = "DrawRed";
        }
        else if (KeyLog == 5)
        {
            myName = "DrawViolet";
        }
        else if (KeyLog == 6)
        {
            myName = "DrawYellow";
        }
        
        foreach (GameObject gos in GameObject.FindGameObjectsWithTag(myName))
        {
            if (gos.name == myName+"(Clone)")
            {
                Destroy(gos);
            }
        }
        
      
        KeyLog++;
        if (KeyLog != 7)
        {
            Start();

        }

    }
    public void Done()
    {
        Final.SetActive(true);
        FinalImg[KeyLog].SetActive(true);
        DoneBtn.SetActive(false);
    }
    public void BackBTN()
    {
        SceneManager.LoadScene("Colors Activities");
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
