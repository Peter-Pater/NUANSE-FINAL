using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIO : MonoBehaviour {
    bool textShown = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!textShown) {
		StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<TextMesh>()));
	   }
	}
	
	public IEnumerator FadeTextToFullAlpha(float t, TextMesh i) {
	    i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
	    while (i.color.a < 1.0f)
	    {
	        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
	        yield return null;
	    }
		textShown = true;
	 }
	 
     public IEnumerator FadeTextToZeroAlpha(float t, Text i)
     {
         i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
         while (i.color.a > 0.0f)
         {
             i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
             yield return null;
         }
     }
}
