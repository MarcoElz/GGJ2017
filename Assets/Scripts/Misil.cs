using UnityEngine;
using System.Collections;

public class Misil : MonoBehaviour {

    private float speed;
    private float addSpeed;

	// Use this for initialization
	void Start () 
    {
        speed = 1.0f;
        addSpeed = 0.5f;
	}
	
    void Update()
    {
        speed += addSpeed;
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
