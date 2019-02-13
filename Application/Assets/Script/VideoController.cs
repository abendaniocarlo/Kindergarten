using System.Collections;
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
        if (player.isPlaying)
        {
            PlayButton.SetActive(false);
            PauseButton.SetActive(true);
             if (Input.GetMouseButtonDown(0) || Input.touchCount>0)
            {
              //  Debug.Log("s");
                player.Pause();
            }
        }
        else
        {
            PlayButton.SetActive(true);
            PauseButton.SetActive(false);
           
            
            
        }
    }
    public void CloseVideo()
    {
    //for patterns or single video

        Video01.SetActive(false);
        VideoList.SetActive(true);
    }
}
