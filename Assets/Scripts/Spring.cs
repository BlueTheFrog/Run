using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour
{
	public float bounceForce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Player")
		{
			other.transform.position = new Vector3 (other.transform.position.x, transform.position.y + transform.lossyScale.y * 0.5f, transform.position.z);
			other.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, other.GetComponent<Rigidbody>().velocity.z);
			other.GetComponent<Rigidbody>().AddForce(0f, bounceForce, 0f);
		}
	}
}
