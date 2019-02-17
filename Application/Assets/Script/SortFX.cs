using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortFX : MonoBehaviour {

    public GameObject[] Objects;
 //   public GameObject[] myObject;
    public int[] setIndex = { 0, 1, 2, 3, 4 };
    int KeyLog;
    int myIndex;
    GameObject name;
   public static int Camel;
   public static int Elephant;
   public static int Walrus;
   public static int Lion;
   public static int donkey;
  public static bool BCamel;
  public static bool BElephant;
  public static bool BWalrus;
  public static bool BLion;
  public static bool Bdonkey;

    int[] PositionY = { 134, 75, 9, -57, -125 };
    int number;
    int Animal;
    public static string TargetName;
	// Use this for initialization
    void Start()
    {
           
        
       
    }
   
    void OnTriggerEnter2D(Collider2D target)
    {
        if (SortController.locked == true)
        {
            StartCoroutine("ImageSpawn");
           
        }
        TargetName = target.tag;
        
    }
 
  
    IEnumerator ImageSpawn() 
    {
        yield return new WaitForSeconds(0);
        if (TargetName == SortController.TagName)
        {



            if (TargetName == "Camel")
            {
                Camel++;
               

                name = GameObject.Find("CamelDrp");
                Animal = 0;
             
            }
            else if (TargetName == "Donkey")
            {
                donkey++;
                Animal = 1;
                name = GameObject.Find("DonkeyDrp");
             
            }
            else if (TargetName == "Elephant")
            {
                Elephant++;
                Animal = 2;
                name = GameObject.Find("ElephantDrp");
             
            }
            else if (TargetName == "Lion")
            {
                Lion++;
                Animal = 3;
                name = GameObject.Find("LionDrp");
               
            }
            else if (TargetName == "Walrus")
            {
                name = GameObject.Find("WalrusDrp");
                Walrus++;
                Animal = 4;
              
            }


        }
        //Instantiate(myObject[0], new Vector3(-6.3f, 1.3f, 0), transform.rotation);
       // var createImage = Instantiate(Objects[Animal], new Vector3(0, PositionY[number], 5), Quaternion.identity) as GameObject;
       // createImage.transform.SetParent(name.transform, false);
        number++;
        SortController.locked = false;
    }
}
