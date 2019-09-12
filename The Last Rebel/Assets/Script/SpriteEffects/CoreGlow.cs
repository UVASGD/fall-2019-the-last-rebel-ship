using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGlow : MonoBehaviour {

	SpriteRenderer coreImage;


	// Use this for initialization
	void Start () 
	{
		coreImage = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		coreImage.color = new Color(255, 0, 0, .15f*(1+(Mathf.Sin(Time.fixedTime))));

	}
}
