using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

	public GameObject toFollow;
	public Rigidbody2D shipPhysics;
	public float smoothTime = 1.0f;
	public float smoothCoefficient = 1.0f;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization 
	void Start () 
	{
		shipPhysics = toFollow.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float zSave = transform.position.z;
		smoothTime = 0.0001f;//smoothCoefficient / (shipPhysics.velocity.magnitude+.000000001f);
		transform.position = Vector3.SmoothDamp(transform.position, toFollow.transform.position, ref velocity, smoothTime);
		transform.position = new Vector3(transform.position.x, transform.position.y, zSave);
	}
}
