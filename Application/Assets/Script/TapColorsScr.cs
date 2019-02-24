﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TapColorsScr : MonoBehaviour {

    public GameObject colorname;
    public GameObject red;
    public GameObject orange;
    public GameObject yellow;
    public GameObject green;
    public GameObject blue;
    public GameObject purple;
    public GameObject brown;
    public GameObject pink;
    public GameObject toCover;
    public Button redbtn;
    public Button orangebtn;
    public Button yellowbtn;
    public Button greenbtn;
    public Button bluebtn;
    public Button purplebtn;
    public Button brownbtn;
    public Button pinkbtn;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1f;
        redbtn.onClick.AddListener(() => {  StartCoroutine(redTap());  });

        orangebtn.onClick.AddListener(() => { StartCoroutine(orangeTap()); });

        yellowbtn.onClick.AddListener(() => { StartCoroutine(yellowTap()); });

        greenbtn.onClick.AddListener(() => { StartCoroutine(greenTap()); });

        bluebtn.onClick.AddListener(() => { StartCoroutine(blueTap()); });

        purplebtn.onClick.AddListener(() => { StartCoroutine(purpleTap()); });

        brownbtn.onClick.AddListener(() => { StartCoroutine(brownTap()); });

        pinkbtn.onClick.AddListener(() => { StartCoroutine(pinkTap()); });

    }

    public void returnBTN()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("ColorIndex1"));
    }

    IEnumerator redTap() {
        colorname.SetActive(true);
        red.SetActive(true);
        toCover.SetActive(true);

        yield return new WaitForSeconds(1f);
        colorname.SetActive(false);
        red.SetActive(false);
        toCover.SetActive(false);
    }

    IEnumerator orangeTap()
    {
        colorname.SetActive(true);
        orange.SetActive(true);
        toCover.SetActive(true);

        yield return new WaitForSeconds(1f);
        colorname.SetActive(false);
        orange.SetActive(false);
        toCover.SetActive(false);
    }

    IEnumerator yellowTap()
    {
        colorname.SetActive(true);
        yellow.SetActive(true);
        toCover.SetActive(true);

        yield return new WaitForSeconds(1f);
        colorname.SetActive(false);
        yellow.SetActive(false);
        toCover.SetActive(false);
    }

    IEnumerator greenTap()
    {
        colorname.SetActive(true);
        green.SetActive(true);
        toCover.SetActive(true);

        yield return new WaitForSeconds(1f);
        colorname.SetActive(false);
        green.SetActive(false);
        toCover.SetActive(false);
    }

    IEnumerator blueTap()
    {
        colorname.SetActive(true);
        blue.SetActive(true);
        toCover.SetActive(true);

        yield return new WaitForSeconds(1f);
        colorname.SetActive(false);
        blue.SetActive(false);
        toCover.SetActive(false);
    }

    IEnumerator purpleTap()
    {
        colorname.SetActive(true);
        purple.SetActive(true);
        toCover.SetActive(true);

        yield return new WaitForSeconds(1f);
        colorname.SetActive(false);
        purple.SetActive(false);
        toCover.SetActive(false);
    }

    IEnumerator brownTap()
    {
        colorname.SetActive(true);
        brown.SetActive(true);
        toCover.SetActive(true);

        yield return new WaitForSeconds(1f);
        colorname.SetActive(false);
        brown.SetActive(false);
        toCover.SetActive(false);
    }

    IEnumerator pinkTap()
    {
        colorname.SetActive(true);
        pink.SetActive(true);
        toCover.SetActive(true);

        yield return new WaitForSeconds(1f);
        colorname.SetActive(false);
        pink.SetActive(false);
        toCover.SetActive(false);
    }



    // Update is called once per frame
    //void Update () {

    //}
}
