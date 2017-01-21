using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

    public int damage;

    private const string TAG_PLAYER = "Player"; //Player Tag

    private Submarine player;   //Submarine object instance of the player

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<Submarine>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals(TAG_PLAYER))
        {
            player.TakeDamage(damage);  //Player take damage
            Destroy(this.gameObject);   //Destroy this GameObject
        }
    }

}
