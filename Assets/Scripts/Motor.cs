using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

    public bool canMove;

    private float xSpeed;
    private float ySpeed;

    private float minYSpeed;
    private float maxYSpeed;

    private Vector2 yVector;
    private Vector2 xVector;
    private Vector2 clampMinPosition;
    private Vector2 clampMaxPosition;

	// Use this for initialization
	void Start () 
    {
        xSpeed = 10.0f;     //Speed in x position. Don't change
        ySpeed = 0.0f;      //Speed in y position. Do change
        minYSpeed = -4.0f;  //Min y speed
        maxYSpeed = 8.0f;   //Max y speed
        clampMinPosition.x = 0.0f;  //Min position of x
        clampMinPosition.y = 0.0f;  //Min position of y
        clampMaxPosition.x = 13.0f; //Max position of x
        clampMaxPosition.y = 8.5f;  //Max position of y

        canMove = true; //Can object move?
	}
	
	// Update is called once per frame
	void Update () 
    { 
        if(canMove) //If object can move, move
            Move();

	}

    //Movement of the object
    private void Move()
    {
        //Input for Y speed.

        //If W or UpArrow
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            ySpeed += 1.0f; //GoUp
        else
            ySpeed -= 1.0f; //GoDown

        //If S or DownArrow
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            minYSpeed = -8.0f; //GoDownFaster
        else
            minYSpeed = -4.0f; //GoDownSlower

        //Clamp Y speed between min and max Y speed
        ySpeed = Mathf.Clamp(ySpeed, minYSpeed, maxYSpeed);

        //Calculate xVector and yVector
        xVector = Input.GetAxis("Horizontal")* Vector2.right * xSpeed * Time.deltaTime;
        yVector = Vector2.up * ySpeed * Time.deltaTime;

        //Translate position. 
        transform.Translate(xVector + yVector);     //Sum of xVector and yVector.
        //Clamp position to be on camera.
        Vector2 clampPos = transform.position;      
        clampPos.x = Mathf.Clamp(transform.position.x, clampMinPosition.x, clampMaxPosition.x);     //Clamp x
        clampPos.y = Mathf.Clamp(transform.position.y, clampMinPosition.y, clampMaxPosition.y);     //Clamp y
        transform.position = clampPos;      //Clamped position
    }
}
