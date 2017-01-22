using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public bool isBossMusic;
    public bool nowPlayBoss;

    public AudioClip bossClip;

    float maxVolume;

    AudioSource audioSource;
    Animator animator;


	// Use this for initialization
	void Start () {
        maxVolume = 0.7f;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isBossMusic && !nowPlayBoss)
        {
            nowPlayBoss = true;
            //ChangeClip
            audioSource.clip = bossClip;
            audioSource.Play();
        }
	
	}

    public void BeginBossMusic()
    {
        animator.SetTrigger("BossMusic");   
    }

}
