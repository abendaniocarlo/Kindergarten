using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SetSpawn : MonoBehaviour {
    public GameObject[] myObject;
    public Transform[] TButtons;
    public GameObject treeshake;
    public AudioSource SoundFx;
    public AudioClip willSpeak;
    public GameObject tree;
    public Text[] QText;
    public GameObject[] OText;
    public GameObject[] QFruit;
    public GameObject Capsule;
    public GameObject[] CButtons;
    public Button[] myButton;
 	// Use this for initialization
    public static int FruitIndex = 8;
    public static int KeyLog;
    public static int tune;
    public static int[] question = { 3, 5, 4, 2,5 };
   public static int[] number = { 2, 3, 4 };
   public static int[] Obj = { 0, 1, 2, 3, 4, 5, 6 };
   int[] YPostion = { 146, 76, 15, -50, -114 };

	void Start () {
        if (tune == 0)
        {
            SoundFx.PlayOneShot(willSpeak);
            tune++;
        }

            question = randomPos(question);
        number = randomPos(number);
        Obj = randomPos(Obj);
      //  YPostion = randomPos(YPostion);
   
        for (int a = 0; a != number[0]; a++)
        {
            var createImage = Instantiate(QFruit[Obj[a]], new Vector3(7, YPostion[a], 0), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Capsule.transform, false);
            QText[a].text = question[a].ToString();
            OText[a].SetActive(true);
       
        }

	}
    public void Apple()
    {
        FruitIndex = 0;
        CButtons[0].transform.localPosition = new Vector3(CButtons[0].transform.localPosition.x, -234, 0);
        myButton[0].interactable = false;
        StartCoroutine("ButtonSettings");
    }
    public void Banana()
    {
        FruitIndex = 1;
        CButtons[1].transform.localPosition = new Vector3(-204.4f, -234, 0);
        myButton[1].interactable = false;
        StartCoroutine("ButtonSettings");
    }
    public void Grapes()
    {
        FruitIndex = 2;
        CButtons[2].transform.localPosition = new Vector3(-98.8f, -234, 0);
        myButton[2].interactable = false;
        StartCoroutine("ButtonSettings");
    }
    public void Orange()
    {
        FruitIndex = 3;
        CButtons[3].transform.localPosition = new Vector3(6.8f, -234, 0);
        myButton[3].interactable = false;
        StartCoroutine("ButtonSettings");
    }
    public void PineApple()
    {
        FruitIndex = 4;
        CButtons[4].transform.localPosition = new Vector3(112.4f, -234, 0);
        myButton[4].interactable = false;
        StartCoroutine("ButtonSettings");
    }
    public void Watermelon()
    {
        FruitIndex = 5;
        CButtons[5].transform.localPosition = new Vector3(218, -234, 0);
        myButton[5].interactable = false;
        StartCoroutine("ButtonSettings");
    }
    public void Cherry()
    {
        FruitIndex = 6;
        CButtons[6].transform.localPosition = new Vector3(323.6f, -234, 0);
        myButton[6].interactable = false;
        StartCoroutine("ButtonSettings");
    }
    IEnumerator NoOption()
    {
        yield return new WaitForSeconds(.3f);
        int x = 0;
        while (x != 7)
        {
           
                
                CButtons[x].transform.localPosition = new Vector3(CButtons[x].transform.localPosition.x, -269, 0);
           
            x++;
        }
    }
    IEnumerator ButtonSettings()
    {
        yield return new WaitForSeconds(0);
        int x=0;
        while(x!=7)
        {
            if (x != FruitIndex)
            {
                myButton[x].interactable = true;
                CButtons[x].transform.localPosition = new Vector3(CButtons[x].transform.localPosition.x, -269, 0);
            }
            x++;
        }
            
    
        
    }
	
	
	
	
	
	
	// Update is called once per frame
    void Update()
    {
        if (SetDestroy.Answer == false)
        {

            //      Debug.Log("hit");
          Rect rect = new Rect(150, 400, 700, 200);
        //    if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (rect.Contains(touch.position))
        //    {

               
        //           // Touch touch = Input.GetTouch(0);
        //            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        //            if (touch.phase == TouchPhase.Began)
        //            {

        //                if (FruitIndex == 8)
        //                {
        //                    int x = 0;
        //                    while (x != 7)
        //                    {


        //                        CButtons[x].transform.localPosition = new Vector3(CButtons[x].transform.localPosition.x, -234, 0);

        //                        x++;
        //                        StartCoroutine("NoOption");
        //                    }
        //                }
        //                else
        //                {
        //                    Instantiate(myObject[FruitIndex], touchPos, Quaternion.identity);
        //                }
        //            }


        //    }
        //}
        if (rect.Contains(Input.mousePosition))
        {
      

                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine("ToShake");


                    Vector2 down = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (Input.GetMouseButtonDown(0))
                    {
                
                        if (FruitIndex == 8)
                        {
                            int x = 0;
                            while (x != 7)
                            {


                                CButtons[x].transform.localPosition = new Vector3(CButtons[x].transform.localPosition.x, -234, 0);

                                x++;
                                StartCoroutine("NoOption");
                            }
                        }
                        else
                        {
                            Instantiate(myObject[FruitIndex], down, Quaternion.identity);
                        }
                    }
                }
            }
        }
        else
        {
          //  Debug.Log("done");
        }
       

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
    IEnumerator ToShake()
    {
        tree.SetActive(false);
        treeshake.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        tree.SetActive(true);
        treeshake.SetActive(false);

    }
    public void EndBTN()
    {
        KeyLog = 0;
        SceneManager.LoadScene("Layout Games Sets");
    }
    public void Done()
    {
        //    tune = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Layout Games Sets");
    }
}
