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
    public GameObject Game;
 
    GameObject thisTrail;
    Vector3 startPos;
    string myColor;
    Plane objPlane;
    public static int KeyLog;
    public static int State=0;
    string myName;
    string ColorIndex1;
   public static int trail;
    void Start()
    {
        
        nextBTN.SetActive(false);
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
        DoneBtn.SetActive(true);
       
        myColor = PlayerPrefs.GetString("ColorIndex1","No Color");
        if (State == 0)
        {


            if (myColor == "Colors Activities")
            {

                KeyLog = 0;
                trail = 0;
            }
            else if (myColor == "Colors Brown")
            {

                KeyLog = 3;
                trail = 1;
            }
            else if (myColor == "Colors Green")
            {

                KeyLog = 6;
                trail = 2;
            }
            else if (myColor == "Colors Orange")
            {

                KeyLog = 9;
                trail = 3;
            }
            else if (myColor == "Colors Pink")
            {

                KeyLog = 12;
                trail = 4;
            }
            else if (myColor == "Colors Red")
            {

                KeyLog = 15;
                trail = 5;
            }
            else if (myColor == "Colors Yellow")
            {

                KeyLog = 18;
                trail =6;
            }
            else if (myColor == "Colors Purple")
            {

                KeyLog = 21;
                trail = 7;
            }
        }
        Debug.Log(State);

        trailPrefab[trail].SetActive(true);
       // Debug.Log(KeyLog);
        Images[KeyLog].SetActive(true);
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
            thisTrail = (GameObject)Instantiate(trailPrefab[trail],
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
    public void ColorGame()
    {
        KeyLog = 0;
        State = 0;
        SceneManager.LoadScene(myColor);
    }
    public void next()
    {
        
        Final.SetActive(false);
        FinalImg[KeyLog].SetActive(false);
        Images[KeyLog].SetActive(false);
     //   trailPrefab[KeyLog].SetActive(false);
       /* if (KeyLog == 0)
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
        }*/
        StartCoroutine("Restart");


    

    }
    public void Done()
    {
        nextBTN.SetActive(true);
        Final.SetActive(true);
        FinalImg[KeyLog].SetActive(true);
        DoneBtn.SetActive(false);
        if (State == 2)
        {
            Debug.Log("change");
            nextBTN.SetActive(false);
            Game.SetActive(true);
            KeyLog = KeyLog - 2;
       
        }
    
        
        KeyLog++;
        State++;
      
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackBTN()
    {
        KeyLog = 0;
        State = 0;
        SceneManager.LoadScene("Colors Activities");
   
    }
    public void HomeBtn()
    {
        KeyLog = 0;
        State = 0;
        SceneManager.LoadScene("Main Menu");
      
    }
}
