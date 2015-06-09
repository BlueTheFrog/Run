using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CrossPlatformInputManager.GetButtonDown("ToMenu"))
        {
            Application.LoadLevel(0);
        }
	    if (CrossPlatformInputManager.GetButtonDown("ToNextLevel"))
        {
            Application.LoadLevel(int.Parse(Application.loadedLevel.ToString()) + 1);
        }
	}
}
