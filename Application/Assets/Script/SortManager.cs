using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static string Mode;
    int Camel=0;
    int Elephant=0;
    int Walrus=0;
    int Lion=0;
    int Count=0;
    int donkey=0;
    bool BCamel = false;
    bool BElephant = false;
    bool BWalrus = false;
    bool BLion = false;
    bool Bdonkey = false;
     public GameObject Board;
	// Use this for initialization
	void Start () {
        Mode = PlayerPrefs.GetString("SetIndex", "No mode");
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
            Debug.Log("s");
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
        Debug.Log(BCamel);
        if (BCamel == true && Bdonkey == true && BElephant == true && BLion == true && BWalrus == true)
        {
          //  Debug.Log(!BCamel);
            Board.SetActive(true);
        }
       
	}


    public void Retry()
    {
        KeyLog = 0;

        StartCoroutine("TryAgain");
    }
    IEnumerator TryAgain()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void backbtn()
    {
        KeyLog = 0;
        if (Mode == "Set1")
            SceneManager.LoadScene("Sets Activity");

        else
            SceneManager.LoadScene("Sets Compare");
    }
}
