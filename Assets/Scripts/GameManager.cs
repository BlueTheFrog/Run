using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour 
{
	public GameObject[] levelButtons;

	// Use this for initialization
	void Awake ()
	{

		if (!PlayerPrefs.HasKey("unlockedLevels"))
		{
			PlayerPrefs.SetInt("unlockedLevels", 1);
		}

		//PlayerPrefs.SetInt("unlockedLevels", 1);

		if (Application.platform != RuntimePlatform.Android)
		{
		    CrossPlatformInputManager.SwitchActiveInputMethod (CrossPlatformInputManager.ActiveInputMethod.Hardware);
		}
		else
		{
			CrossPlatformInputManager.SwitchActiveInputMethod (CrossPlatformInputManager.ActiveInputMethod.Touch);
		}
	}

	void Start ()
	{
		checkUnlockedLevels ();
	}
	
	// Update is called once per frame
	void Update ()
	{
			
	}

	void checkUnlockedLevels ()
	{
		int unlockedLevels = PlayerPrefs.GetInt ("unlockedLevels");
		for (int i = 0; i < unlockedLevels; i++)
		{
			levelButtons[i].SetActive(true);
		}
	}
}
