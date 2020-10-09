using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour
{
    private ParticleSystem thisParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        //find from game
        thisParticleSystem = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (thisParticleSystem.isPlaying)
            return;
            //don't care about rest of the loop
        
        Destroy(gameObject);
    }
//to destroy remaining particles

    void onBecameInvisible(){
        Destroy(gameObject);
    }
}
