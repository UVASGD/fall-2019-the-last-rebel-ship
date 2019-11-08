using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMine : MonoBehaviour
{
    public float acceleration;
    public float range;
    GameObject player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 toPlayer = player.transform.position - this.transform.position;

        if(toPlayer.magnitude < range) {
            //gravitate towards player.

            float force_mag = acceleration / toPlayer.sqrMagnitude;

            rb.AddForce(force_mag * toPlayer.normalized);
        }
    }
}
