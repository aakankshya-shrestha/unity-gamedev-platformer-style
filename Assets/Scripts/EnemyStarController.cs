using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarController : MonoBehaviour
{
    public float speed;
	public PlayerController player;
	public GameObject impactEffect;
	//public float rotationSpeed;
	public int damageToGive;
	
	private Rigidbody2D rigidbody2D;
	
	// Use this for initialization
	void Start ()
	{
		this.rigidbody2D = GetComponent<Rigidbody2D> ();
		this.player = FindObjectOfType<PlayerController> ();
		
		if (this.player.transform.position.x < transform.position.x) {
			this.speed = -this.speed;
			//this.rotationSpeed = -this.rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.rigidbody2D.velocity = new Vector2 (this.speed, this.rigidbody2D.velocity.y);
		//this.rigidbody2D.angularVelocity = this.rotationSpeed;
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "player") {
			Debug.Log("Hit Player");

			HealthManager.HurtPlayer(damageToGive);
		
		}
		
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
		
	}
}
