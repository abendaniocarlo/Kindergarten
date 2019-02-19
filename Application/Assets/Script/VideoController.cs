﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour {

	// Use this for initialization
    public GameObject PlayButton;
    public GameObject PauseButton;
    private VideoPlayer player;
    public GameObject Video01;
    public GameObject Video02;
    public GameObject VideoList;
    bool show = false;
    void Awake()
    {
       
        player = GetComponent<VideoPlayer>();
        player.Pause();
         
       
    }
	void Start () {
        PauseButton.SetActive(false);
       
       

	}
   
    public void EXP()
    {
        
    }
    public void PlayPause()
    {
      
        if (player.isPlaying)
        {
            
            player.Pause();
           
        }
        else
        {
            
            player.Play();
         
        }
    }
    public void Exit()
    {
        player.Pause();
        
        Video01.SetActive(false);
        Video02.SetActive(false);
        VideoList.SetActive(true);
    }
	
	// Update is called once per frame
    void Update()
    {
        Rect rect = new Rect(150, 400, 700, 200);
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (rect.Contains(touch.position))
        //    {
        //        if (Input.touchCount > 0)
        //        {

        //            if (player.isPlaying)
        //            {

        //                Debug.Log("T");
        //                player.Pause();
        //            }
        //            else
        //            {
        //                Debug.Log("s");
        //                player.Play();

        //            }
        //        }

        //    }
        //}

        if (rect.Contains(Input.mousePosition))
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (player.isPlaying)
                {

                    Debug.Log("T");
                    player.Pause();

                    PlayButton.SetActive(true);

                }
                else
                {
                    Debug.Log("s");
                    player.Play();
                    PlayButton.SetActive(false);


                }
            }
        }
    }
    public void CloseVideo()
    {
    //for patterns or single video

        Video01.SetActive(false);
        VideoList.SetActive(true);
    }
}
