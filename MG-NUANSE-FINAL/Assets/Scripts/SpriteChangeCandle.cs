using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeCandle : MonoBehaviour {

    const int HALF_CANDLE = 1;
    const int BULLET = 2;
    const int FULLCANDLE = 3;

    public Sprite halfCandle;
    public Sprite fullCandle;
    private int STATE = HALF_CANDLE;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = halfCandle;
	}
	
    private void OnMouseDown()
    {

        //Debug.Log(gameObject.name);

        if (STATE == HALF_CANDLE){
            GameObject.Find("bullet").GetComponent<Renderer>().enabled = false;
            STATE = BULLET;
        }

        if (STATE == BULLET){
            
        }

    }
}
