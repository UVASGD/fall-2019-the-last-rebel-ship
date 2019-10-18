using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        GetComponent<Transform>().position = player.transform.position;

        Rigidbody2D playerRB = (Rigidbody2D)player.GetComponent("Rigidbody2D");

        Vector2 offset = new Vector2(speed * playerRB.position.x, speed * playerRB.position.y);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
