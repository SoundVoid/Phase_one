using UnityEngine;
using System.Collections;

public class startScript3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter)) {
			Application.LoadLevel(3);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel (2);
		}
	}
}
