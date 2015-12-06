using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public WaveManager WM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col) {
		if (col.GetComponent<Collider>().tag == "Player1" || col.GetComponent<Collider>().tag == "Player2" ) {
			if (gameObject.tag == "Health") {
				if (col.GetComponent<Collider>().GetComponent<Player1> ().currentHealth < 15f) {
					col.GetComponent<Collider>().GetComponent<Player1> ().currentHealth += 30;
				} else {
					col.GetComponent<Collider>().GetComponent<Player1> ().currentHealth += Random.Range (10, 25);
				}
				if (col.GetComponent<Collider>().tag == "Player1") {
					col.GetComponent<Player1>().gotItem = true;
					WM.items1[2].SetActive(false);
				}
				if (col.GetComponent<Collider>().tag == "Player2") {
					col.GetComponent<Player2>().gotItem = true;
					WM.items2[2].SetActive(false);
				}
			}
			if (gameObject.tag == "Buff") {
				Debug.Log ("Active");
				//Temporally Help Current Player
				if (col.GetComponent<Collider>().tag == "Player1") {
					col.GetComponent<Player1>().gotItem = true;
					WM.items1[2].SetActive(false);
				}
				if (col.GetComponent<Collider>().tag == "Player2") {
					col.GetComponent<Player2>().gotItem = true;
					WM.items2[2].SetActive(false);
				}
			}
			if (gameObject.tag == "Debuff") {
				Debug.Log ("Active");
				//Temporally Hinder Opponet
				if (col.GetComponent<Collider>().tag == "Player1") {
					col.GetComponent<Player1>().gotItem = true;
					WM.items1[0].SetActive(false);
					WM.items1[1].SetActive(false);
				}
				if (col.GetComponent<Collider>().tag == "Player2") {
					col.GetComponent<Player2>().gotItem = true;
					WM.items2[0].SetActive(false);
					WM.items2[1].SetActive(false);
				}
			}
			gameObject.SetActive (false);
		}
	}
}
