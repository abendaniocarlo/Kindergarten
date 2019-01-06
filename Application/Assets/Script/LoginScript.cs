using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginScript : MonoBehaviour {
    public Text UserField;
	// Use this for initialization
    string result;
    string user1 = "Char Image0";
    string user2 = "Char Image1";
    string user3 = "Char Image2";
    string user4 = "Char Image3";
	void Start () {
        for (int a = 0; a != 3; a++)
        {
            if (PlayerPrefs.HasKey("user"+a))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("user"+a);
            }
        }
	}
    public void Character1()    
    {
        
        PlayerPrefs.SetString(user1, "CHRSTNV1");
        PlayerPrefs.SetString(result, user1);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
       
    }
	
    public void Character2()    
    {
        PlayerPrefs.SetString(user2, "CHRSTNV2");
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       PlayerPrefs.SetString(result, user2);
      // Debug.Log(PlayerPrefs.GetString(user2).ToString());  
    }

    public void Character3()    
    {
        PlayerPrefs.SetString(user3, "CHRSTNV3");
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       PlayerPrefs.SetString(result, user3);
      //  Debug.Log(PlayerPrefs.GetString(user).ToString());  
    }
    public void Character4()
    {
         PlayerPrefs.SetString(user4, "CHRSTNV4");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         PlayerPrefs.SetString(result, user4);
 
         
    }



}
