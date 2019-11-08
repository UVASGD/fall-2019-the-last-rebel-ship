using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastJedi : MonoBehaviour
{

    public Vector2 start_velocity;

    public float power = 150f;

    public float duration = 0.25f;

    public float duration_timer = -1f;

    public float cooldown = 5f;

    public float cooldown_timer = -1f;

    public bool ramming = false;

    public static KeyCode ram_key = KeyCode.Z;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (duration_timer < 0 && ramming)
        {
            ramming = false;
            rb.velocity = start_velocity;
            gameObject.GetComponent<PlayerMove>().enabled = true;
        }
        if (Input.GetKey(ram_key) && !(cooldown_timer > 0))
        {
            ramming = true;
            cooldown_timer = cooldown;
            start_velocity = rb.velocity;
            duration_timer = duration;
            gameObject.GetComponent<PlayerMove>().enabled = false;
        }
        else if (cooldown_timer > 0)
        {
            cooldown_timer = cooldown_timer - Time.deltaTime;
        }
        if (ramming)
        {
            float accelerationX = -Mathf.Sin(Mathf.Deg2Rad * rb.rotation);
            float accelerationY = Mathf.Cos(Mathf.Deg2Rad * rb.rotation);
            Debug.Log(power);
            rb.AddForce((new Vector2(accelerationX, accelerationY)) * power);
            duration_timer = duration_timer - Time.deltaTime;
        }
    }
}
