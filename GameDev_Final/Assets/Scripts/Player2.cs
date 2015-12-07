﻿using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {
	Rigidbody rb;

	public Bullet bullet;
	public float maxHealth;
	public float currentHealth;
	public float walkSpeed;
	private int score = 0;
	public int totalScore = 0;

	public AudioSource sfxShot;
    public AudioClip sfxShoting;
    public AudioSource sfxHurt;
    public AudioClip sfxHurting;
    public AudioSource sfxWalk;
    public AudioClip sfxWalking;
    public bool startWalking = false;


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
		if (gameObject.tag == "Player2") {
			if (Input.GetKey (KeyCode.I) || Input.GetKey (KeyCode.K))
			{
				FixedUpdate();

				if (!startWalking)
				{
					sfxWalk.Play();

					startWalking = true;
				}
			}
			if (Input.GetKey (KeyCode.J))
			{
				transform.RotateAround(transform.position, transform.up, -3);
				//transform.position -= transform.right * 8 * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.L))
			{
				transform.RotateAround(transform.position, transform.up, 3);
				//transform.position += transform.right * 8 * Time.deltaTime;
			}

			if (startWalking)
			{
				if (Input.GetKeyUp (KeyCode.W)|| Input.GetKeyUp (KeyCode.S))
				{
					sfxWalk.Stop();

					startWalking = false;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Semicolon)) {
			Shoot();
		}
	}
	void OnCollisionEnter(Collision col)
	{
		//decrease the health if the collider's tag tells us it's an 'enemy'. We set the tag in the inspector underneath the object name.
		if (col.collider.tag == "Enemy")
		{
			currentHealth -= 0.5f;
		}
		
	}
	void OnCollisionStay(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			grounded = true;
		}
		if (col.collider.tag == "Enemy")
		{
			currentHealth -= 0.5f;

			sfxHurt.PlayOneShot(sfxHurting);
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
		if (Input.GetKey(KeyCode.I))
		{
			rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
			//transform.position += transform.forward * walkSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.K))
		{
			rb.AddForce(-transform.forward * walkSpeed, ForceMode.Acceleration);
			//transform.position -= transform.forward * walkSpeed * Time.deltaTime;
		}
	}
	void Shoot(){
		//Instantiate a bullet and set it to a newBullet
		Bullet newBullet =  (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet.direction = transform.forward;

		sfxShot.PlayOneShot(sfxShoting);
		
	}

}
