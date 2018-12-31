using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
	public int dmg;
	public int activeFrames;
	public float xSpawn;
	public float ySpawn;
	public GameObject source;
	Rigidbody2D rb;
	Rigidbody2D sourceRB;

    // Start is called before the first frame update
    void Start()
    {
		sourceRB = source.GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
		rb.position = sourceRB.position + new Vector2(xSpawn, ySpawn);
    }
	private void FixedUpdate()
	{
		rb.position = new Vector2(sourceRB.position.x + xSpawn, sourceRB.position.y + ySpawn);
	}

	// Update is called once per frame
	void Update()
    {
		activeFrames = activeFrames - 1;
		if (activeFrames < 0)
		{
			Destroy(gameObject);
		}
    }

	void OnCollisionEnter(Collision collision)
	{
		HealthSystem hs = collision.gameObject.GetComponent<HealthSystem>();
		hs.Damage(dmg);
	}
}
