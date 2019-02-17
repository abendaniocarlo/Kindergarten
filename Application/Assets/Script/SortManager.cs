using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortManager : MonoBehaviour {

   
    public GameObject[] myObject;
    public int[] setIndex = { 0, 1, 2, 3, 4 };
    
     int[] PosY = {-6,-3,0,4,7 };
    public int KeyLog;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
   public static bool Available;
    public static string answer;
    private Vector2 mousePosition;
    public string TagName;
    int Camel;
    int Elephant;
    int Walrus;
    int Lion;
    int Count;
    int donkey;
    bool BCamel;
     bool BElephant;
     bool BWalrus;
    bool BLion;
     bool Bdonkey;
     public GameObject Board;
	// Use this for initialization
	void Start () {
        setIndex = randomPos(setIndex);
        for (int a = 0; a != 5; a++)
        {
            Instantiate(myObject[setIndex[a]], new Vector3(PosY[a], -4.3f, 0), transform.rotation);
        }
          
       // StartCoroutine("PrefabGuard");
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
	// Update is called once per frame
	void Update () {
        //tags improvised circles = camel ... 
        Camel = GameObject.FindGameObjectsWithTag("Circle").Length;
        donkey = GameObject.FindGameObjectsWithTag("Square").Length;
        Elephant = GameObject.FindGameObjectsWithTag("Rectangle").Length;
        Lion = GameObject.FindGameObjectsWithTag("Oblong").Length;
        Walrus = GameObject.FindGameObjectsWithTag("Triangle").Length;
        if (Camel == 4)
        {
            BCamel = true;
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Camel"))
            {
                Destroy(temp);
            }
          
        }
        if (donkey == 5)
        {
            Bdonkey = true;
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Donkey"))
            {
                Destroy(temp);
            }
            Count++;
        }
        if (Elephant == 3)
        {
            BElephant = true;
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Elephant"))
            {
                Destroy(temp);
            }
            Count++;
        }
        if (Lion == 5)
        {
            BLion = true;
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Lion"))
            {
                Destroy(temp);
            }
            Count++;

        }
        if (Walrus == 4)
        {
            BWalrus = true;
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Walrus"))
            {
                Destroy(temp);
            }
            Count++;
        }
        if (BCamel && Bdonkey && BElephant && BLion && BWalrus)
        {
            Board.SetActive(true);
        }
       
	}
}
