using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortSpawn : MonoBehaviour {
    public GameObject[] myObject;
    public GameObject[] Objects;
    int[] PositionY = { 134, 75, 9, -57, -125 };
    int[] setIndex;
    int key = 0;
   public static int current;
    Rigidbody2D Controller;
    int Camel;
    int Elephant;
    int Walrus;
    int Lion;
    int Count;
    int donkey;
    public static string XName;
   public static GameObject myname;
   int number;
   public static int Animal;
    List<int> Index = new List<int>();
   
	// Use this for initialization
	void Start () {
        

	}
    
    void OnTriggerEnter2D(Collider2D target)
    {
       // Debug.Log("s");
        Controller = GetComponent<Rigidbody2D>();
        Debug.Log(target.tag);
        if (target.tag == Controller.tag)
        {

            Animal = 0;

            XName = "CamelDrp";
                
                current = Camel;
              
                number++;
                Camel++;
               // Debug.Log("ssz");            
        }
         if (target.tag == Controller.tag)
        {
            Animal = 1;

            XName = "DonkeyDrp";
            number++;
            current = donkey;
          
            donkey++;
        //    Debug.Log("ssz1");    
            
        }
        if (target.tag == Controller.tag)
        {
            Animal = 2;
            XName = "ElephantDrp";
            current = Elephant;
        
            Elephant++;
            number++;
         //   Debug.Log("ssz2");    
        }
         if (target.tag == Controller.tag)
        {
            Animal = 3;
            current = Lion;
            XName = "LionDrp";
        //    Debug.Log("ssz3");    
            
            Lion++;
     

        }
        if (target.tag == Controller.tag)
        {
            Animal = 4;
            number++;
            XName = "WalrusDrp";

            current = Walrus;
          
            Walrus++;

          //  Debug.Log("ssz4");    
        }
        Debug.Log(XName);
      var createImage = Instantiate(Objects[Animal], new Vector3(0, PositionY[current], 5), Quaternion.identity) as GameObject;
      createImage.transform.SetParent(GameObject.Find(XName).transform, false);
    }

    void Update()
    {
        
        if (Camel == 4)
        {
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Camel"))
            {
                Destroy(temp);
            }
           
        }
          if (donkey == 5)
        {
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Donkey"))
            {
                Destroy(temp);
            }
           
        }
          if (Elephant == 3)
          {
              foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Elephant"))
              {
                  Destroy(temp);
              }

          }
          if (Lion == 5)
          {
              foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Lion"))
              {
                  Destroy(temp);
              }

          }
          if (Walrus == 4)
          {
              foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Walrus"))
              {
                  Destroy(temp);
              }

          }
          if (number == 20)
          {
              Debug.Log("Design here");
          }
    }
    public int[] randomPos(int[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            int tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
        return array;
    }
}
