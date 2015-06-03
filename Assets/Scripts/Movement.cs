using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
	public float forwardSpeed;
	public float turnSpeed;
	public float jumpForce;
	float forwardSpeedBackUp;
    bool hasJumped = false;

	// Use this for initialization
	void Start ()
	{
		forwardSpeedBackUp = forwardSpeed;
		Debug.Log (Application.platform.ToString());
	}

	void Update ()
	{
		// If the player is grounded and they press the jump button, jump
		if (CrossPlatformInputManager.GetButtonDown("Jump"))
		{
			if (isGrounded() && !hasJumped)
			{
				GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, GetComponent<Rigidbody>().velocity.z);
				GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpForce, 0f));
			}
			hasJumped = true;
		}
		else
		{
			hasJumped = false;
		}
	}
		
	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = 0f;
		// Recieves left and right input from the player for PC
        h = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        // Recieves left and right input for mobile
        if (CrossPlatformInputManager.GetButton("Right"))
        {
            h += 1f;
        }
        if (CrossPlatformInputManager.GetButton("Left"))
        {
            h += -1f;
        }

        // Makes sure the player doesn't get stuck when moving forward
		//restrictMovement ();

		// Perpetually moves forward and makes the player move left and right
		GetComponent<Rigidbody> ().velocity = new Vector3 (h * turnSpeed, GetComponent<Rigidbody> ().velocity.y, forwardSpeed);
	}

	// Returns true if the player is on the ground. Duh
	bool isGrounded ()
	{
        BoxCollider bc = GetComponent<BoxCollider>();
		if (Physics.Raycast(transform.position, Vector3.down, bc.size.y / 2f + 0.3f) ||
            Physics.Raycast(new Vector3(transform.position.x + bc.size.x / 2f, transform.position.y, transform.position.z), Vector3.down, bc.size.y / 2f + 0.1f) ||
            Physics.Raycast(new Vector3(transform.position.x - bc.size.x / 2f, transform.position.y, transform.position.z), Vector3.down, bc.size.y / 2f + 0.1f))
		{
			return true;
		}
		return false;
	}

	void restrictMovement ()
	{
		forwardSpeed = forwardSpeedBackUp;
        BoxCollider bc = GetComponent<BoxCollider>();

		// Top Left
		if (Physics.Raycast(new Vector3(transform.position.x - bc.size.x / 2f, transform.position.y + bc.size.y / 2f, transform.position.z), Vector3.forward, bc.size.z / 2 + 0.1f))
		{
			forwardSpeed = 0f;
		}
		// Top
		if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + bc.size.y / 2f, transform.position.z), Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
		{
			forwardSpeed = 0f;
		}
		// Top Right
        if (Physics.Raycast(new Vector3(transform.position.x + bc.size.x / 2f, transform.position.y + bc.size.y / 2f, transform.position.z), Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
		{
			forwardSpeed = 0f;
		}
		// Left
        if (Physics.Raycast(new Vector3(transform.position.x - bc.size.x / 2f, transform.position.y, transform.position.z), Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
		{
			forwardSpeed = 0f;
		}
        // Middle
        if (Physics.Raycast(transform.position, Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
        {
            forwardSpeed = 0f;
        }
        // Right
        if (Physics.Raycast(new Vector3(transform.position.x + bc.size.x / 2f, transform.position.y, transform.position.z), Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
        {
            forwardSpeed = 0f;
        }
        // Bottom Left
        if (Physics.Raycast(new Vector3(transform.position.x - bc.size.x / 2f, transform.position.y - bc.size.y / 2f, transform.position.z), Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
        {
            forwardSpeed = 0f;
        }
        // Bottom
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - bc.size.y / 2f, transform.position.z), Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
        {
            forwardSpeed = 0f;
        }
        // Bottom Right
        if (Physics.Raycast(new Vector3(transform.position.x + bc.size.x / 2f, transform.position.y - bc.size.y / 2f, transform.position.z), Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
        {
            forwardSpeed = 0f;
        }
	}
}
