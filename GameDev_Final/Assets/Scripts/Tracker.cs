using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tracker : MonoBehaviour {

	public Image p;
	public bool wall = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W))
		{
			if (wall == false) {
				p.GetComponent<RectTransform> ().transform.position += p.rectTransform.up * Time.deltaTime * 18f;
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			if (wall == false) {
				p.GetComponent<RectTransform> ().transform.position -= p.rectTransform.up * Time.deltaTime * 18f;
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Wall")
		{
			wall = true;
		}
		
	}

	void OnCollisionStay(Collision col)
	{
		if (col.collider.tag == "Wall")
		{
			wall = true;
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "Wall")
		{
			wall = false;
		}
	}
}
