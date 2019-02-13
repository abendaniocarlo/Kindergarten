using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMatch : MonoBehaviour {
    public GameObject[] setObjects;
    public static int[] setIndex = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };
    public static int keyLog=0;
    public static int Score;
    public static string myTag;
    public GameObject Box1;
	// Use this for initialization
    void Start()
    {
        if (keyLog == 0)
        {
            setIndex = randomPos(setIndex);
        }
       
       var createImage = Instantiate(setObjects[setIndex[keyLog]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        createImage.transform.SetParent(Box1.transform, false);

     //   myTag = setObjects[setIndex[keyLog]].tag;
        Debug.Log(myTag);
    }
    void Update()
    {
        myTag = setObjects[setIndex[keyLog]].tag;
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
