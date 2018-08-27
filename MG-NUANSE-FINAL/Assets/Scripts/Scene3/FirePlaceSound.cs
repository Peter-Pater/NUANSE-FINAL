using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceSound : MonoBehaviour {
    
    public Transform cameraTrans;
    Transform thisScene;

    bool isFireOn = true;
    bool isFireSoundOn = false;


    AudioSource fireAudioPlayer;


	// Use this for initialization
	void Start () {
        thisScene = transform.parent.GetChild(0);
        fireAudioPlayer = transform.GetChild(0).GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isFireOn && cameraTrans.position == thisScene.position){
            if (!isFireSoundOn){
                fireAudioPlayer.Play();
                isFireSoundOn = true;
            }
        }else{
            fireAudioPlayer.Stop();
            isFireSoundOn = false;
        }
	}


    private void OnMouseDown()
    {
        isFireOn = false;
    }
}
