using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	Rigidbody rb;
	public Transform target;
	public Transform[] pt;
	public int wanderIndex;
	public string color;
	public GameManager gm;
	
	private float t = 60.0f;
	private float walkSpeed = 3.0f;
	private float runSpeed = 2.0f;
	public int HP;
	public GameObject p;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		Chasing (target);
		if (gm.grace == true) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		}

		switch (color) {
		case "red":
			Chasing (target);
			break;
		case "blue":
			Tank();
			Chasing (target);
			break;
		case "yellow":
			Chasing (target);
//			Attack();
			break;
		case "green":
			Wandering ();
			break;
		}
	}

	void Chasing (Transform t)
	{	
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(t.position - transform.position), .2f);
		transform.position += transform.forward * runSpeed * Time.deltaTime;
	}
	
	void Wandering ()
	{
		if (HP == 7) {
			if (transform.position.x >= pt [wanderIndex].position.x && transform.position.z >= pt [wanderIndex].position.z) {
				wanderIndex = Random.Range (0, pt.Length);
				Debug.Log (wanderIndex);
			}
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (pt [wanderIndex].position - transform.position), .2f);
			transform.position += transform.forward * walkSpeed * Time.deltaTime;
		} else {
			Chasing(target);
		}

	}

	void Tank (){
		if (HP < 10 && HP >= 8) {
			transform.localScale = new Vector3(2f, 2f, 2f);
		}
		if (HP < 8 && HP >= 6) {
			transform.localScale = new Vector3(3f, 3f, 3f);
		}
		if (HP < 6 && HP >= 4) {
			transform.localScale = new Vector3(4f, 4f, 4f);
			//rb.mass = 3;
		}
		if (HP < 4 && HP >= 2) {
			transform.localScale = new Vector3(5f, 5f, 5f);
		}
		if (HP < 2 && HP >= 1) {
			transform.localScale = new Vector3(6f, 6f, 6f);
			//rb.mass = 4;
		}
	}

	void OnTriggerEnter (Collider col) {
		if (color == "yellow") {
			if (target.tag == "Player1") {
				if (col.GetComponent<Collider>().tag == "Vision Cone1") {
					Attack(target);
				}
			}
			if (target.tag == "Player2") {
				if (col.GetComponent<Collider>().tag == "Vision Cone2") {
					Attack(target);
				}
			}
		}
	}

	void OnTriggerStay (Collider col) {
		if (color == "yellow") {
			if (target.tag == "Player1") {
				if (col.GetComponent<Collider>().tag == "Vision Cone1") {
					Attack(target);
				}
			}
			if (target.tag == "Player2") {
				if (col.GetComponent<Collider>().tag == "Vision Cone2") {
					Attack(target);
				}
			}
		}
	}

	void Attack (Transform t){
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(t.position - transform.position), .2f);
		transform.position += transform.forward * 3.0f * Time.deltaTime;
	}

//	public void Killed (){
//		//set enemy to false
//		if (HP == 0){
//			gameObject.SetActive(false);
//			Destroy(gameObject);
//		}
//	}
	public void Killed (){
		//set enemy to false
		if (HP == 0){
			//p.SetActive(true);
			if (target.tag == "Player1")
			{
				if (color == "red")
				{
					target.GetComponent<Player1> ().totalScore += 1;
				}
				if (color == "blue")
				{
					target.GetComponent<Player1> ().totalScore += 2;
				}
				if (color == "yellow")
				{
					target.GetComponent<Player1> ().totalScore += 3;
				}
				if (color == "green")
				{
					target.GetComponent<Player1> ().totalScore += 4;
				}
			}
			
			if (target.tag == "Player2")
			{
				if (color == "red")
				{
					target.GetComponent<Player2> ().totalScore += 1;
				}
				if (color == "blue")
				{
					target.GetComponent<Player2> ().totalScore += 2;
				}
				if (color == "yellow")
				{
					target.GetComponent<Player2> ().totalScore += 3;
				}
				if (color == "green")
				{
					target.GetComponent<Player2> ().totalScore += 4;
				}
			}
			gameObject.SetActive(false);
			Destroy(gameObject);
			//p.SetActive(false);
		}
	}
}