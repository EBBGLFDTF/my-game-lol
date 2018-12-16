using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

	public string yourName;	


    // Start is called before the first frame update
    void Start()
    {
		Debug.Log("Y'all bitches best be readY" + yourName);
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
