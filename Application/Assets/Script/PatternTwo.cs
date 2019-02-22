 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatternTwo : MonoBehaviour {

    public GameObject[] ObjStar;
    public GameObject directions;
    public GameObject other;
    int[] oddNumbers = { -29, -24, -5, 0 };
    int[] EvenNumbers = { -18, -11, 6,12 };
    int[] ObjIndex = { 0, 1, 2, 3, 4, 5, 6 };
    int z, x;
    public static int keyLog;
    public static int directionOnce;

    public static string TagName;
    void Start()
    {
        if (directionOnce == 0)
        {
            StartCoroutine(DirectionPlay());
            directionOnce++;
        }
        //odd numbers positions

        ObjIndex = randomPos(ObjIndex);
        x = ObjIndex[1];
        z = ObjIndex[0];
      
        if (x == 0)
        {
            TagName = "Circle";
        }
        else if (x == 1)
        {
            TagName = "Oblong";
        }
        else if (x == 2)
        {
            TagName = "Pentagon";
        }
        else if (x == 3)
        {
            TagName = "Rectangle";
        }
        else if (x == 4)
        {
            TagName = "Square";
        }
        else if (x == 5)
        {
            TagName = "Star";
        }
        else if (x == 6)
        {
            TagName = "Triangle";
        }
        //Debug.Log("Tag " + TagName);
        // Debug.Log(z);
        for (int a = 0; a <= 3; a++)
        {
            Instantiate(ObjStar[x], new Vector3(oddNumbers[a], 4, 65), transform.rotation);
            /*Vector3 Temp3 = ObjStar[z].transform.localPosition;
            Temp3 = new Vector3(oddNumbers[a], 0, 0);
            ObjStar[z].SetActive(true);
            ObjStar[z].transform.localPosition = Temp3;*/

        }
        for (int a = 0; a <= 3; a++)
        {
            Instantiate(ObjStar[z], new Vector3(EvenNumbers[a], 4, 65), transform.rotation);
          

        }


    }

    IEnumerator DirectionPlay()
    {
        other.SetActive(false);
        directions.SetActive(true);
        yield return new WaitForSeconds(8.5f);
        directions.SetActive(false);
        other.SetActive(true);
    }

    public void Done()
    {
        directionOnce = 0;
        SceneManager.LoadScene("Layout Activities Patterns");
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
