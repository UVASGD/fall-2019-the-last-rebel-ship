using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        if (col.gameObject.tag == "spawner")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().score += 1;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
