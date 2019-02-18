using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JingleControllRoom : MonoBehaviour {
    public GameObject MyCanvas;
    public GameObject Audio;
    public GameObject BabyShark;
    public GameObject FiveLittleDucks;
    public GameObject FiveLittleMonkeys;
    public GameObject HumpyDumpy;
    public GameObject Spider;
    public GameObject Monkey;
    public GameObject McDonald;
    public GameObject RingAround;
    public GameObject RowBoat;
    public GameObject Twinkle;

    public void GOBabyShark()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        BabyShark.SetActive(true);
    }
    public void GoLittleDucks()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        FiveLittleDucks.SetActive(true);
    }
    public void GoLittleMonkeys()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        FiveLittleMonkeys.SetActive(true);
    }
    public void GoHumpyDumpy()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        HumpyDumpy.SetActive(true);
    }
    public void GoSpider()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        Spider.SetActive(true);

    }
    public void GoMonkey()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        Monkey.SetActive(true);
    }
    public void GoMcdonald()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        McDonald.SetActive(true);
    }
    public void GoRingAround()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        RingAround.SetActive(true);
    }
    public void GoRowBoat()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        RowBoat.SetActive(true);
    }
    public void GoTwinkle()
    {
        MyCanvas.SetActive(false);
        Audio.SetActive(false);
        Twinkle.SetActive(true);
    }
}
