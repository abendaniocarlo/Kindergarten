using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SizeTutorial1 : MonoBehaviour {
    public GameObject[] Small;
    public GameObject[] Big;
    public GameObject Circle;
    public GameObject Board;
    public GameObject bigTxt;
    public GameObject smallTxt;
    public GameObject message;
    public AudioSource SoundFx;
    public AudioClip thatsright;
    public static int[] SmallIndex = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
    public static int[] BigIndex = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    int[] PositionY = {-250,250 };
    public static int KeyLog;
    public static int KeyLog1;
   public static string Mode;
	// Use this for initialization
	void Start () {
        if (KeyLog == 0)
        {
            SmallIndex = randomPos(SmallIndex);
            BigIndex = randomPos(BigIndex);
            Mode = PlayerPrefs.GetString("SizeMode", "No mode");
          
        }
              PositionY = randomPos(PositionY);
            Vector3 Temp = Small[SmallIndex[KeyLog]].transform.position;
            Temp = new Vector3(PositionY[0], -36, 0);
            Small[SmallIndex[KeyLog]].transform.localPosition = Temp;
            Small[SmallIndex[KeyLog]].SetActive(true);
           
            Vector3 Temp1 = Big[BigIndex[KeyLog]].transform.position;
            Temp1 = new Vector3(PositionY[1], 2, 0);
            Big[BigIndex[KeyLog]].transform.localPosition = Temp1;
            Big[BigIndex[KeyLog]].SetActive(true);

        if (Mode == "BigSize")
            bigTxt.SetActive(true);
        else
            smallTxt.SetActive(true);

    }
    public void SmallBTN()
    {

        if (Mode == "BigSize")
        {
            Vector3 Temp1 = Circle.transform.position;
            Temp1 = new Vector3(PositionY[1], 2, 0);
            Circle.transform.localPosition = Temp1;
            Circle.SetActive(true);
            StartCoroutine("ShowRight");
        }
        else
        {
            KeyLog++;
            SoundFx.PlayOneShot(thatsright);
            message.SetActive(true);
            StartCoroutine("RestartGame");
        }
        
      
    }
    public void BigBTN()
    {
        if (Mode == "BigSize")
        {
            KeyLog++;
            SoundFx.PlayOneShot(thatsright);
            message.SetActive(true);
            StartCoroutine("RestartGame");
        }
        else
        {
            Vector3 Temp1 = Circle.transform.position;
            Temp1 = new Vector3(PositionY[0], -36, 0);
            Circle.transform.localPosition = Temp1;
            Circle.SetActive(true);
            StartCoroutine("ShowRight");
        }
        

    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.01f);
        if (KeyLog != 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Board.SetActive(true);
        }
     
    }

    IEnumerator ShowRight()
    {
        yield return new WaitForSeconds(.3f);
        Circle.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Retry()
    {
        KeyLog = 0;
        
        StartCoroutine("TryAgain");
    }
    public void returnBTN()
    {
        if(Mode == "BigSize")
            SceneManager.LoadScene("Sizes Big");
        else
            SceneManager.LoadScene("Sizes Small");
    }
    IEnumerator TryAgain()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
}
