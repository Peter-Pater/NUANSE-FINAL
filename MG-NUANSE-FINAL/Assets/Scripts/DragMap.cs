using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMap : MonoBehaviour {

    private Vector3 screenPoint;

    private float mouseDownPositionX;
    private float offset;

    private Vector3 cameraPositionOrigin;
    private Vector3 cameraPosition; // TO DO: TAKE CAMERA BACK AT TRANSITION

    private GameObject camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Main Camera");
        cameraPositionOrigin = camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //OnMouseDown();
        //OnMouseDrag();
	}

    void OnMouseDown()
    {
        //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        mouseDownPositionX = Input.mousePosition.x;
    }

    void OnMouseDrag(){

        //Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        //Debug.Log(transform.position);
        offset = mouseDownPositionX - Input.mousePosition.x;
        Debug.Log(offset);
        if (!((offset < 0 && camera.transform.position.x <= -0.7) || (offset > 0 && camera.transform.position.x >= 6.8))){ //0.3 to reconcile
            if (offset < -4){
                offset = -4;
            }else if(offset > 4){
                offset = 4;
            }
            camera.transform.position = new Vector3(camera.transform.position.x + offset * 0.1f, camera.transform.position.y, camera.transform.position.z);
        }
        mouseDownPositionX = Input.mousePosition.x;
        Debug.Log(camera.transform.position.x);
    }
}
