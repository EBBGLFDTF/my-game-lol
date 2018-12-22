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

	public GameObject canKill;

	private Rigidbody2D rb;
	private CharacterController controller;
	private Vector2 move = Vector2.zero;
	private Collider2D deathBox;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		controller = GetComponent<CharacterController>();
		deathBox = canKill.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
		//le fake gravity
		//rb.position = rb.position + (Vector2.down * gravity / 10);

		//le jump
		if (Input.GetKeyDown(jumpButton) == true)
		{
			rb.AddForce(Vector2.up * jumpFactor);
		}

		//le move left and right
		if (Input.GetKey(leftButton) == true)
		{
			rb.position = rb.position + (Vector2.left * speed / 10);
		}

		if (Input.GetKey(rightButton) == true)
		{
			rb.position = rb.position + (Vector2.right * speed / 10);
		}

    }


	//lol doesn't work
	void OnCollisionEnter2D(Collider2D collision)
	{
		if (canKill.tag == "death")
		{
			Destroy(gameObject);
		}
	}
}
