using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAppear : MonoBehaviour {
    int NumClicks = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		NumClicks++;
		if (NumClicks == 1) {
			GameObject.Find("Black1").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Text1").GetComponent<MeshRenderer>().enabled = true;
		}
		else if (NumClicks == 2) {
			GameObject.Find("Text1").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find("Text2").GetComponent<MeshRenderer>().enabled = true;
		}
		
		else if (NumClicks == 3) {
			GameObject.Find("Text2").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find("Text3").GetComponent<MeshRenderer>().enabled = true;
		}
		
		else if (NumClicks == 4) {
			GameObject.Find("Text3").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find("Black1").GetComponent<SpriteRenderer>().enabled = false;
		}

	}
}
