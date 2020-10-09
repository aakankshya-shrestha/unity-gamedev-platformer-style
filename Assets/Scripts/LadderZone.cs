using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour
{
    private PlayerController thePlayer;

	// Use this for initialization
	void Start ()
	{
		this.thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "player") {
			this.thePlayer.onLadder = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "player") {
			this.thePlayer.onLadder = false;
		}
	}
}
