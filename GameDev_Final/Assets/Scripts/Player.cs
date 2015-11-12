﻿using UnityEngine;
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
//			transform.RotateAround(transform.position, transform.up, -5);

		}

		if (Input.GetKey (KeyCode.A))
		{
			transform.RotateAround(transform.position, transform.up, -5);
		}
		
		if (Input.GetKey (KeyCode.D))
		{
			transform.RotateAround(transform.position, transform.up, 5);
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
				walkSpeed = 10;
			}
			else
			{
				walkSpeed = 5;
			}
			
			rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
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
