﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemyPatrol : MonoBehaviour
{
    private const float V = 0.4f;
    public float moveSpeed;
	public bool moveRight;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.hittingWall = Physics2D.OverlapCircle (this.wallCheck.position, this.wallCheckRadius, this.whatIsWall);
        this.notAtEdge = Physics2D.OverlapCircle (this.edgeCheck.position, this.wallCheckRadius, this.whatIsWall);

        if(hittingWall || !notAtEdge)
            moveRight = !moveRight;

        if (this.moveRight) {
			transform.localScale = new Vector3 (-V, V, V);
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
			
		} else {
			transform.localScale = new Vector3 (V, V, V);
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
			
		}
        
    }
}