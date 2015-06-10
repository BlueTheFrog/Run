using UnityEngine;
using System.Collections;

public class FloatingPlatform : MonoBehaviour
{
	public float speed = 1f;
	public float height = 1f;
	float x = 0f;
	public Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
		if (startPos == Vector3.zero)
		{
		    startPos = transform.position;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(transform.position.x, height * Mathf.Sin(speed * x) + startPos.y, transform.position.z);
		x += Time.deltaTime;
	}
}
