using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody> ().velocity.x, 
		                                                   GetComponent<Rigidbody> ().velocity.y, 
		                                                   speed * Time.deltaTime);	
	}
}
