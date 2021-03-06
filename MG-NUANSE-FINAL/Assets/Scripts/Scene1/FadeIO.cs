﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIO : MonoBehaviour {

    const int NOFADE = 0;
    const int FADEIN = 1;
    const int FADEINANDOUT = 2;
    const int FADEOUT = 3;

    bool textShown = false;
    bool textHide = false;
    public bool fadeDone = false;
    // Use this for initialization
    public int fadeMode;

    public float showtime;
    public float fadeSpeed;


	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!textShown && fadeMode == FADEIN || fadeMode == FADEINANDOUT) {
		    StartCoroutine(FadeTextToFullAlpha(fadeSpeed, GetComponent<TextMesh>()));
	    }

        if (textShown && fadeMode == FADEINANDOUT && !textHide){
            StartCoroutine(FadeTextToZeroAlpha(fadeSpeed, GetComponent<TextMesh>()));
        }

        if (fadeMode == FADEOUT && !textHide){
            StartCoroutine(FadeOut(fadeSpeed, GetComponent<TextMesh>()));
        }
	}
	
	public IEnumerator FadeTextToFullAlpha(float t, TextMesh i) {
	    i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        if (!textShown){
            while (i.color.a < 1.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
                yield return null;
            }
            textShown = true;
        }
        //Debug.Log("Fade in");
        if (fadeMode == 1){
            fadeDone = true;    
        }
	 }
	 
     public IEnumerator FadeTextToZeroAlpha(float t, TextMesh i)
     {
         i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        yield return new WaitForSeconds(showtime);
         while (i.color.a > 0.0f)
         {
             i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
             yield return null;
         }
        textHide = true;
        fadeDone = true;
     }

    public IEnumerator FadeOut(float t, TextMesh i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        //Debug.Log("Fade out");
        textHide = true;
        fadeDone = true;
    }

}
