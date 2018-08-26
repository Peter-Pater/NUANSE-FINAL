using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneStateMachine : MonoBehaviour {

    int PICKEDUP = 0;
    int RINGING = 1;
    int AUDIOMESSAGEPLAYING = 2;
    int state = 0;


    public AudioClip ringingClip;
    public AudioClip messageClip;
    AudioSource myAudioPlayer;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseDown()
    {
        if (state == PICKEDUP){
            state = RINGING;

            myAudioPlayer.clip = ringingClip;
            myAudioPlayer.loop = true;
            myAudioPlayer.Play();
        }else if (state == RINGING){
            state = AUDIOMESSAGEPLAYING;

            myAudioPlayer.Stop();
            myAudioPlayer.clip = messageClip;
            myAudioPlayer.loop = false;
            myAudioPlayer.Play();
        }
    }
}
