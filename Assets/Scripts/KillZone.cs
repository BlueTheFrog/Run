using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour
{
	public GameObject player;
	Vector3 spawnPos;

	// Use this for initialization
	void Start ()
	{
		spawnPos = player.transform.position;	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Player")
		{
			other.transform.position = spawnPos;
		}
	}
}
