using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TapShapesScr : MonoBehaviour {

    public GameObject circle;
    public GameObject square;
    public GameObject triangle;
    public GameObject rectangle;
    public GameObject oval;

    public Button circlebtn;
    public Button squarebtn;
    public Button trianglebtn;
    public Button rectanglebtn;
    public Button ovalbtn;

    // Use this for initialization
    void Start () {

        circlebtn.onClick.AddListener(() => { StartCoroutine(circleTap()); });

        squarebtn.onClick.AddListener(() => { StartCoroutine(squareTap()); });

        trianglebtn.onClick.AddListener(() => { StartCoroutine(triangleTap()); });

        rectanglebtn.onClick.AddListener(() => { StartCoroutine(rectangleTap()); });

        ovalbtn.onClick.AddListener(() => { StartCoroutine(ovalTap()); });

    }

    public void returnBTN()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("ShapeIndex", "No Shape"));
    }


    IEnumerator circleTap()
    {
        circle.SetActive(true);

        yield return new WaitForSeconds(1f);
        circle.SetActive(false);
    }

    IEnumerator squareTap()
    {
        square.SetActive(true);

        yield return new WaitForSeconds(1f);
        square.SetActive(false);
    }

    IEnumerator triangleTap()
    {
        triangle.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        triangle.SetActive(false);
    }

    IEnumerator rectangleTap()
    {
        rectangle.SetActive(true);

        yield return new WaitForSeconds(2f);
        rectangle.SetActive(false);
    }

    IEnumerator ovalTap()
    {
        oval.SetActive(true);

        yield return new WaitForSeconds(1f);
        oval.SetActive(false);
    }


    // Update is called once per frame
    //void Update () {

    //}
}
