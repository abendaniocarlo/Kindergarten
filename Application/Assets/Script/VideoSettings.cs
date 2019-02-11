using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettings : MonoBehaviour {
    public GameObject VideoOne;
    public GameObject VideoTwo;
    public GameObject VideoList;
        // Use this for initialization
    public void Video1()
    {
        VideoOne.SetActive(true);
        VideoList.SetActive(false);
        
    }
    public void Video2()
    {
        VideoTwo.SetActive(true);
        VideoList.SetActive(false);
    }
}
