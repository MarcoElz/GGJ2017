using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject misil;

    public bool canShoot;
	// Use this for initialization
	void Start () 
    {
	
        canShoot = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (canShoot)
            Shooting();
	}

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = -5.0f;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.z = 0;
            Debug.Log(pos);

            GameObject misilObject = Instantiate(misil, this.transform.position, Quaternion.identity) as GameObject;
            misilObject.transform.LookAt(pos);

        }
            
    }
}
