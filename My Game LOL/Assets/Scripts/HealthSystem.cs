﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	public int health;
	public string harmedBy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (health <= 0)
		{
			Destroy(gameObject);
		}
    }

	void OnCollisionEnter(Collision collision)
	{

	}

	public void Damage(int n)
	{
		health = health - n;
	}
}