using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float forwardSpeed;
	public float turnSpeed;
	public float jumpForce;
	float forwardSpeedBackUp;

	// Use this for initialization
	void Start ()
	{
		forwardSpeedBackUp = forwardSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If the player is grounded and they press the jump button, jump
		if (isGrounded() && Input.GetAxisRaw("Jump") == 1f)
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpForce, 0f));
		}

		// Recieves left and right input from the player
		float h = Input.GetAxisRaw ("Horizontal");

		restrictMovement ();

		// Perpetually moves forward and makes the player move left and right
		GetComponent<Rigidbody> ().velocity = new Vector3 (h * Time.deltaTime * turnSpeed, 
		                                                   GetComponent<Rigidbody> ().velocity.y, 
		                                                   forwardSpeed * Time.deltaTime);	
	}

	// Returns true if the player is on the ground. Duh
	bool isGrounded ()
	{
		if (Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.y / 2 + 0.1f))
		{
			return true;
		}
		return false;
	}

	void restrictMovement ()
	{
		forwardSpeed = forwardSpeedBackUp;

		// Center
		if (Physics.Raycast(transform.position, Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
		{
			forwardSpeed = 0f;
		}
		// Top (Not Finished)
		if (Physics.Raycast(transform.position, Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
		{
			forwardSpeed = 0f;
		}
		// Top Left (Not Finished)
		if (Physics.Raycast(transform.position, Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
		{
			forwardSpeed = 0f;
		}
		// Top Right (Not Finished)
		if (Physics.Raycast(transform.position, Vector3.forward, GetComponent<BoxCollider>().size.z / 2 + 0.1f))
		{
			forwardSpeed = 0f;
		}
	}
}
