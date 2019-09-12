using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManagement : MonoBehaviour {

	public enum Direction
	{
		North,
		South,
		East,
		West
	};

	public GameObject emptySector;
	public Direction direction;

	Sector sector;

	// Use this for initialization
	void Start () 
	{
		sector = this.transform.GetComponentInParent<Sector> ();
		emptySector = sector.emptySector;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			Debug.Log ("Hit!");
			float x = 0;
			float y = 0;

			int newBorderToDelete = 0;

			switch (direction) {
			case Direction.North:
				y += sector.height;
				newBorderToDelete = 3;
				break;
			case Direction.South:
				y -= sector.height;
				newBorderToDelete = 0;
				break;
			case Direction.East:
				x += sector.width;
				newBorderToDelete = 1;
				break;
			case Direction.West:
				x -= sector.width;
				newBorderToDelete = 2;
				break;
			}

			GameObject newSector = GameObject.Instantiate (emptySector);
			newSector.GetComponent<Sector> ().emptySector = emptySector;

            newSector.transform.GetChild(newBorderToDelete).gameObject.SetActive(false);
            //GameObject.DestroyImmediate(newSector.transform.GetChild(newBorderToDelete));

            Vector3 newPos = this.transform.parent.transform.position
			                 + new Vector3 (x, y, 0);
			newSector.transform.position = newPos;

            //GameObject.DestroyImmediate (this.gameObject);
            this.gameObject.SetActive(false);



		}
	}

}
