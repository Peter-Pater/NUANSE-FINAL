using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAppear : MonoBehaviour {
    public int NumClicks = 0;
    public bool validate = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch(NumClicks){
            case 1:
                validate = GameObject.Find("Text1").GetComponent<FadeIO>().fadeDone;
                if(validate == true){
                    GameObject.Find("Text1").GetComponent<FadeIO>().fadeMode = 0;
                }
                break;
            case 2:
                validate = GameObject.Find("Text1").GetComponent<FadeIO>().fadeDone;
                if (validate == true)
                {
                    
                    GameObject.Find("Text1").GetComponent<FadeIO>().fadeMode = 0;
                }
                break;
            case 3:
                validate = GameObject.Find("Text2").GetComponent<FadeIO>().fadeDone;
                if (validate == true)
                {
                    GameObject.Find("Text2").GetComponent<FadeIO>().fadeMode = 0;
                }
                break;
            case 4:
                validate = GameObject.Find("Text2").GetComponent<FadeIO>().fadeDone;
                if (validate == true)
                {
                    GameObject.Find("Text2").GetComponent<FadeIO>().fadeMode = 0;
                }
                break;
            case 5:
                validate = GameObject.Find("Text3").GetComponent<FadeIO>().fadeDone;
                if (validate == true)
                {
                    GameObject.Find("Text3").GetComponent<FadeIO>().fadeMode = 0;
                }
                break;
            case 6:
                validate = GameObject.Find("Text3").GetComponent<FadeIO>().fadeDone;
                if (validate == true)
                {
                    GameObject.Find("Text3").GetComponent<FadeIO>().fadeMode = 0;
                }
                break;
        }
	}
	
	void OnMouseDown() {
        if (validate){
            NumClicks++;
            if (NumClicks == 1)
            {
                GameObject.Find("Black1").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Text1").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Text1").GetComponent<FadeIO>().fadeMode = 1;
            }else if (NumClicks == 2){
                GameObject.Find("Text1").GetComponent<FadeIO>().fadeDone = false;
                GameObject.Find("Text1").GetComponent<FadeIO>().fadeMode = 3;
            }
            else if (NumClicks == 3)
            {
                GameObject.Find("Text1").GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("Text2").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Text2").GetComponent<FadeIO>().fadeMode = 1;
            }

            else if (NumClicks == 4)
            {
                GameObject.Find("Text2").GetComponent<FadeIO>().fadeDone = false;
                GameObject.Find("Text2").GetComponent<FadeIO>().fadeMode = 3;
            }else if (NumClicks == 5)
            {
                GameObject.Find("Text2").GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("Text3").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Text3").GetComponent<FadeIO>().fadeMode = 1;
            }

            else if (NumClicks == 6)
            {
                GameObject.Find("Text3").GetComponent<FadeIO>().fadeDone = false;
                GameObject.Find("Text3").GetComponent<FadeIO>().fadeMode = 3;
            }

            else if (NumClicks == 7)
            {
                //validate = GameObject.Find("Text4").GetComponent<FadeIO>().fadeDone;
                GameObject.Find("Text3").GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("Black1").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Transition").GetComponent<Transition>().transitCommand = true;
            }   
        }
	}
}
