using UnityEngine;
using System.Collections;

public class Submarine : MonoBehaviour {

    public SpriteRenderer sprite;

    public int health;  //Actual Health
    private int initialHealth;  //Initial health
    private bool isDead;    //is player dead?

	// Use this for initialization
	void Start () 
    {
        initialHealth = 100;
        health = initialHealth;
        isDead = false;
	
	}

    //Reduce the actual health
    public void TakeDamage(int damage)
    {
        //If player isn't dead take damage
        if (!isDead)
        {
            health -= damage;
            UIManager.instance.UpdateHealth(health);
            StopAllCoroutines();
            sprite.enabled = true;
            StartCoroutine(DamageEffect());
        }

        //If health is zero or below zero, then is dead.
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            GameMaster.instance.GameOver(); //Game Over
        }
        
    }

    IEnumerator DamageEffect()
    {
        sprite.enabled = false;
        yield return new WaitForSeconds(0.3f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.3f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.3f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.3f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.3f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.3f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.3f);
        sprite.enabled = true;
    }
}
