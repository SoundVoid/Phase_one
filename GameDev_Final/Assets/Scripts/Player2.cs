using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2 : MonoBehaviour {
	Rigidbody rb;

	public float setDrag = .9f;
	public float setRight = 1.5f;
	public int setGunDamage = 1;
	public int setAxeDamage = 3;

	public GameObject opponet;
	public GameObject sheild;

	public Bullet bullet;
	public float maxHealth;
	public float currentHealth;
	public float walkSpeed;
	public float turnRight = 2.5f;
	public float gunDamage;
	public float axeDamage;
	public int totalScore = 0;

	public bool dead = false;
	public bool gotItem = false;
	public bool sh = false;
	private float shHP = 25f;

	private int score;
	public AudioSource sfx;
	public AudioClip sfx_shoot;

	public Image p;

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
		if (sh == true) {
			sheild.SetActive(true);
		}
		if (gameObject.tag == "Player2") {
			if (Input.GetKey (KeyCode.I) || Input.GetKey (KeyCode.K))
			{
				FixedUpdate();
			}
			if (Input.GetKey (KeyCode.J))
			{
				p.GetComponent<RectTransform> ().transform.RotateAround(p.rectTransform.position, p.rectTransform.forward, turnRight);
				transform.RotateAround(transform.position, transform.up, -turnRight);
				//transform.position -= transform.right * 8 * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.L))
			{
				p.GetComponent<RectTransform> ().transform.RotateAround(p.rectTransform.position, p.rectTransform.forward, -turnRight);
				transform.RotateAround(transform.position, transform.up, turnRight);
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
			if (sh == false) {
				currentHealth -= 0.5f;
			}
			if (sh == true) {
				shHP -= 0.5f;
			}
			if (shHP <= 0f) {
				sheild.SetActive(false);
				sh = false;
				shHP = 25f;
			}
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
			if (sh == false) {
				currentHealth -= 0.5f;
			}
			if (sh == true) {
				shHP -= 0.5f;
			}
			if (shHP <= 0f) {
				sheild.SetActive(false);
			}
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
