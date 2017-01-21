using UnityEngine;
using System.Collections;

public class Misil : MonoBehaviour {

    private float speed;    //Speed of the missil
    private float addSpeed; //Speed that will be add
    private Vector3 movement;

	// Use this for initialization
	void Awake () 
    {
        speed = 1.0f;
        addSpeed = 0.5f;
        movement = Vector3.down;

	}
	
    // Update is called once per frame
    void Update()
    {
        //Add speed to make it looks faster
        speed += addSpeed;
    }

	
	void FixedUpdate () 
    {
        transform.Translate(movement * speed * Time.deltaTime); //Move to the player
	}

    public void SetTarget(Vector3 target)
    {
        movement = (target - transform.position).normalized;
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        Transform sprite = GetComponentInChildren<SpriteRenderer>().gameObject.transform;
        sprite.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 newRotation = sprite.rotation.eulerAngles;
        newRotation.z += 90.0f;
        sprite.eulerAngles = newRotation;
    }
}
