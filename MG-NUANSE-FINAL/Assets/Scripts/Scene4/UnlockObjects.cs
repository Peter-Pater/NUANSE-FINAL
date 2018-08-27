using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObjects : MonoBehaviour {

    public GameObject obj2Unlock;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        obj2Unlock.GetComponent<ObjectLock>().isLocked = false;
    }
}
