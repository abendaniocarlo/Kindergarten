using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class JinglesController : MonoBehaviour
{
    private VideoPlayer player;
    public GameObject VideoList;
    public GameObject PlayBTN;
    public GameObject PauseBTN;
    public GameObject MyCanvas;
    public GameObject MyAudio;
    // Use this for initialization
    void Start()
    {

    }
    
    public void GoReturn()
    {
        SceneManager.LoadScene("Play Menu");
    }

    void Awake()
    {

        player = GetComponent<VideoPlayer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Rect rect = new Rect(200,100,500,300);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (rect.Contains(touch.position))
            {
                if (Input.touchCount>0)
                {

                    if (player.isPlaying)
                    {

                        Debug.Log("T");
                        player.Pause();
                    }
                    else
                    {
                        Debug.Log("s");
                        player.Play();

                    }
                }
             
            }
        }
        
           if (rect.Contains(Input.mousePosition))
             {
                 if (Input.GetMouseButtonDown(0))
                 {

                     if (player.isPlaying)
                     {
                        
                         Debug.Log("T");
                         player.Pause();
                   
                         PlayBTN.SetActive(true);
                    
                     }
                     else
                     {
                         Debug.Log("s");
                         player.Play();
                         PlayBTN.SetActive(false);
                        
                    
                     }
                 }
        }
    }

    public void SeeList()
    {
        MyCanvas.SetActive(false);
        VideoList.SetActive(true);
        MyAudio.SetActive(true);



    }
}
