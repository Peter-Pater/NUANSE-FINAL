using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAppear : MonoBehaviour {
    int NumClicks = 0;
    bool validate = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch(NumClicks){
            case 1:
                validate = GameObject.Find("Text1").GetComponent<FadeIO>().fadeDone;
                break;
            case 2:
                validate = GameObject.Find("Text2").GetComponent<FadeIO>().fadeDone;
                break;
            case 3:
                validate = GameObject.Find("Text3").GetComponent<FadeIO>().fadeDone;
                break;
        }
	}
	
	void OnMouseDown() {
        if (validate){
            NumClicks++;
            if (NumClicks == 1)
            {
                //validate = GameObject.Find("Text1").GetComponent<FadeIO>().fadeDone;
                GameObject.Find("Black1").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Text1").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Text1").GetComponent<FadeIO>().enabled = true;
            }
            else if (NumClicks == 2)
            {
                //validate = GameObject.Find("Text2").GetComponent<FadeIO>().fadeDone;
                GameObject.Find("Text1").GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("Text2").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Text2").GetComponent<FadeIO>().enabled = true;
            }

            else if (NumClicks == 3)
            {
                validate = GameObject.Find("Text3").GetComponent<FadeIO>().fadeDone;
                GameObject.Find("Text2").GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("Text3").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Text3").GetComponent<FadeIO>().enabled = true;
            }

            else if (NumClicks == 4)
            {
                //validate = GameObject.Find("Text4").GetComponent<FadeIO>().fadeDone;
                GameObject.Find("Text3").GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("Black1").GetComponent<SpriteRenderer>().enabled = false;
            }   
        }
	}
}
