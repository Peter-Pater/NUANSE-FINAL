using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGeneric : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public bool canbedragged = false;
    //public bool canBeDestroyed = false;

    //public GameObject trigger;
    public GameObject target;

    private bool atTarget = false;

    public TransConditions conditions;
    public float fadeSpeed = 2f;
    bool isConditionsCounted = false;

	// Use this for initialization
	void Start() {
		
	}
	
    void Update()
    {
        if (atTarget)
        {
            if (gameObject.GetComponent<SpriteRenderer>().color.a >= 0.01f)
            {
                gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.5f * Time.deltaTime * fadeSpeed);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }

            if (target.GetComponent<SpriteRenderer>().color.a <= 0.99f)
            {
                target.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.5f * Time.deltaTime * fadeSpeed);
            }
            else
            {
                target.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                if (conditions != null && !isConditionsCounted)
                {
                    conditions.conditionsMet += 1;
                    isConditionsCounted = true;
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (canbedragged)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject == target){
            Debug.Log("Hit!");
            canbedragged = false;
            atTarget = true;
        }
	}
}
