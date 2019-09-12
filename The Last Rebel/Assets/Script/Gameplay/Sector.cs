using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour {
	
	public float width = 300.0f;
	public float height = 300.0f;
	public float borderWidth = 100.0f;
	public int seed = 1;
    public int numStars = 10000;

	public GameObject star;

	public GameObject northernBorder;
	public GameObject southernBorder;
	public GameObject easternBorder;
	public GameObject westernBorder;

	public GameObject emptySector;

	private float prevRand = .015f; //Lews Therin Telemon

	// Use this for initialization
	void Start () 
	{
		//Place Borders
		northernBorder.transform.position.Set(0, height/2, 0);
		southernBorder.transform.position.Set(0, -height/2, 0);
		easternBorder.transform.position.Set(width/2, 0, 0);
		westernBorder.transform.position.Set(-width/2, 0, 0);

		northernBorder.transform.localScale.Set (width * 1.5f, borderWidth, 1);
		southernBorder.transform.localScale.Set (width * 1.5f, borderWidth, 1);
		easternBorder.transform.localScale.Set (borderWidth, height * 1.5f, 1);
		westernBorder.transform.localScale.Set (borderWidth, height * 1.5f, 1);

		PlaceRandomCopies (star, numStars, 10);

		Debug.Log ("Initiated Sector...");
		Debug.Log (this.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void PlaceRandomCopies(GameObject o, int density, float z)
	{
		for (int i = 0; i < density; i++) 
		{
			float x = width * Pseudorandom (seed + (int)this.transform.position.x) - width/2;
			float y = height * Pseudorandom (seed + (int)this.transform.position.y) - height/2;

			x += this.transform.position.x;
			y += this.transform.position.y;

			GameObject c = GameObject.Instantiate (o);
			c.transform.position = new Vector3 (x, y, z);
		}
	}

	public float Pseudorandom(int seed)
	{
		int a = int.MaxValue/1028;

		float interimRand = (a * prevRand + seed) % seed;
		float currentRand = ((float)interimRand) / seed;

		prevRand = currentRand;

		return currentRand;

	}

}
