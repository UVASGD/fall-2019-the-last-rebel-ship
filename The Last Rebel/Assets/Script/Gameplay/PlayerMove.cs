using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


	public float maxSpeed = 10.0f;
	public float force = 1.0f;
	public float mass = 10.0f;
	public byte direction = 8;

	public Vector2 velovity;

    KeyCode[] up = { KeyCode.UpArrow, KeyCode.W };
    KeyCode[] left = { KeyCode.LeftArrow, KeyCode.A };
    KeyCode[] down = { KeyCode.DownArrow, KeyCode.S };
    KeyCode[] right = { KeyCode.RightArrow, KeyCode.D };

    KeyCode[] thruster = { KeyCode.LeftShift, KeyCode.I };
    KeyCode[] brake = { KeyCode.LeftControl, KeyCode.K };


    public Rigidbody2D rb;


	private bool directionKeyPressedOnPrevious = false;
	private int previousDirection;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		bool directionKeyPressed = true;
		previousDirection = direction;

		if (CheckKeyset(up) && CheckKeyset(right)) {
			direction = 7;
		}
		else if (CheckKeyset(up) && CheckKeyset(left)) {
			direction = 1;
		}
		else if (CheckKeyset(down) && CheckKeyset(right)) {
			direction = 5;
		}
		else if (CheckKeyset(down) && CheckKeyset(left)) {
			direction = 3;
		}
		else if (CheckKeyset(up)) {
			direction = 0;
		} else if (CheckKeyset(down)) {
			direction = 4;
		} else if (CheckKeyset(left))
        {
			direction = 2;
		} else if (CheckKeyset(right))
        {
			direction = 6;
		} else {
			directionKeyPressed = false;
		}

        bool brakeKeyIsPressed = false;
        if(CheckKeyset(brake))
        {
            brakeKeyIsPressed = true;
        }

		if (directionKeyPressed) {
			float originalRotation = rb.rotation;


			rb.MoveRotation (45.0f * direction);
			if (previousDirection != direction) {
				rb.velocity = RedirectInertia (rb.velocity, originalRotation, 45.0f * direction);
			}
            /*
			if (rb.velocity.magnitude < maxSpeed) {
                if (brakeKeyIsPressed)
                {
                    ActivateThrusters(-1);
                }
                else
                {
                    ActivateThrusters(1);
                }
			}
            */
			directionKeyPressedOnPrevious = true;

            rb.angularVelocity = 0;

		} else {
			directionKeyPressedOnPrevious = false;
		}

        if(CheckKeyset(thruster))
        {
            if (rb.velocity.magnitude < maxSpeed)
                ActivateThrusters(force);
        }
        if(CheckKeyset(brake))
        {
            ActivateThrusters(-force);
        }

    }

	private void ActivateThrusters(float power)
	{
		float accelerationX = -Mathf.Sin (Mathf.Deg2Rad*rb.rotation);
		float accelerationY = Mathf.Cos (Mathf.Deg2Rad* rb.rotation);
		rb.AddForce ((new Vector2(accelerationX, accelerationY)) * power);
	}

	private Vector2 RedirectInertia(Vector2 originalVelocity, float originalRotation, float newRotation)
	{
		
		float oldXUnit = -Mathf.Sin (Mathf.Deg2Rad * originalRotation); 
		float oldYUnit = Mathf.Cos (Mathf.Deg2Rad * originalRotation);
		Vector2 oldDirectionUnit = new Vector2 (oldXUnit, oldYUnit);

		float oldDirectionSpeed = Vector2.Dot (originalVelocity, oldDirectionUnit);

		Vector2 oldDirectionVector = oldDirectionUnit * oldDirectionSpeed;

		float newXUnit = -Mathf.Sin (Mathf.Deg2Rad * newRotation); 
		float newYUnit = Mathf.Cos (Mathf.Deg2Rad * newRotation);
		Vector2 newDirectionUnit = new Vector2 (newXUnit, newYUnit);
		Vector2 newDirectionVector = newDirectionUnit * oldDirectionSpeed;

		Vector2 newVelocity = originalVelocity - oldDirectionVector + newDirectionVector;

		return newVelocity;
	}

    private bool CheckKeyset(KeyCode[] keys)
    {
        bool keyis = false;
        foreach(KeyCode key in keys)
        {
            if(Input.GetKey(key))
            {
                keyis = true;
            }
        }
        return keyis;
    }

}
