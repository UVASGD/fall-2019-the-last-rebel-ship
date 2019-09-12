using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoRandomGenerator : MonoBehaviour {

	public int seed = 1478996325;
	private float prevRand = .015f; //Lews Therin Telemon

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float Pseudorandom()
	{
		int a = int.MaxValue;

		float interimRand = (a * prevRand + seed) % seed;
		float currentRand = ((float)interimRand) / seed;

		prevRand = currentRand;

		return currentRand;

	}
}
