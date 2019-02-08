using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

	// Use this for initialization
    public GameObject PlayButton;
    public GameObject PauseButton;
    private VideoPlayer player;
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
            Debug.Log("pause");
            PauseButton.SetActive(false);
            PlayButton.SetActive(true);
        }
        else
        {
            player.Play();
            Debug.Log("Play");
            PlayButton.SetActive(false);
            PauseButton.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
