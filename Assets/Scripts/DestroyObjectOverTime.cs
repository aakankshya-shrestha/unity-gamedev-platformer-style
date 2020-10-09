﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour
{
    public float lifetime;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.lifetime -= Time.deltaTime;

		if (this.lifetime < 0) {
			Destroy (gameObject);
		}
	}
}
