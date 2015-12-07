using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {
	Rigidbody rb;

	public const float setDrag = .9f;
	public const float setRight = 1.5f;
	public const int setGunDamage = 1;
	public const int setAxeDamage = 3;

	public GameObject opponet;

	public Bullet bullet;
	public float maxHealth;
	public float currentHealth;
	public float walkSpeed;
	public float turnRight;
	public float gunDamage;
	public float axeDamage;
	public int totalScore = 0;

	public bool dead = false;
	public bool gotItem = false;

	private int score;
	public AudioSource sfx;
	public AudioClip sfx_shoot;

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
			dead = true;
			gameObject.SetActive(false);
		}
		if (gameObject.tag == "Player2") {
			if (Input.GetKey (KeyCode.I) || Input.GetKey (KeyCode.K))
			{
				FixedUpdate();
			}
			if (Input.GetKey (KeyCode.J))
			{
				transform.RotateAround(transform.position, transform.up, -2.5f);
				//transform.position -= transform.right * 8 * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.L))
			{
				transform.RotateAround(transform.position, transform.up, 2.5f);
				//transform.position += transform.right * 8 * Time.deltaTime;
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
		sfx.PlayOneShot(sfx_shoot);
		//Instantiate a bullet and set it to a newBullet
		Bullet newBullet =  (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet.direction = transform.forward;
		
	}

}
