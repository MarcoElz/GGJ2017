using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int damage;  //Damage of the enemy
    public float speed; //Speed of the enemy

    private const string TAG_PLAYER = "Player"; //Player Tag
    private Submarine player;   //Submarine object instance of the player

    void Awake()
    {
        //Get component Submarine of the player
        player = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<Submarine>();
    }

    //If trigger founds player move to it.
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals(TAG_PLAYER))
        {
            Vector2 movePos = (this.transform.position - other.transform.position).normalized; //Vector to move
            transform.Translate(-movePos * speed * Time.deltaTime); //Move to the player
        }
    }

    //If collide with player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals(TAG_PLAYER))
        {
            player.TakeDamage(damage);  //Player take damage
            Destroy(this.gameObject);   //Destroy this GameObject
        }
    }

}
