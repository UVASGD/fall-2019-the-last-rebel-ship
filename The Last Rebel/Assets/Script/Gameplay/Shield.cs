using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shield : MonoBehaviour
{

    bool shieldActive;
    bool shieldAvailable;
    CircleCollider2D myCollide;
    GameObject player;
    BoxCollider2D playerCollide;
    SpriteRenderer myRender;
    float regenerationTimer;
    float cooldownTime;
    Slider shieldHealthBar;
    float shieldHP;
    float healthcoef;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = 5;
        shieldHealthBar = GameObject.FindGameObjectWithTag("MainCanvas").GetComponentInChildren<Slider>();
        shieldHP = 100.0f;
        healthcoef = 5f; //rate at which the shield dies!
        shieldAvailable = true;
        
        //hitsLeft = 1;
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

        if (shieldActive) //if on, it dies over time
        {
            shieldHP -= healthcoef * Time.deltaTime; //shield dies over time...
            shieldHealthBar.value = shieldHP;
        }

        //if shield WAS on and the HP went under 0, the shield should die and a regeneration time should be set to equal cooldown time
        if (shieldHP<0 && shieldActive == true)
        {
            switchShieldState(); //shields need to turn off
            shieldAvailable = false;
            //hitsLeft--; //we don't
            regenerationTimer = cooldownTime;
        }

        //if shield in process of regenerating, time until they are allowed should decrease
        if (regenerationTimer > 0)
        {
            regenerationTimer -= Time.deltaTime;

        }
        else if(regenerationTimer<=0 && shieldAvailable==false) // if the end of the cooldown period, you can have a shield again, 
        {
            shieldHP = 100.0f;
            //hitsLeft = 1;
            shieldAvailable = true;
            shieldHealthBar.value = shieldHP;
        }

        if (Input.GetKeyDown(KeyCode.Q) == true) //should generally toggle the shield
        {
            //should not turn shield on if it is dead :(
            if (!shieldAvailable || regenerationTimer>0)
            {
                Debug.Log("Your shield is dead sorry");
            }
            else
            {
                //shieldHP = 100.0f;
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
        shieldActive = !shieldActive;
    }

    void hitShield() {
        Debug.Log("Shields have been hit!");
        shieldHP -= 50; //the amount of damage the shield takes when hit
        
        //hitsLeft--;
        //Invoke("switchShieldState", 1);
        //switchShieldState();

        //regenerationTimer = cooldownTime; // sets the timer so that you can't use the shield for a bit
    }
}
