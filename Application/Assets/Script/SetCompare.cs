using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCompare : MonoBehaviour {
    public GameObject[] setObjects;
    public GameObject canvas;
    int[] setIndex = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] SetPosition = { 165, -111, -82, -43, -17, 15, 42, 70, 101, 132 };
    int keyLog;
	// Use this for initialization
	void Start () {
        if (keyLog == 0)
        {
            setIndex = randomPos(setIndex);
        }
        
        for (int a = 0; a <= 9;a++)
        {
            var createImage = Instantiate(setObjects[0]) as GameObject;
            createImage.transform.SetParent(canvas.transform, false);
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
