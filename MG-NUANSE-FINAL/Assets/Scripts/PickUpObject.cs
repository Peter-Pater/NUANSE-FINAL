using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    SpriteRenderer state1Renderer;
    public SpriteRenderer state2Renderer;


    public TransConditions conditions;
    bool isConditionsCounted = false;


    bool isObjectPicked = false;


	// Use this for initialization
	void Start () {
        state1Renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isObjectPicked){
            if (state1Renderer.color.a >= 0.01f){
                state1Renderer.color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);
            }else{
                state1Renderer.color = new Color(1, 1, 1, 0);
            }

            if (state2Renderer.color.a <= 0.99f)
            {
                state2Renderer.color += new Color(0, 0, 0, 0.5f * Time.deltaTime);
            }
            else
            {
                state2Renderer.color = new Color(1, 1, 1, 1);
            }
        }
	}

    private void OnMouseDown()
    {
        isObjectPicked = true;

        if (conditions != null && !isConditionsCounted){
            conditions.conditionsMet += 1;
            isConditionsCounted = true;
        }
       
    }
}
