using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public int i;
	
    // Start is called before the first frame update
    void Start()
    {
		i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
		if (i == 5)
		{
			Destroy(gameObject);
		}
    }

	void OnCollisionStay2D(Collision2D collision)
	{
		Vector2 rad = collision.gameObject.transform.position - transform.position;
		float magnitude = 3 - rad.magnitude;
		Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = rb.velocity + (rad * magnitude * 1.5f);
		Debug.Log("magnitude: " + (rb.velocity));

		if (collision.gameObject.tag == "enemy")
		{
			Destroy(collision.gameObject);
			Debug.Log("enemy blew up");
		}
	}
}
