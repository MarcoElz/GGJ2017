using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {

    public bool isLighting;

    private Light radarLight;
    private Animator animator;
    private bool canLight;

    void Awake()
    {
        radarLight = GetComponent<Light>();
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () 
    {
        canLight = true;
        animator.SetBool("CanLight", canLight);
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

}
