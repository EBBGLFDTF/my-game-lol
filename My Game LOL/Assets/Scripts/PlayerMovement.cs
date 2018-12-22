using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{

	public string jumpButton;
	public string leftButton;
	public string rightButton;
	public string shootLeftButton;
	public string shootRightButton;
	public string shootUpButton;

	public float speed;
	public float jumpFactor;
	public float throwStrength;

	public GameObject projectile;

	private Rigidbody2D rb;
	private CharacterController controller;
	private Vector2 move = Vector2.zero;
	private float gravityOriginal;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		controller = GetComponent<CharacterController>();
		gravityOriginal = rb.gravityScale;
		//deathBox = canKill.GetComponent<Collider2D>();
    }

	// Update is called once per frame
	void Update()
	{

		//le jump
		if (Input.GetKeyDown(jumpButton) == true)
		{
			rb.velocity = new Vector2(0, jumpFactor);
		}
		if (Input.GetKey(jumpButton) == true)
		{
			rb.gravityScale = 2;
		}
		if (Input.GetKeyUp(jumpButton) == true)
		{
			rb.gravityScale = gravityOriginal;
		}

		//le move left and right
		if (Input.GetKey(leftButton) == true)
		{
			rb.position = rb.position + (Vector2.left * speed / 10);
		}
		else if (Input.GetKey(rightButton) == true)
		{
			rb.position = rb.position + (Vector2.right * speed / 10);
		}

		/*
		//le move left and right but it's velocity based
		if (Input.GetKeyDown(leftButton) == true)
		{
			rb.velocity = rb.velocity + (Vector2.left * speed / 10);
		}
		if (Input.GetKeyUp(leftButton) == true)
		{
			rb.velocity =
		}
		*/
		//le shoot bomb
		if (Input.GetKeyDown(shootRightButton) == true)
		{
			ThrowBomb("right");
		}
		else if (Input.GetKeyDown(shootLeftButton) == true)
		{
			ThrowBomb("left");
		}
		else if (Input.GetKeyDown(shootUpButton) == true)
		{
			ThrowBomb("up");
		}
    }


	void ThrowBomb(string direction)
	{
		FallingThing bomb = projectile.GetComponent<FallingThing>();
		if (direction == "right")
		{
			Vector2 spawn = new Vector2(1f, 0);
			bomb.direction = new Vector2(throwStrength * 9f, 0.7f);
			Debug.Log("shoot direction: right");
			Instantiate(projectile, rb.position + spawn, transform.rotation);
		}
		else if(direction == "left")
		{
			Vector2 spawn = new Vector2(-1f, 0);
			bomb.direction = new Vector2(-throwStrength * 9f, 0.7f);
			Debug.Log("shoot direction: left");
			Instantiate(projectile, rb.position + spawn, transform.rotation);
		}
		else if (direction == "up")
		{
			Vector2 spawn = new Vector2(0, 1.5f);
			bomb.direction = new Vector2(0, throwStrength);
			Debug.Log("shoot direction: up");
			Instantiate(projectile, rb.position + spawn, transform.rotation);
		}
	}
}
