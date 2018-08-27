﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrans : MonoBehaviour {

    public Transition trans;
    bool isTransHappened = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown(){
        if (!isTransHappened){
            trans.transitCommand = true;
            isTransHappened = true;
        }
    }
}