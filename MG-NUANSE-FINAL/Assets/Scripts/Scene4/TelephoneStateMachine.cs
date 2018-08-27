using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneStateMachine : MonoBehaviour
{

    int PICKEDUP = 0;
    int RINGING = 1;
    int AUDIOMESSAGEPLAYING = 2;
    int state = 0;
    public Collider2D polygonCo;
    public Collider2D boxCo;


    public AudioClip ringingClip;
    public AudioClip messageClip;
    AudioSource myAudioPlayer;
    float counter;

    bool isMessagePlaying = false;
    TransConditions conditions;


    // Use this for initialization
    void Start()
    {
        myAudioPlayer = GetComponent<AudioSource>();
        conditions = transform.parent.GetComponent<TransConditions>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isMessagePlaying)
        {
            if (!myAudioPlayer.isPlaying)
            {
                conditions.conditionsMet += 1;
                isMessagePlaying = false;
            }
        }
        if (state == RINGING)
        {
            counter += Time.deltaTime;
            Debug.Log(counter);
        }
    }


    private void OnMouseDown()
    {
        if (state == PICKEDUP)
        {
            state = RINGING;
            polygonCo.enabled = false;
            boxCo.enabled = true;

            myAudioPlayer.clip = ringingClip;
            myAudioPlayer.loop = true;
            myAudioPlayer.Play();
        }
        else if (state == RINGING && counter > 0.8f)
        {
            state = AUDIOMESSAGEPLAYING;
            myAudioPlayer.Stop();
            myAudioPlayer.clip = messageClip;
            myAudioPlayer.loop = false;
            myAudioPlayer.Play();
            isMessagePlaying = true;
        }
    }

}
