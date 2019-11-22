
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingShooting : MonoBehaviour
{ 
    public Transform FirePoint;
	public GameObject bulletPrefab;
	public float bulletForce = .001f;
	public float range = 5;
	public float fireRate = 2;
	public float timeBetweenShots;
	private float timestamp;
	private Transform target;


	// Start is called before the first frame update
	void Start()
	{
		timeBetweenShots = (1 / fireRate);
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
		bullet.AddComponent<SlowingBullet>();
        bullet.GetComponent<SlowingBullet>().direction = FirePoint.up * bulletForce;
        Collider2D c = bullet.GetComponent<Collider2D>();
		Physics2D.IgnoreCollision(c, GetComponent<Collider2D>());
		//Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		//rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
        
	}
}

