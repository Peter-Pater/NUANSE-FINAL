using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareControllerScript : MonoBehaviour {

    char state = 's';

	private void OnMouseDown()
	{

        Sprite square = Resources.Load<Sprite>("Square");
        Sprite circle = Resources.Load<Sprite>("Circle");

        Debug.Log("Clicked!");

        if (state == 's'){
            state = 'c';
            GetComponent<SpriteRenderer>().sprite = circle;
        }else{
            state = 's';
            GetComponent<SpriteRenderer>().sprite = square;
        }
	}
}
