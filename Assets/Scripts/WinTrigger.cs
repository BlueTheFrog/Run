using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public GameObject panel;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Player")
		{
            panel.GetComponent<Animator>().SetBool("Activate", true);
			other.GetComponent<Movement>().enabled = false;
			other.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
			other.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 1500f));
			Debug.Log(PlayerPrefs.GetInt("unlockedLevels").ToString() + " " + Application.loadedLevelName[6].ToString());
			if (PlayerPrefs.GetInt("unlockedLevels") == int.Parse(Application.loadedLevelName[6].ToString()))
			{
				PlayerPrefs.SetInt("unlockedLevels", PlayerPrefs.GetInt("unlockedLevels") + 1);
			}
		}
	}
}
