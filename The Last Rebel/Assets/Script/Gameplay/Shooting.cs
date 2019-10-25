using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float bulletForce = .1f;
    public float timeBetweenShots = .333333f;  // Allow 3 shots per secon
    private float timestamp;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp && (Input.GetKey(KeyCode.Space)))
        {
            Shoot();
            timestamp = Time.time + timeBetweenShots;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.AddComponent<Bullet>();
		Collider2D c = bullet.GetComponent<Collider2D>();
		Physics2D.IgnoreCollision(c, GetComponent<Collider2D>());
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
