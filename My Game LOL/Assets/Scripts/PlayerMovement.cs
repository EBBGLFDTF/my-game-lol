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
	public string shootDownButton;

	public float speed;
	public float jumpFactor;
	public float throwStrength;

	public GameObject projectile;			//this is the bomb
	public GameObject animationComponent;	//I don't know what to do with this yet

	private Rigidbody2D rb;
	private Animation animationThing;
	private float gravityOriginal;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		gravityOriginal = rb.gravityScale;
		animationThing = GetComponent<Animation>();
    }

	// Update is called once per frame
	void Update()
	{

		//le jump
		if (Input.GetKeyDown(jumpButton) == true)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpFactor);
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

		#region velocity movement script
		/*/le move left and right but velocity based doesn't work that well
		if (Input.GetKeyDown(rightButton) == true)
		{
			rb.velocity = rb.velocity + new Vector2(10, 0);
		}
		else if (Input.GetKeyDown(leftButton) == true)
		{
			rb.velocity = rb.velocity + new Vector2(-10, 0);
		}

		if (Input.GetKeyUp(rightButton) == true)
		{
			rb.velocity = rb.velocity + new Vector2(-10, 0);
		}
		if (Input.GetKeyUp(leftButton) == true)
		{
			rb.velocity = rb.velocity + new Vector2(10, 0);
		} */


		/*/le shoot bomb
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
		else if (Input.GetKeyDown(shootDownButton) == true)
		{
			ThrowBomb("down");
		} */
		#endregion

		//le shoot bomb v2 and hit people
		if (Input.GetKeyDown(shootRightButton) == true)
		{
			Punch(1,0);
			//ThrowBomb(1, 0, 16, 0.2f);
			Debug.Log("shoot direction: right");
		}
		else if (Input.GetKeyDown(shootLeftButton) == true)
		{
			Punch(-1,0);
			//ThrowBomb(-1, 0, -16, 0.2f);
			Debug.Log("shoot direction: left");
		}
		else if (Input.GetKeyDown(shootUpButton) == true)
		{
			ThrowBomb(0, 1.5f, 0, 1f);
			Debug.Log("shoot direction: up");
		}
		else if (Input.GetKeyDown(shootDownButton) == true)
		{
			ThrowBomb(0, -1.5f, 0, -1f);
			Debug.Log("shoot direction: down");
		}

	}
#region Old Throw Script
	/* old bombThrowScript
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
		else if (direction == "left")
		{
			Vector2 spawn = new Vector2(-1f, 0);
			bomb.direction = new Vector2(-throwStrength * 9f, 0.7f);
			Debug.Log("shoot direction: left");
			Instantiate(projectile, rb.position + spawn, transform.rotation);
		}
		else if (direction == "up")
		{
			Vector2 spawn = new Vector2(0, 1.5f);
			bomb.direction = new Vector2(0, throwStrength * 0.78f);
			Debug.Log("shoot direction: up");
			Instantiate(projectile, rb.position + spawn, transform.rotation);
		}
		else if (direction == "down")
		{
			Vector2 spawn = new Vector2(0, -1.5f);
			bomb.direction = new Vector2(0, throwStrength * -0.78f);
			Debug.Log("shoot direction: down");
			Instantiate(projectile, rb.position + spawn, transform.rotation);
		}
	}
	*/
#endregion

	void ThrowBomb(float spawnX, float spawnY, float throwX, float throwY)
	{
		//recoil
		rb.velocity = rb.velocity + new Vector2(-throwX / 2, throwY);

		FallingThing bomb = projectile.GetComponent<FallingThing>();
		Vector2 spawn = new Vector2(spawnX, spawnY);
		bomb.direction = new Vector2(throwStrength * throwX, throwStrength * throwY);
		Instantiate(projectile, rb.position + spawn, transform.rotation);
	}

	void Punch(float xSpawn, float ySpawn)
	{
		GameObject punch = new GameObject("punch");
		punch.AddComponent<Rigidbody2D>();
		punch.AddComponent<CircleCollider2D>();
		punch.AddComponent<Hitbox>();
		Rigidbody2D punchRb = punch.GetComponent<Rigidbody2D>();
		CircleCollider2D punchCol = punch.GetComponent<CircleCollider2D>();
		Hitbox punchHB = punch.GetComponent<Hitbox>();

		punchRb.bodyType = RigidbodyType2D.Kinematic;
		punchRb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

		punchHB.source = gameObject;
		punchHB.xSpawn = xSpawn;
		punchHB.ySpawn = ySpawn;
		punchHB.dmg = 10;
		punchHB.activeFrames = 30;
	}
}
