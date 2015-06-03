using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour 
{

	// Use this for initialization
	void Awake ()
	{
		if (Application.platform != RuntimePlatform.Android)
		{
		    CrossPlatformInputManager.SwitchActiveInputMethod (CrossPlatformInputManager.ActiveInputMethod.Hardware);
		}
		else
		{
			CrossPlatformInputManager.SwitchActiveInputMethod (CrossPlatformInputManager.ActiveInputMethod.Touch);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
			
	}
}
