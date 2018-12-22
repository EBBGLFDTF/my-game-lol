using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThing : MonoBehaviour
{
	public Vector2 direction;
	public float speed;

	public string explodeButton;

	public bool willExplode;
	public GameObject explosion;

	private Rigidbody2D rb;
	private Transform t;
	
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		t = GetComponent<Transform>();
		rb.AddForce(Vector2.up * direction.y * 1000);

		willExplode = false;
	}

    // Update is called once per frame
    void Update()
    {

		//le fake gravity
		//rb.position = rb.position + (Vector2.down * fallSpeed / 100);
		if (direction.x > 0)
		{
			rb.position = rb.position + (Vector2.right * Mathf.Sqrt(direction.x * direction.x));
		}
		else
		{
			rb.position = rb.position + (Vector2.left * Mathf.Sqrt(direction.x * direction.x));
		}

		//boopy
		if (Input.GetKeyDown(explodeButton) == true)
		{
			willExplode = true;
		}
    }

	void OnCollisionEnter2D()
	{

		if (willExplode == true)
		{
			Instantiate(explosion, transform.position, transform.rotation);
			Debug.Log("it blew up");
			Destroy(gameObject);
		}
	}
}
