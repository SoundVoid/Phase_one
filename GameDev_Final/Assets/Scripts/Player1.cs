using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	
	Rigidbody rb;

	public Bullet bullet;
	public int maxHealth;
	public int currentHealth;
	public float walkSpeed;

	bool grounded = false;
	
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody>();
		
	}

	// Update is called once per frame
	void Update () {
		//if the player's health is zero, deactivate the player
		if (currentHealth <= 0)
		{
			gameObject.SetActive(false);
		}

		if (gameObject.tag == "Player1") {
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S))
			{
				FixedUpdate();
			}
			if (Input.GetKey (KeyCode.A))
			{
				transform.RotateAround(transform.position, transform.up, -3);
				//transform.position -= transform.right * 8 * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.D))
			{
				transform.RotateAround(transform.position, transform.up, 3);
				//transform.position += transform.right * 8 * Time.deltaTime;
			}
		}

		if(Input.GetKeyDown(KeyCode.C)){
			Shoot();
		}	
	}
	void OnCollisionEnter(Collision col)
	{
		//decrease the health if the collider's tag tells us it's an 'enemy'. We set the tag in the inspector underneath the object name.
		if (col.collider.tag == "Enemy")
		{
			currentHealth -= 1;
		}
		
	}
	void OnCollisionStay(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			grounded = true;
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			grounded = false;
		}
	}
	
	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
			//transform.position += transform.forward * walkSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(-transform.forward * walkSpeed, ForceMode.Acceleration);
			//transform.position -= transform.forward * walkSpeed * Time.deltaTime;
		}
	}
	void Shoot(){
		//Instantiate a bullet and set it to a newBullet
		//Bullet newBullet =  (Bullet)Instantiate (bullet, transform.position + -transform.forward, Quaternion.identity);
		//newBullet.direction = -transform.forward;
		
	}

}
