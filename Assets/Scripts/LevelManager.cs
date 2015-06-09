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

	}

    public void toMenu ()
    {
        Application.LoadLevel(0);
    }

    public void toNextLevel ()
    {
        Application.LoadLevel(int.Parse(Application.loadedLevel.ToString()) + 1);
    }
}
