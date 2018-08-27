using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnClick : MonoBehaviour {

    AudioSource myAudioPlayer;
    bool isAudioPlayed = false;

    const int SINGLE = 1;
    const int MULTI = 2;

    public int MODE = SINGLE;

	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseDown()
    {
        if (!isAudioPlayed){
            myAudioPlayer.Play();
            if (MODE == SINGLE){
                isAudioPlayed = true;   
            }
        }
    }
}
