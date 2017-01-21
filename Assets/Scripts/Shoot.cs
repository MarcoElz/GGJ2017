using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject misil;    //Misil prefab
    public Transform misilShooter;  //Position of the shooter part

    private float timeBetweenShoots;    //Time between twho misil shoot
    private float timeLastShoot;        //Time of last shoot

    public bool canShoot;           //can player shoot?

	// Use this for initialization
	void Start () 
    {
	
        timeBetweenShoots = 2.0f;
        timeLastShoot = 0.0f;
        canShoot = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Shoot
        if (Time.time > timeLastShoot + timeBetweenShoots)
            canShoot = true;
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            timeLastShoot = Time.time;
            Shooting();
        }
            
	}

    private void Shooting()
    {
        //Get Mouse position to get where to shoot
        Vector3 pos = Input.mousePosition;  //Get mouse position in pixels
        pos.z = -5.0f;                      //Adjust z
        pos = Camera.main.ScreenToWorldPoint(pos);  //Pixel position to transform position
        pos.z = 0;                          //Readjust z

        //Can't shoot position.x smaller than misil shooter part
        if (pos.x < misilShooter.transform.position.x)
            return;

        //Instantiate misil and look at mouse position
        GameObject misilObject = Instantiate(misil, misilShooter.transform.position, Quaternion.identity) as GameObject;
        misilObject.transform.LookAt(pos);   
    }
}
