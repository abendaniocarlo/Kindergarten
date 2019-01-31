using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternOne : MonoBehaviour {
    public GameObject[] ObjStar;
    int[] oddNumbers = {-207,-43, 120};
    int[] EvenNumbers = { -125, 41, 207 };
     int[] ObjIndex = { 5, 11, 17, 23, 29,35,41 };
    int z, x; 
    public static string TagName;
	void Start () {
        //odd numbers positions
        
        ObjIndex = randomPos(ObjIndex);
        x = ObjIndex[1];
        z = ObjIndex[0];
        if (x == 5)
        {
            TagName = "Circle";
        }
        else if (x == 11)
        {
            TagName = "Oblong";
        }
        else if (x == 17)
        {
            TagName = "Pentagon";
        }
        else if (x == 23)
        {
            TagName = "Rectangle";
        }
        else if (x == 29)
        {
            TagName = "Triangle";
        }
        else if (x == 35)
        {
            TagName = "Square";
        }
        else if (x == 41)
        {
            TagName = "Star";
        }
        Debug.Log("Tag " + TagName);
       // Debug.Log(z);
        for (int a = 0; a <= 2; a++)
        {
            Vector3 Temp3 = ObjStar[z].transform.localPosition;
            Temp3 = new Vector3(oddNumbers[a], 0, 0);
            ObjStar[z].SetActive(true);
            ObjStar[z].transform.localPosition = Temp3;
            z--;
        }
        for (int a = 0; a <= 1; a++)
        {
            Vector3 Temp3 = ObjStar[x].transform.localPosition;
            Temp3 = new Vector3(EvenNumbers[a], 0, 0);
            ObjStar[x].SetActive(true);
            ObjStar[x].transform.localPosition = Temp3;
            x--;
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
	
	// Update is called once per frame
	void Update () {
		
	}
}
