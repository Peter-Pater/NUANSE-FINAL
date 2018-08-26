using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransConditions : MonoBehaviour {

    public int conditionsToMeet;
    public int conditionsMet = 0;
    public Transition trans;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (conditionsMet == conditionsToMeet){
            trans.transitCommand = true;
            conditionsMet = 0;
        }
	}
}
