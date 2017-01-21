using UnityEngine;
using System.Collections;

public class Misil : MonoBehaviour {

    private float speed;    //Speed of the missil
    private float addSpeed; //Speed that will be add

	// Use this for initialization
	void Start () 
    {
        speed = 1.0f;
        addSpeed = 0.5f;
	}
	
    // Update is called once per frame
    void Update()
    {
        //Add speed to make it looks faster
        speed += addSpeed;
    }

	
	void FixedUpdate () 
    {
        //Translate missil forward. If is player missil is looking at mouse position.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
