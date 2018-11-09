using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeMound: MonoBehaviour {

    const int MOUNDCLOSED = 1;
    const int MOUNDOPEN = 2;
    public AudioSource myAudio;

    public bool allowMound = false;

    public Sprite mound_open;
    public Sprite mound_closed;

    public GameObject gun;

    private int STATE = MOUNDCLOSED;

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = mound_closed;
    }

    private void OnMouseUp()
    {

        //Debug.Log("clicked!");
        if (allowMound == true){

            if (STATE == MOUNDCLOSED)
            {
                GetComponent<SpriteRenderer>().sprite = mound_open;
                STATE = MOUNDOPEN;
                myAudio.Play();
            }
            else if (STATE == MOUNDOPEN)
            {
                gun.SetActive(true);
                MouseDrag MouseDragScript;
                MouseDragScript = gun.GetComponent<MouseDrag>();
                MouseDragScript.canbedragged = true;
                //Debug.Log("drag now");
                allowMound = false;
                myAudio.Play();
            }   
        }

    }
	
}
