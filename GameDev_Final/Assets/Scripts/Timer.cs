using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	private float t = 60.0f;
	public GameObject l;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (t > 0.0f) {
			t -= Time.deltaTime;
			l.transform.RotateAround(transform.position, transform.right, -0.02f);
		}
		string s = t.ToString ();
		GetComponent<TextMesh> ().text = s;
	}
}
