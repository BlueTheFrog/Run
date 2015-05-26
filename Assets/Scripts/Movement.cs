using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float forwardSpeed;
	public float turnSpeed;
	public float jumpForce;
	float forwardSpeedBackUp;
    Vector3 startPos;
    bool hasJumped = false;

	// Use this for initialization
	void Start ()
	{
		forwardSpeedBackUp = forwardSpeed;
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
        // Puts the player back at the start if they fall off
        if (transform.position.y < -40f)
        {
            transform.position = startPos;
        }
		// If the player is grounded and they press the jump button, jump
		if (Input.GetAxisRaw("Jump") == 1f)
		{
            if (isGrounded() && !hasJumped)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpForce, 0f));
            }
            hasJumped = true;
		}
        else
        {
            hasJumped = false;
        }

		// Recieves left and right input from the player
		float h = Input.GetAxisRaw ("Horizontal");

        // Makes sure the player doesn't get stuck when moving forward
		//restrictMovement ();

		// Perpetually moves forward and makes the player move left and right
		GetComponent<Rigidbody> ().velocity = new Vector3 (h * Time.deltaTime * turnSpeed, 
		                                                   GetComponent<Rigidbody> ().velocity.y, 
		                                                   forwardSpeed * Time.deltaTime);	
	}

	// Returns true if the player is on the ground. Duh
	bool isGrounded ()
	{
        BoxCollider bc = GetComponent<BoxCollider>();
		if (Physics.Raycast(transform.position, Vector3.down, bc.size.y / 2f + 0.1f) ||
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
