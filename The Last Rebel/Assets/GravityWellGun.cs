using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWellGun : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject gravWellBulletPrefab;
    public float bulletForce = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject gravWell = Instantiate(gravWellBulletPrefab, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = gravWell.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
