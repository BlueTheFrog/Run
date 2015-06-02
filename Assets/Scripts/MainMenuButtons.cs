using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
	string buttonName;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeLevel ()
	{
		buttonName = GetComponentInChildren<Text> ().text;
		Application.LoadLevel ((int.Parse(buttonName[6].ToString())));
	}
}
