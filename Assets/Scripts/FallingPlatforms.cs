using UnityEngine;
using System.Collections;

public class FallingPlatforms : MonoBehaviour
{
	public GameObject[] platforms;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "Player")
		{
			int rand = Random.Range(0, platforms.Length);
			platforms[rand].GetComponent<Rigidbody>().useGravity = true;
			platforms[rand].GetComponent<Rigidbody>().isKinematic = false;
		}
	}
}
