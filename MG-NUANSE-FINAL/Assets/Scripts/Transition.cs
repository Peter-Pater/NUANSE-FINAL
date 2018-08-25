using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour { // The script makes transition into the next scene.

    public GameObject cameraObj;
    public GameObject nextSceneObj;
    Transform startingPoint;


    SpriteRenderer curtainRenderer;
    float curtainOpacity = 0; // Used to change opacity of the black curtain in front of camera.


    // Keep track of transition state
    public bool isTransiting = false;
    public bool isRelocateComplete = false;

    bool isThisScenePassed = false;



	// Use this for initialization
	void Start () {
        curtainRenderer = cameraObj.transform.GetChild(0).GetComponent<SpriteRenderer>();
        startingPoint = nextSceneObj.transform.GetChild(0);
	}
	

	// Update is called once per frame
	void Update () {

        CheckCondition();

        if (isTransiting){
            if (!isRelocateComplete){

                // Start transiting.
                // Disable player movement.
                // Lock camera.
                //cameraObj.GetComponent<Camera_Movement>().LockCamera();


                // Fade in the black curtain
                // so that camera view fades to black.
                if (curtainOpacity < 0.99f){
                    curtainOpacity += 0.01f;
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainOpacity);
                }else{

                    // After camera view faded to black,
                    // relocate player and camera to the new position.
                    //player.transform.position = targetPosObj.transform.position;
                    cameraObj.transform.position = startingPoint.position;

                    isRelocateComplete = true;
                }

            }else{

                // After completing relocating player and camera,
                // black curtain fades out so that camera view comes back.
                if (curtainOpacity > 0.01f){
                    curtainOpacity -= 0.01f;
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainOpacity);
                }else{

                    // After camera view is back,
                    // reenable player movement.
                    // Transition complete.
                    isTransiting = false;
                    isRelocateComplete = false;
                }
            }
        }
	}


    void CheckCondition(){

        if (Input.GetKeyDown(KeyCode.Space)){

            if (!isThisScenePassed)
            {
                isTransiting = true;
                isThisScenePassed = true;
            }

        }
    }

}
