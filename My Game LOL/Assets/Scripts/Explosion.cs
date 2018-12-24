using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public int i;
	public float blastPower;
	public int dmg;
	
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

	void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 rad = collision.gameObject.transform.position - transform.position;
		float magnitude = 3 - rad.magnitude;
		Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = rb.velocity + (rad * magnitude * blastPower);
		Debug.Log("magnitude: " + (rb.velocity));

		if (collision.gameObject.tag == "enemy")
		{
			collision.gameObject.GetComponent<HealthSystem>().Damage(dmg);
		}

		/* /testing
		if (collision.gameObject.tag == "enemy")
		{
			collision.gameObject.GetComponent<HealthSystem>().Damage(dmg);
			Destroy(collision.gameObject);
			Debug.Log("enemy blew up");
		}
		*/
	}
}
