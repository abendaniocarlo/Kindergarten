using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library 
{
   // namespace {
    public int[] randomPos(int[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            int tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
            // Debug.Log(tmp);
        }
        return array;
    }
//}

}
