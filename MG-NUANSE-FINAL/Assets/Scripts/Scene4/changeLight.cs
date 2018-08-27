using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLight : MonoBehaviour {
    public GameObject lamp_Wall;
    public GameObject light1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
        lamp_Wall.SetActive(true);
        light1.SetActive(false);
        gameObject.SetActive(false);
	}
}
