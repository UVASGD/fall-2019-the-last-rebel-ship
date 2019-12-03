using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    int tractorOn = 0;
    GameObject player;
    PolygonCollider2D polycol;
    Collider2D[] rh;
    ContactFilter2D cf = new ContactFilter2D();

    void Start()
    {
        player = GameObject.Find("Player");
        polycol = player.GetComponent<PolygonCollider2D>();
        cf.NoFilter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (tractorOn == 0)
            {
                tractorOn = 1;
            } else
            {
                tractorOn = 0;
            }
        }
        if (tractorOn == 1)
        {
            rh = new Collider2D[10];
            polycol.OverlapCollider(cf, rh);
            for (int i = 0; i < rh.Length; i++)
            {
                if (rh[i] != null && rh[i].name != "Player")
                {
                    GameObject enemy = GameObject.Find(rh[i].name);
                    Rigidbody2D enemyrb = enemy.GetComponent<Rigidbody2D>();
                    var enemypos = enemy.transform.position;
                    var playerpos = player.transform.position;
                    Vector2 dirvec2 = (playerpos - enemypos).normalized;
                    Vector2 forcevec = dirvec2 * 2;
                    enemyrb.AddForce(forcevec);
                }
            }
        }
    }
}
