using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour { // The script makes transition into the next scene.

    public GameObject cameraObj;
    public GameObject nextSceneObj;
    Transform startingPoint;
    public int nextScene = 0;
    public GameObject[] scenes = new GameObject[6];
    public bool transitCommand = false;

    bool sceneLock = false;


    SpriteRenderer curtainRenderer;
    float curtainOpacity = 0; // Used to change opacity of the black curtain in front of camera.


    // Keep track of transition state
    public bool isTransiting = false;
    public bool isRelocateComplete = false;
    public float curtainOpacSpeed = 0.5f;

    public bool isThisScenePassed = false;
    AudioSource myAudio;



	// Use this for initialization
    void Start () {
        curtainRenderer = cameraObj.transform.GetChild(0).GetComponent<SpriteRenderer>();
        startingPoint = nextSceneObj.transform.GetChild(0);
        myAudio = GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {
        //Debug.Log(nextSceneObj);

        CheckCondition();
        if (isTransiting)
        {
            StartCoroutine(delayTransit(2));
        }else{
            StopAllCoroutines();
        }        
	}


    void CheckCondition(){

        if ((transitCommand == true || Input.GetKeyDown("space")) && nextScene <= 5){

            //Debug.Log(isThisScenePassed);

            if (!isThisScenePassed)
            {
                isTransiting = true;
                isThisScenePassed = true;
                StartCoroutine(delayAudio(3.6f));
            }

        }
    }

    public IEnumerator delayAudio(float waitTime){
        yield return new WaitForSeconds(waitTime);
        myAudio.Play();
    }

    public IEnumerator delayTransit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Debug.Log(curtainRenderer.color.a);
        if (isTransiting)
        {
            if (!isRelocateComplete)
            {

                // Start transiting.
                // Disable player movement.
                // Lock camera.
                //cameraObj.GetComponent<Camera_Movement>().LockCamera();


                // Fade in the black curtain
                // so that camera view fades to black.
                while (curtainRenderer.color.a < 1 - curtainOpacSpeed)
                {
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainRenderer.color.a + Time.deltaTime * curtainOpacSpeed);
                    yield return null;
                }

                // After camera view faded to black,
                // relocate player and camera to the new position.
                //player.transform.position = targetPosObj.transform.position;
                if (!sceneLock){
                    startingPoint = nextSceneObj.transform.GetChild(0);
                    cameraObj.transform.position = startingPoint.position;
                    sceneLock = true;
                    if (nextScene < 5)
                    {
                        nextScene += 1;
                        nextSceneObj = scenes[nextScene];
                    }
                    else if (nextScene == 5)
                    {
                        nextScene++;
                    }
                }
                isRelocateComplete = true;
            }
            else
            {

                // After completing relocating player and camera,
                // black curtain fades out so that camera view comes back.
                while (curtainRenderer.color.a > curtainOpacSpeed)
                {
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainRenderer.color.a - Time.deltaTime * curtainOpacSpeed);
                    yield return null;
                }
                // After camera view is back,
                // reenable player movement.
                // Transition complete.
                isTransiting = false;
                isRelocateComplete = false;
                isThisScenePassed = false;
                transitCommand = false;
                sceneLock = false;
            }
        }


    }

    void doTransition(){
        //StopAllCoroutines();
        if (isTransiting)
        {
            if (!isRelocateComplete)
            {

                // Start transiting.
                // Disable player movement.
                // Lock camera.
                //cameraObj.GetComponent<Camera_Movement>().LockCamera();


                // Fade in the black curtain
                // so that camera view fades to black.
                while(curtainRenderer.color.a < 1 - curtainOpacSpeed){
                    Debug.Log(curtainRenderer.color.a);           
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainRenderer.color.a + Time.deltaTime * curtainOpacSpeed);
                }

                // After camera view faded to black,
                // relocate player and camera to the new position.
                //player.transform.position = targetPosObj.transform.position;
                startingPoint = nextSceneObj.transform.GetChild(0);
                cameraObj.transform.position = startingPoint.position;
                if (nextScene < 5)
                {
                    nextScene += 1;
                    nextSceneObj = scenes[nextScene];
                }
                else if (nextScene == 5)
                {
                    nextScene++;
                }
                isRelocateComplete = true;
            }
            else
            {

                // After completing relocating player and camera,
                // black curtain fades out so that camera view comes back.
                while (curtainRenderer.color.a > curtainOpacSpeed)
                {
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainRenderer.color.a - Time.deltaTime * curtainOpacSpeed);
                }
                // After camera view is back,
                // reenable player movement.
                // Transition complete.
                isTransiting = false;
                isRelocateComplete = false;
                isThisScenePassed = false;
                transitCommand = false;
            }
        }
    }


}
