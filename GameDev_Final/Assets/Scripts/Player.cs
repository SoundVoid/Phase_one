using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	Rigidbody rb;
//	public Bullet bullet;
	public int maxHealth;
	public int currentHealth;
//	public float jumpStrength;
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
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
//			Shoot();
		}
		if (Input.GetKey (KeyCode.W))
		{
			FixedUpdate();
		}
		if (Input.GetKey (KeyCode.A))
		{
			transform.RotateAround(transform.position, transform.up, -2);
		}
		if (Input.GetKey (KeyCode.S))
		{
			FixedUpdate();
		}
		if (Input.GetKey (KeyCode.D))
		{
			transform.RotateAround(transform.position, transform.up, 2);
		}
		int i = 0;
		while (i < 4) {
			if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2F || Mathf.Abs(Input.GetAxis("Vertical")) > 0.2F)
				Debug.Log(Input.GetJoystickNames()[i] + " is moved");
			
			i++;
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
			float walkSpeed;
			
			if (grounded)
			{
				walkSpeed = 8;
			}
			else
			{
				walkSpeed = 4;
			}
			
			rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
		}
		if (Input.GetKey(KeyCode.S))
		{
			float walkSpeed;
			
			if (grounded)
			{
				walkSpeed = 8;
			}
			else
			{
				walkSpeed = 4;
			}
			
			rb.AddForce(-transform.forward * walkSpeed, ForceMode.Acceleration);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{
//				rb.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
//				Debug.Log ("jumped");
			}
		}
	}
	
	
}
