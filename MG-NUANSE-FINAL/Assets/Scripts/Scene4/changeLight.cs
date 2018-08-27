using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLight : MonoBehaviour {
    public GameObject myLight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<SpriteRenderer>().color.a >= 0.99f){
            myLight.SetActive(true);
        }else if (gameObject.GetComponent<SpriteRenderer>().color.a <= 0.01f){
            myLight.SetActive(false);
        }
	}

}
