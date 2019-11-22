using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float bulletForce = .1f;
    public float range = 5;
    public float fireRate = 2;
    private float timeBetweenShots;
    private float timestamp;
    private Transform target;
    private Collider2D spawner;






    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = (1 / fireRate);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawner = transform.parent.gameObject.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 raycastDir = target.position - transform.position;

        if (Time.time >= timestamp && (raycastDir.magnitude < range))
        {
            Shoot();
            timestamp = Time.time + timeBetweenShots;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.AddComponent<EnemyBullet>();
        Collider2D c = bullet.GetComponent<Collider2D>();
        //Physics2D.IgnoreCollision(c, GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(c, spawner);
        //Physics2D.IgnoreCollision(c, lr);
        //Physics2D.IgnoreCollision(c, ur);
        //Physics2D.IgnoreCollision(c, ll);
        //Physics2D.IgnoreCollision(c, ul);


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}



