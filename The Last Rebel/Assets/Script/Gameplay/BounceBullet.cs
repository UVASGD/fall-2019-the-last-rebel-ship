using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		//Check collision name
		if (col.gameObject.tag == "Enemy")
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().score += 1;
            var force = transform.position - col.transform.position;
            force.Normalize();
            var magnitude = 200;
            Destroy(col.gameObject);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);
        }
	}
	// Update is called once per frame
	void Update()
	{

	}
}
