using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {
    private Vector3 screenPoint;
	private Vector3 offset;
	public bool canbedragged = false;
    private bool throwGun = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//OnMouseDown();
		//OnMouseDrag();
        toThrowGun();
	}
		
	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
		
	void OnMouseDrag(){
		if (canbedragged){
        	Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        	Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        	transform.position = cursorPosition;
	    }
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name == "Well")
        {
            canbedragged = false;
            throwGun = true;
        }

        if (collision.gameObject.name == "gun_catcher" && canbedragged == false){
            Destroy(gameObject);
        }
	}

    void toThrowGun(){
        if (throwGun == true){
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("gun_thrower").transform.position, 5 * Time.deltaTime);   
        }

        if (transform.position == GameObject.Find("gun_thrower").transform.position){
            throwGun = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

}