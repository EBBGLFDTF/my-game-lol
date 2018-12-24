using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThing : MonoBehaviour
{
	public Vector2 direction;
	public float speed;

	public string explodeButton;

	public bool willExplode;
	public int dmg;
	public int fuse;
	public GameObject explosion;

	private Rigidbody2D rb;
	private Transform t;
	
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		t = GetComponent<Transform>();
		rb.AddForce(Vector2.up * direction.y * 100f);
		rb.velocity = new Vector2(direction.x, 0);

		willExplode = false;
		fuse = fuse * 60;
	}

    // Update is called once per frame
    void Update()
    {

		/* le keeps going for some reason and won't bounce
		if (direction.x > 0)
		{
			rb.position = rb.position + (Vector2.right * Mathf.Sqrt(direction.x * direction.x));
		}
		else
		{
			rb.position = rb.position + (Vector2.left * Mathf.Sqrt(direction.x * direction.x));
		}
		*/

		//boopy

		fuse = fuse - 1;
		if (fuse == 0)
		{
			BlowUp();
		}

		if (Input.GetKeyDown(explodeButton) == true)
		{
			willExplode = true;
		}
    }
	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "enemy")
		{
			collision.gameObject.GetComponent<HealthSystem>().Damage(dmg);
		}

		if (willExplode == true)
		{
			BlowUp();
		}
	}

	void BlowUp()
	{
		Instantiate(explosion, transform.position, transform.rotation);
		Debug.Log("it blew up");
		Destroy(gameObject);
	}
}
