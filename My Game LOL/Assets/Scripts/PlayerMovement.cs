using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float jumpFactor;
	public float walkFactor;

	public string bindJump;
	public string bindLeft;
	public string bindRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		bool jump = Input.GetKeyDown(bindJump);
		bool left = Input.GetKey(bindLeft);
		bool right = Input.GetKey(bindRight);

		if (jump == true)
		{
			rb.AddForce(Vector2.up * jumpFactor);
		}

		if (left == true)
		{
			rb.AddForce(Vector2.left * walkFactor);
		}

		if (right == true)
		{
			rb.AddForce(Vector2.right * walkFactor);
		}

    }
}
