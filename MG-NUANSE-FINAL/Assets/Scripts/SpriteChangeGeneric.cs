using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeGeneric : MonoBehaviour {
    
    public Sprite sprite1;
    public Sprite sprite2;
    private bool noChange = false;

    public TransConditions conditions;
    bool isConditionCounted = false;


	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = sprite1;
    }

	private void OnMouseDown(){

        //Debug.Log(gameObject.name);

        if (detectMode() == 1 && !noChange){
            noChange = true;
            changeSprite();
        }

        if (detectMode() == 2){
            changeSprite();
        }

        if (detectMode() == -1){
            Debug.Log("Wrong tag!");
        }


        if (conditions != null && !isConditionCounted){
            conditions.conditionsMet += 1;
            isConditionCounted = true;
        }
	}

    private int detectMode(){
        if (gameObject.tag == "Sprite_Change_Mode_Single"){
            return 1; //only allow change once
        }else if(gameObject.tag == "Sprite_Change_Mode_Multi"){
            return 2;
        }else{
            return -1;
        }
    }

    private void changeSprite(){
        if (GetComponent<SpriteRenderer>().sprite == sprite1){
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else{
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
    }
}
