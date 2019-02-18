using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatternCreator : MonoBehaviour {
    public GameObject Panel;
    public GameObject[] Objects;
    public GameObject[] Objects1;
    public GameObject Board;
    public GameObject ScoreBoard;
    public GameObject Star;
    int[] YPosition = { 26, -64 };
    int[] XPosition = { -143, -71, 0, 74, 146 };
    int[] Pattern = new int[12];
    int[] PositionX = { -400, -250, -106, 43, 189, 335 };
    int[] PositionY = { 90, -73 };
    public static int KeyLog;
    public static int Score;
    int[] Index = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    // Use this for initialization
    void Start()
    {

        Index = randomPos(Index);
        PositionY = randomPos(PositionY);
        Creator();
        


    }
    void Creator()
    {
        int a = 0, b = 0;
        while (a <= 11)
        {



            if (b == 2)
            {
                b = 0;


            }
            Pattern[a] = Index[b];

            b++;
            a++;
        }
        StartCoroutine("SpawnImages");
        StartCoroutine("SpawnImages1");


    }
    IEnumerator SpawnImages()
    {
        yield return new WaitForSeconds(0);
        int c = 0, d = 0;

        for (int x = 0; x <= 5; x++)
        {
            yield return new WaitForSeconds(.1f);
            var createImage = Instantiate(Objects[Pattern[x]], new Vector3(PositionX[c], PositionY[d], 5), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Panel.transform, false);
            c++;


        }
    }
    IEnumerator SpawnImages1()
    {
        yield return new WaitForSeconds(0);
        int c = 0, d = 1;

        for (int x = 3; x <= 8; x++)
        {
            yield return new WaitForSeconds(.1f);
            var createImage = Instantiate(Objects[x], new Vector3(PositionX[c], PositionY[d], 5), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(Panel.transform, false);
            c++;
        }
    }
    public void ButtonOne()
    {
        KeyLog++;
        if (PositionY[0] == 90)
        {
            Debug.Log("right");
            Score++;
        }
        else
        {
            Debug.Log("false");
        }
        if (KeyLog != 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            StartCoroutine("ScoreEval");
        }
    }
    public void ButtonTwo()
    {
        KeyLog++;
        if (PositionY[1] == 90)
        {
            Debug.Log("right");
            Score++;

        }
        else
        {
            Debug.Log("false");
        }
        if (KeyLog != 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            StartCoroutine("ScoreEval");
        }
    }
    IEnumerator ScoreEval()
    {
        yield return new WaitForSeconds(0);
        // Debug.Log(Score);
        Board.SetActive(true);

        int b = 0, c = 0;
        for (int a = 0; a != Score; a++)
        {
            yield return new WaitForSeconds(0.5f);
            var createImage = Instantiate(Star, new Vector3(XPosition[b], YPosition[c], 0), Quaternion.identity) as GameObject;
            createImage.transform.SetParent(ScoreBoard.transform, false);
            b++;
            if (a == 4)
            {
                b = 0;
                c++;
            }
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

    // Update is called once per frame
    void Update()
    {

    }
}
