﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
	public float bounce;
	private Rigidbody2D rb;
    
	// Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		rb.velocity = new Vector2(0, bounce);
		Debug.Log("enemy bounced");
	}
}
