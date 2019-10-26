using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{

    public static List<GravityBody> ALL_BODIES;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if(ALL_BODIES == null) {
            ALL_BODIES = new List<GravityBody>();
        }

        ALL_BODIES.Add(this);

        rb = GetComponent<Rigidbody2D>();
    }

    void OnDestroy() {
        ALL_BODIES.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
