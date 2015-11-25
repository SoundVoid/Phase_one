using UnityEngine;
using System.Collections;

public class Hide : MonoBehaviour {
	// Use this for initialization
	public GameObject wall;
	private Light l;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		Debug.Log ("Hit");
		if (col.GetComponent<Collider>().tag == "Wall") {
			col.gameObject.GetComponent<Renderer> ().enabled = false;
			//wall.GetComponent<Renderer> ().enabled = false;
		}
	}
	void OnTriggerExit(Collider col){
		Debug.Log ("Exit");
		if (col.GetComponent<Collider> ().tag == "Wall") {
			col.gameObject.GetComponent<Renderer> ().enabled = true;
		}
	}
}
