using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

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
			other.GetComponent<Movement>().enabled = false;
			other.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
			other.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 1500f));
		}
	}
}
