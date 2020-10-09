using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToGive;
    public AudioSource pickUpEffect;

    void OnTriggerEnter2D (Collider2D other){
        if (other.GetComponent<PlayerController>() ==null)
        return;

        HealthManager.HurtPlayer(-healthToGive);
       pickUpEffect.Play();
        Destroy (gameObject);
    
    }
}
