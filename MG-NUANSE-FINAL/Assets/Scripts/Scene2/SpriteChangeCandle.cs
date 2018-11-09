using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeCandle : MonoBehaviour {

    const int HALF_CANDLE = 1;
    const int BULLET = 2;
    const int ALMOST_CANDLE = 3;
    const int FULLCANDLE = 4;
    const int DEAD_CANDLE = 5;
    const int BACK_IN_CLOSET = 6;
    const int SCENE_END = 7;

    bool cupboard_audio_played = false;

    public AudioSource bullet_audio;
    public AudioSource candle_audio;
    public AudioSource cupboard_audio;

    public Sprite halfCandle;
    public Sprite almostCandle;
    public Sprite fullCandle;
    public Sprite deadCandle;

    private Vector3 screenPoint;
    private Vector3 offset;

    private int STATE = HALF_CANDLE;

    public GameObject bullet;
    public bool allowDragging = false;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = halfCandle;
	}

	private void Update(){
        if (STATE == BACK_IN_CLOSET){
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("candle_position").transform.position, 5 * Time.deltaTime);
            if (transform.position == GameObject.Find("candle_position").transform.position){
                STATE = SCENE_END;
                GameObject.Find("Transition").GetComponent<Transition>().transitCommand = true;
            }
        }
	}

	private void OnMouseDown()
    {

        //Debug.Log(gameObject.name);


        switch (STATE)
        {
            case HALF_CANDLE:
                bullet.SetActive(true);
                STATE = BULLET;
                bullet_audio.Play();
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.02588505f, -0.7151861f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.9001524f, 2.180191f);
                break;
            case BULLET:
                GetComponent<SpriteRenderer>().sprite = almostCandle;
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.01008403f, -0.6125971f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.8558465f, 2.473438f);
                bullet.SetActive(false);
                STATE = ALMOST_CANDLE;
                candle_audio.Play();
                break;
            case ALMOST_CANDLE:
                GetComponent<SpriteRenderer>().sprite = fullCandle;
                GetComponent<BoxCollider2D>().offset = new Vector2(0.01609588f, -0.5422899f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.8034868f, 2.543027f);
                STATE = FULLCANDLE;
                candle_audio.Play();
                break;
            case FULLCANDLE:
                GetComponent<SpriteRenderer>().sprite = deadCandle;
                STATE = DEAD_CANDLE;
                candle_audio.Play();
                break;
            case DEAD_CANDLE:
                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                allowDragging = true;
                break;
            default:
                break;
        }
    }

    void OnMouseDrag(){
        if (allowDragging){
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }
    }

	private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.name == "candle_collider"){
            Debug.Log("Collide!");
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            allowDragging = false;
            STATE = BACK_IN_CLOSET;
            GameObject.Find("closet_close_2").GetComponent<BoxCollider2D>().enabled = false;
            if(!cupboard_audio.isPlaying&&cupboard_audio_played==false){
                cupboard_audio.Play();
                cupboard_audio_played = true;
            }
        }
	}
}
