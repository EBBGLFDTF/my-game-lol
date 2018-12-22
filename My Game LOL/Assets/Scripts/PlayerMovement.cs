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
	// true for left, false for right

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
		Vector2 spawn = new Vector2(0, 1.5f);
		FallingThing bomb = projectile.GetComponent<FallingThing>();
		if (direction == "right")
		{
			bomb.direction = new Vector2(throwStrength / 10, 1);
			Debug.Log("shoot direction: right");
		}
		else if(direction == "left")
		{
			bomb.direction = new Vector2(-throwStrength / 10, 1);
			Debug.Log("shoot direction: left");
		}
		else if (direction == "up")
		{
			bomb.direction = new Vector2(0, throwStrength * .67f);
			Debug.Log("shoot direction: up");
		}
		Instantiate(projectile, rb.position + spawn, transform.rotation);
	}
}
