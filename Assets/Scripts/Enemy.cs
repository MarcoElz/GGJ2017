using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    //public int damage;  //Damage of the enemy
    public float speed; //Speed of the enemy

    private const string TAG_PLAYER = "Player"; //Player Tag
    private const string TAG_RADAR = "Radar"; //Player Tag
    private const string TAG_PLAYERMISSIL = "PlayerMissil"; //Player Missil


    private Animator animator;

    void Awake()
    {
        //Get component Submarine of the player

        animator = GetComponent<Animator>();
    }

    //Radar Trigger Enter
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(TAG_RADAR))
        {
            //Light on
            animator.SetTrigger("LightUp");
        }
    }

    //If trigger founds player move to it.
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals(TAG_PLAYER))
        {
            Vector2 movePos = (other.transform.position - this.transform.position).normalized; //Vector to move
            transform.Translate(movePos * speed * Time.deltaTime); //Move to the player
        }
    }

    //If collide with player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals(TAG_PLAYERMISSIL))
        {
            Destroy(this.gameObject);
            GameMaster.instance.AddScore(1000);
        }
    }

}
