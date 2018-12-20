using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

	public string yourName;
	public GameObject jumpCollisionBox;
	public GameObject platformCB;
	public int jumpFactor;
	public int walkForce;

	//private int i = 0;

	// Start is called before the first frame update
	void Start()
    {
		Debug.Log("Y'all bitches best be readY " + yourName);

	}

    // Update is called once per frame
    void Update()
    {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		Collider2D jumpBox = jumpCollisionBox.GetComponent<Collider2D>();
		Collider2D platCB = platformCB.GetComponent<Collider2D>();

		bool spacebar = Input.GetKeyDown("space");

		bool aKey = Input.GetKey("a");
		bool dKey = Input.GetKey("d");

		//jump stuff
		bool onGround = jumpBox.IsTouchingLayers(8);
		Debug.Log(onGround);
		bool jumpTest = spacebar && onGround;

		if (jumpTest == true)
		{
			rb.AddForce(Vector2.up * jumpFactor);
			Debug.Log("jump");
		}

		if (dKey == true)
		{
			rb.AddForce(Vector2.right * walkForce);
		}

		if (aKey == true)
		{
			rb.AddForce(Vector2.left * walkForce);
		}
		
    }
}
