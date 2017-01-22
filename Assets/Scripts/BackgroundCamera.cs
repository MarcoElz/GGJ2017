using UnityEngine;
using System.Collections;

public class BackgroundCamera : MonoBehaviour {

    private float minX;
    private float maxX;

    private float speed;


	// Use this for initialization
	void Start () 
    {
        minX = 5.0f;
        maxX = 50.0f;
        speed = 0.4f;
        //speed = 1;
	
	}
	
	void FixedUpdate () 
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        Vector3 actualPos = this.transform.position;
        Vector3 clampedPos = new Vector3(Mathf.Clamp(actualPos.x, minX, maxX), actualPos.y, actualPos.z);
        transform.position = clampedPos;
	}
}
