using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float bounce;
	public float movementSpeed;
	private Rigidbody2D rb;
	private Vector2 movePrev;
	private Transform t;
    
	// Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		t = GetComponent<Transform>();
		rb.velocity = new Vector2(movementSpeed, 0);
		movePrev = new Vector2(rb.velocity.x, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<HealthSystem>().Damage(4);
			Bounce();
			Debug.Log("enemy bounced off player");
		}
		else
		{
			Bounce();
			//Debug.Log("enemy bounced");
		}
	}

	private void Bounce()
	{
		rb.velocity = new Vector2(-movePrev.x, bounce);
		movePrev = new Vector2(rb.velocity.x, bounce);
	}
}
