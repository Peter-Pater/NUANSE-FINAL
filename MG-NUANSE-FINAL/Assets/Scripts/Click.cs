using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {
	public int[] footprintvalues = new int[5];
	public GameObject footPrint0;
	public GameObject footPrint1;
	public GameObject footPrint2;
	public GameObject footPrint3;
	public GameObject footPrint4;
	private Click clickScript1;
	private Click clickScript2;
	private Click clickScript3;
	private Click clickScript4;

	// Use this for initializastion
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		if (gameObject.name == "footprint0") {
            footPrintFadeOut();
			Destroy(gameObject);
			footprintvalues[0] = 1;
			clickScript1 = footPrint1.GetComponent<Click>();
			clickScript1.footprintvalues[0] = 1;
			clickScript2 = footPrint2.GetComponent<Click>();
			clickScript2.footprintvalues[0] = 1;
			clickScript3 = footPrint3.GetComponent<Click>();
			clickScript3.footprintvalues[0] = 1;
			clickScript4 = footPrint4.GetComponent<Click>();
			clickScript4.footprintvalues[0] = 1;
		}
		else if (gameObject.name == "footprint1") {
			if (footprintvalues[0] == 1) {
                footPrintFadeOut();
				Destroy(gameObject);
				footprintvalues[1] = 1;
				clickScript2 = footPrint2.GetComponent<Click>();
				clickScript2.footprintvalues[1] = 1;
				clickScript3 = footPrint3.GetComponent<Click>();
				clickScript3.footprintvalues[1] = 1;
				clickScript4 = footPrint4.GetComponent<Click>();
				clickScript4.footprintvalues[1] = 1;
				
			}
		}
		
		else if (gameObject.name == "footprint2") {
			if (BeforeAllOne(2)) {
                footPrintFadeOut();
				Destroy(gameObject);
				footprintvalues[2] = 1;
				clickScript3 = footPrint3.GetComponent<Click>();
				clickScript3.footprintvalues[2] = 1;
				clickScript4 = footPrint4.GetComponent<Click>();
				clickScript4.footprintvalues[2] = 1;
			}
		}
		
		else if (gameObject.name == "footprint3") {
			if (BeforeAllOne(3)){
                footPrintFadeOut();
				Destroy(gameObject);
				footprintvalues[3] = 1;
				clickScript4 = footPrint4.GetComponent<Click>();
				clickScript4.footprintvalues[3] = 1;
			}
		}
		
		else if (gameObject.name == "footprint4") {
			if (BeforeAllOne(4)){
                footPrintFadeOut();
				Destroy(gameObject);
				footprintvalues[4] = 1;
                GameObject.Find("mound").GetComponent<SpriteChangeMound>().allowMound = true;
			}
		}
	}
	
	bool BeforeAllOne(int idx) {
		bool allOne = true;
		for (int i = 0; i < idx; i++){
			if (footprintvalues[i] != 1){
				allOne = false;
				return allOne;
			}
		}
		return allOne;
	}

    void footPrintFadeOut(){
        //float a = 1;
        //while (a > 0.01){
        //    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, a);
        //    a -= 0.0000001f;
        //}
    }
}
