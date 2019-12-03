using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    CircleCollider2D circol;
    Collider2D[] rh;
    ContactFilter2D cf = new ContactFilter2D();

    // Start is called before the first frame update
    void Start()
    {
        circol = this.gameObject.GetComponent<CircleCollider2D>();
        cf.NoFilter();
    }

    // Update is called once per frame
    void Update()
    {
        rh = new Collider2D[10];
        circol.OverlapCollider(cf, rh);
        for (int i = 0; i < rh.Length; i++)
        {
            if (rh[i] != null && rh[i].name != "Player")
            {
                GameObject enemy = GameObject.Find(rh[i].name);
                Rigidbody2D enemyrb = enemy.GetComponent<Rigidbody2D>();
                var enemypos = enemy.transform.position;
                var thispos = this.gameObject.transform.position;
                var dist = (thispos - enemypos).magnitude + 10f;
                Vector2 dirvec2 = (thispos - enemypos).normalized;
                Vector2 forcevec = dirvec2 * 1000 / (dist * dist);
                enemyrb.AddForce(forcevec);
            }
        }
    }
}
