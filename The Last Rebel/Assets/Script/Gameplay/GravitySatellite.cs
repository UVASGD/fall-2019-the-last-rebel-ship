using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySatellite : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sumForce = new Vector2(0, 0);
        foreach(GravityBody body in GravityBody.ALL_BODIES) {
            Vector2 toBody = body.gameObject.transform.position - this.gameObject.transform.position;

            if(toBody.magnitude <= float.Epsilon) {
                continue;
            }

            float force = (0.001f * this.rb.mass * body.rb.mass) / toBody.sqrMagnitude;

            sumForce += toBody.normalized * force;
        }

        rb.AddForce(sumForce, ForceMode2D.Impulse);
    }
}
