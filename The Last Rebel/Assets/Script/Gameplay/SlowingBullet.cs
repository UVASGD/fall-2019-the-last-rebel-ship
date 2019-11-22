using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingBullet : MonoBehaviour
{
    public Vector2 direction;
    public byte directB = 8;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Check collision name
        if (col.gameObject.tag == "Player" && col is CircleCollider2D)
        {
            Destroy(gameObject);
            var vel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().rb.velocity;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().rb.velocity = -vel*3;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().rb.angularVelocity = 0;
            directB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().direction;
            directB += 4;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().rb.MoveRotation(45.0f * directB);

        }
    }

        // Update is called once per frame
        void Update()
    {
        transform.Translate(direction * Time.deltaTime, Space.World);

    }
}
