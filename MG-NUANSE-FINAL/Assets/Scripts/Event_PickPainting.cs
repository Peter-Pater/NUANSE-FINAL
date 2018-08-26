using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PickPainting : MonoBehaviour {

    SpriteRenderer paintingGround;
    public SpriteRenderer paintingWall;

    bool isPiantingRecovered = false;


	// Use this for initialization
	void Start () {
        paintingGround = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isPiantingRecovered){
            if (paintingGround.color.a >= 0.01f){
                paintingGround.color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);
            }else{
                paintingGround.color = new Color(1, 1, 1, 0);
            }

            if (paintingWall.color.a <= 0.99f)
            {
                paintingWall.color += new Color(0, 0, 0, 0.5f * Time.deltaTime);
            }
            else
            {
                paintingWall.color = new Color(1, 1, 1, 1);
            }
        }
	}

    private void OnMouseDown()
    {
        isPiantingRecovered = true;
       
    }
}
