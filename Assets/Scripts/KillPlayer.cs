﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public LevelManager levelMananger;

    // Start is called before the first frame update
    void Start()
    {
        levelMananger = FindObjectOfType<LevelManager> ();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "player"){
            levelMananger.RespawnPlayer();  

        }

    }
}
