using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Transform location = player.transform;

        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(this.transform.position.x - location.position.x), -(this.transform.position.y - location.position.y)));


    }
}
