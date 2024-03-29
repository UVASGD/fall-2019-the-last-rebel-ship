﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShotgunShooting : MonoBehaviour
{
	public Transform FirePoint;
	public Transform FirePoint2;
	public Transform FirePoint3;


	public GameObject bulletPrefab;
	public float bulletForce = .1f;
	public float timeBetweenShots = .333333f;  // Allow 3 shots per secon
	private float timestamp;
    public Text test;

	// Update is called once per frame
	void Update()
	{
		if (Time.time >= timestamp && (Input.GetKey(KeyCode.B)))
		{
			Shoot();
			timestamp = Time.time + timeBetweenShots;
		}
	}


	void Shoot()
	{
		var right45 = (FirePoint2.forward + FirePoint2.right).normalized;
		var left45 = (FirePoint3.forward - FirePoint3.right).normalized;
		GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
		GameObject bullet2 = Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);
		GameObject bullet3 = Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Rigidbody2D ship = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().rb;
        var velValue = ship.velocity.magnitude;
        float force = velValue+bulletForce;

        bullet.AddComponent<BounceBullet>();
        bullet2.AddComponent<BounceBullet>();
        bullet3.AddComponent<BounceBullet>();


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
		Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();

		Collider2D c = bullet.GetComponent<Collider2D>();
		Physics2D.IgnoreCollision(c, GetComponent<Collider2D>());
		Collider2D c2 = bullet2.GetComponent<Collider2D>();
		Physics2D.IgnoreCollision(c2, GetComponent<Collider2D>());
		Collider2D c3 = bullet3.GetComponent<Collider2D>();
		Physics2D.IgnoreCollision(c3, GetComponent<Collider2D>());



        rb.AddForce(FirePoint.up * force, ForceMode2D.Impulse);
		rb2.AddForce(right45 * force, ForceMode2D.Impulse);
		rb3.AddForce(left45 * force, ForceMode2D.Impulse);


        test.text = (FirePoint.up * force).ToString();

    }
}
