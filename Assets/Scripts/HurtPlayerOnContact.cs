using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    public int damageToGive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "player"){
            HealthManager.HurtPlayer(damageToGive);  
            other.GetComponent<AudioSource>().Play();

            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.knockbackLength;
            //other-player, transform- enemy
            if(other.transform.position.x < transform.position.x){
                player.knockFromRight = true;

            }
            else
                player.knockFromRight = false;

        }
    }
}
