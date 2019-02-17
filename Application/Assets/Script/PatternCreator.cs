using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCreator : MonoBehaviour {
    int[] Pattern = new int[6];
    int[] Index = { 0, 1, 2 };
	// Use this for initialization
	void Start () {


        Creator();

        
	}
    void Creator()
    {
        int a = 0,b=0;
        while (a <= 5)
        {

           
          
            if (b == 1)
            {
                b = 0;
            }
            Pattern[a] = b;
            Debug.Log(Pattern[a]);
            b++;
            a++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
