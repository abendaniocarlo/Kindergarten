using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortManager : MonoBehaviour {

   
    public GameObject[] myObject;
    public int[] setIndex = { 0, 1, 2, 3, 4 };
    public int KeyLog;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    public static string answer;
    private Vector2 mousePosition;
    public string TagName;
	// Use this for initialization
	void Start () {
        setIndex = randomPos(setIndex);
        Instantiate(myObject[0], new Vector3(0, -3.7f, 0), transform.rotation);
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
