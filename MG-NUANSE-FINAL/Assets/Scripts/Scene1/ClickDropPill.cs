using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDropPill : MonoBehaviour {
	
	public float pauseTime = 5f;
	bool PillDropped = false;
	public bool StartPause = false;
    private bool enablePill = false;

	// Use this for initialization
	void Start () {
		//Debug.Log(StartPause);
	}
	
	// Update is called once per frame
	void Update () {
		if (StartPause) {
			pauseGame();
		}
		
	}
	
    public void pauseGame()
    {
        StartCoroutine(Pause());
     }
    // public IEnumerator GamePauser(){
    //   Debug.Log ("Inside PauseGame()");
    //   yield return new WaitForSeconds (5);
    //   Debug.Log("Done with my pause");
    // }
	
	IEnumerator Pause() {
        //Debug.Log("Start pause");
        Time.timeScale = 0;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime){
          yield return 0;
        }
        Time.timeScale = 1f;
        //Debug.Log("Done with pause");
	    StartPause = false;
        enablePill = true;
	}
	
	void OnMouseDown(){
        if (enablePill){
            //Debug.Log("click in drop pill");
            Debug.Log(PillDropped);
            if (!PillDropped){
                GameObject.Find("pill").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("pill").GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                PillDropped = true;
                enablePill = false;
            }   
        }
	} 
}
