using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

	// Use this for initialization
    [SerializeField]
    private GameObject[] Objects;
    private BoxCollider2D col;
    float x1, x2;
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        StartCoroutine(SpawnFruit(1f));
	}
    void Awake()
    {
        col = GetComponent<BoxCollider2D>(); 
    }
    IEnumerator SpawnFruit(float time)
    {
        yield return new WaitForSecondsRealtime(time);
         x1 = transform.position.x - col.bounds.size.x / 2f;
         x2 = transform.position.x + col.bounds.size.x / 2f;
        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);
        Instantiate(Objects[Random.Range(0, Objects.Length)], temp, Quaternion.identity);
        StartCoroutine(SpawnFruit(Random.Range(1f, 2f)));
    }
	// Update is called once per frame
	void Update () {
		
	}
}
