using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeMound: MonoBehaviour {

    const int MOUNDCLOSED = 1;
    const int MOUNDOPEN = 2;

    public Sprite mound_open;
    public Sprite mound_closed;

    private int STATE = MOUNDCLOSED;

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = mound_closed;
    }

    private void OnMouseDown()
    {

        //Debug.Log(gameObject.name);

        if (STATE == MOUNDCLOSED)
        {
            GetComponent<SpriteRenderer>().sprite = mound_open;
            STATE = MOUNDOPEN;
        }

        if (STATE == MOUNDOPEN)
        {
            GameObject.Find("gun").GetComponent<Renderer>().enabled = true;
            MouseDrag MouseDragScript;
            MouseDragScript = GameObject.Find("gun").GetComponent<MouseDrag>();
            MouseDragScript.canbedragged = true;
            Debug.Log("drag now");
        }

    }
	
}
