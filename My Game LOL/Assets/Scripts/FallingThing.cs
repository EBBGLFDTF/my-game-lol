using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThing : MonoBehaviour
{
	public float fallSpeed;
	private Rigidbody2D rb;
	private Transform t;
	
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		rb.position = rb.position + (Vector2.down * fallSpeed / 100);
    }

	void OnCollisionEnter2D()
	{
		Destroy(gameObject);
		Debug.Log("it blew up");
	}
}
