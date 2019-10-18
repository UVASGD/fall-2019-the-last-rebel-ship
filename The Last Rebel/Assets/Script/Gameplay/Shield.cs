using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    bool shieldActive;
    CircleCollider2D myCollide;
    GameObject player;
    BoxCollider2D playerCollide;
    SpriteRenderer myRender;
    int hitsLeft;
    float regenerationTimer;
    float cooldownTime;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = 5;

        hitsLeft = 1;
        regenerationTimer = 0;
        shieldActive = true;
        player = GameObject.FindWithTag("Player");
        playerCollide = player.GetComponent<BoxCollider2D>();
        playerCollide.enabled = false;
        myRender = this.GetComponent<SpriteRenderer>();
        myRender.enabled = shieldActive;
        myCollide = GetComponent<CircleCollider2D>();
        this.transform.parent = player.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        if (regenerationTimer > 0)
        {
            regenerationTimer -= Time.deltaTime;
        }
        else
        {
            hitsLeft = 1;
        }

        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            if (hitsLeft <= 0 || regenerationTimer>0)
            {
                Debug.Log("Your shield is dead sorry");
            }
            else
            {
                switchShieldState();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy") { 
            hitShield();
        }
    }

    void switchShieldState()
    {
        Debug.Log("Shield state switched");
        myCollide.enabled = !myCollide.enabled;
        playerCollide.enabled = !playerCollide.enabled;
        myRender.enabled = !myRender.enabled;
    }

    void hitShield() {
        Debug.Log("Shields have been hit!");
        hitsLeft--;

        Invoke("switchShieldState", 1);

        //switchShieldState();
        regenerationTimer = cooldownTime; // sets the timer so that you can't use the shield for a bit
    }
}
