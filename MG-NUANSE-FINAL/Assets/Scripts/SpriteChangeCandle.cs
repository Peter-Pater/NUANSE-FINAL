using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeCandle : MonoBehaviour {

    const int HALF_CANDLE = 1;
    const int BULLET = 2;
    const int ALMOST_CANDLE = 3;
    const int FULLCANDLE = 4;
    const int DEAD_CANDLE = 5;

    public Sprite halfCandle;
    public Sprite almostCandle;
    public Sprite fullCandle;
    public Sprite deadCandle;

    private int STATE = HALF_CANDLE;

    public GameObject bullet;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = halfCandle;
	}
	
    private void OnMouseDown()
    {

        //Debug.Log(gameObject.name);

        if (STATE == HALF_CANDLE){
            bullet.SetActive(true);
            STATE = BULLET;
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.06244355f, -0.9439293f);
            GetComponent<BoxCollider2D>().size = new Vector2(1.850682f, 2.512366f);
        }else if (STATE == BULLET){
            GetComponent<SpriteRenderer>().sprite = almostCandle;
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.06244355f, -0.6454784f);
            GetComponent<BoxCollider2D>().size = new Vector2(1.850682f, 3.109268f);
            bullet.SetActive(false);
            STATE = ALMOST_CANDLE;
        }else if(STATE == ALMOST_CANDLE){
            GetComponent<SpriteRenderer>().sprite = fullCandle;
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.06244355f, -0.3097228f);
            GetComponent<BoxCollider2D>().size = new Vector2(1.850682f, 3.780779f);
            STATE = FULLCANDLE;
        }else if(STATE == FULLCANDLE){
            GetComponent<SpriteRenderer>().sprite = deadCandle;
            STATE = DEAD_CANDLE;
        }

    }
}
