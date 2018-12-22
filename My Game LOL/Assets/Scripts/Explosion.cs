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
}
