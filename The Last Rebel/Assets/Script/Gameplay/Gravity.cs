using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.Find("Player");
        var playerpos = player.transform.position;
        var playerrb = player.GetComponent<Rigidbody2D>();
        var thispos = this.transform.position;
        var thisrb = this.GetComponent<Rigidbody2D>();
        var distancetoplayer = Mathf.Sqrt((playerpos.x - thispos.x)*(playerpos.x - thispos.x) + (playerpos.y - thispos.y) * (playerpos.y - thispos.y));
        var force = (0.001 * playerrb.mass * thisrb.mass) / (distancetoplayer * distancetoplayer);
        Vector2 dirvec = (thispos - playerpos).normalized;
        Vector2 forcevec = dirvec * (float)force;
        playerrb.AddForce(forcevec);
        //print(forcevec);
    }
}
