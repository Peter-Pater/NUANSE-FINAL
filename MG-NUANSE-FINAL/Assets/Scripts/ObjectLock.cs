using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLock : MonoBehaviour {

    public bool isLocked = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isLocked){
            GetComponent<Collider2D>().enabled = false;
        }else{
            GetComponent<Collider2D>().enabled = true;
        }
	}
}
