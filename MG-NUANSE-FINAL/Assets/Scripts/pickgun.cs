using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickgun : MonoBehaviour {
    int Clicked = 0;
	public GameObject gun;
	private MouseDrag MouseDragScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		if (GameObject.FindWithTag("fp") == null) {
			Clicked++;
		}
		
		if (Clicked == 2) {
			MouseDragScript = gun.GetComponent<MouseDrag>();
			MouseDragScript.canbedragged = true;
			Debug.Log("drag now");
		}
	}
	
}
