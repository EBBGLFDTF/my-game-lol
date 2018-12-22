using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{

	public string jumpButton;
	public string leftButton;
	public string rightButton;

	public float speed;
	public float jumpFactor;
	public float gravity;

	private CharacterController controller;
	private Vector2 move = Vector2.zero;


	// Start is called before the first frame update
	void Start()
    {
		controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		//le gravity
		move.y -= gravity;
    }
}
