using UnityEngine;
using System.Collections;

public class startScript : MonoBehaviour {
	public GameObject loadingImage;
	//public string _scene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown (KeyCode.KeypadEnter)) {
			Application.LoadLevel(1);

		}
	}
}
