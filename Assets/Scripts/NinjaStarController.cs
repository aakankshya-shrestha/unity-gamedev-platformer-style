using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    public float speed;
    public PlayerController player;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    public int pointsForKill;
    public int damageToGive;


    // Start is called before the first frame update
    void Start()
    {
        this.player = FindObjectOfType<PlayerController> ();

        if (this.player.transform.localScale.x < 0) {
			
            speed = -speed;
			
		}
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2 (this.speed, this.GetComponent<Rigidbody2D>().velocity.y);
		
        
    }
    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy" ) {
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
		}

        if(other.tag == "Boss"){
            other.GetComponent<BossHealthManager>().giveDamage(damageToGive);
        }
        Instantiate (this.impactEffect, transform.position, transform.rotation);
        Destroy (gameObject);
	}
}
