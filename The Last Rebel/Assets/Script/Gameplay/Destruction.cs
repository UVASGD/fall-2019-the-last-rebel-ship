using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public int hp = 1;
    public float immunityTime = 1.0f;
    public float timeAfterHit = 0.0f;
    public bool hasBeenHit = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit");
        if (!hasBeenHit)
        {
            hp--;
            hasBeenHit = true;
            if (hp < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void Update()
    {
        if (hasBeenHit)
        {
            timeAfterHit += Time.deltaTime;
            if(timeAfterHit > immunityTime)
            {
                hasBeenHit = false;
            }
        }
    }
}
