using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Player1 player1;
	public Player2 player2;

	public Camera p1;
	public Camera p2;

	public Camera p1W;
	public Camera p2W;

	public Enemies redEnemy1;
	public Enemies redEnemy2;

	public Enemies blueEnemy1;
	public Enemies blueEnemy2;

	public Enemies yellowEnemy1;
	public Enemies yellowEnemy2;

	public Enemies greenEnemy1;
	public Enemies greenEnemy2;

//	public Enemies Boss1;
//	public Enemies Boss2;
//	public Enemies Boss3;
//	public Enemies Boss4;

	public int wave;

	public Transform[] spawnPoints1;
	public Transform[] spawnPoints2;

	public Text timer;
	public Slider healthBar;
	public Slider healthBar2;
	public Text status1;
	public Text status2;

	public Text score1;
	public Text score2;
	
	public Transform[] w1;
	public Transform[] w2;
	//public GameObjects[] enemyArray;
	public bool grace = false;

	private GameObject[] enemyWave1;
	private GameObject[] enemyWave2;
	private float matchTimer = 30.0f;
	public float prepTimer = 5.0f;

	private bool gameOver;
	private bool restart;

	private int n = 0;
	private int m = 0;

	private float t = 30.0f;
	private float pt = 10.0f;
	private bool newW;

	public GameObject c;
	public Image red;

	public GameObject t1;
	public GameObject t2;
	public GameObject mainT;
	public GameObject back;
	

	// Use this for initialization

	void Start () {

		gameOver = false;
		restart = false;

		healthBar.maxValue = player1.maxHealth;
		healthBar2.maxValue = player2.maxHealth;

		SpawnEnemy();

	}
	
	// Update is called once per frame
	void Update () {
		int temp;
		healthBar.value = player1.currentHealth;
		healthBar2.value = player2.currentHealth;

		string s1 = player1.currentHealth.ToString ("#");
		status1.text = "Player 1: " + s1;

		string s2 = player2.currentHealth.ToString ("#");
		status2.text = "Player 2: " + s2;

		string s11 = player1.totalScore.ToString ("#");
		score1.text = "Score: " + s11;
		
		string s22 = player2.totalScore.ToString ("#");
		score2.text = s22 + " :Score";

		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Debug.Log ("Reset");
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		if (matchTimer > 0.0f) {
			prepTimer = 10.0f;
			matchTimer -= Time.deltaTime;
			timer.text = matchTimer.ToString ("#.##");
		} else {
			if (prepTimer > 0.0f) {
				timer.color = Color.white;
				prepTimer -= Time.deltaTime;
				timer.text = prepTimer.ToString ("#.##");
				//wave = 1;
				temp = wave;
				wave = Random.Range (1, 8);
				if (temp == wave) {
					wave = (wave + temp) % 8;
				}
				CancelInvoke();
				Start();
			}
			else {
				timer.color = Color.red;
				matchTimer = 30.0f;
			}
		}
		if (matchTimer < 10.0f || matchTimer < 10.0f) {
			timer.text = "0" + timer.text;
		}
		if (matchTimer <= 0f ) {
			t1.SetActive(false);
			t2.SetActive(false);
			grace = true;
		}
		if (prepTimer <= 0f) {
			grace = false;
			player1.gotItem = false;
			player2.gotItem = false;
		}
		if (matchTimer <= 1f && matchTimer > 0f) {
			newW = true;
		} else {
			newW = false;
		}
		if (matchTimer <= 1.5f && matchTimer >= 0f) {
			player1.sheild.SetActive(false);
			player2.sheild.SetActive(false);
			player1.turnRight = player1.setRight;
			player2.turnRight = player2.setRight;
			player1.walkSpeed = 10f;
			player2.walkSpeed = 10f;
		}
		if (matchTimer <= 5.1) {
			t1.SetActive(true);
			t2.SetActive(true);
			t1.GetComponent<Text> ().text = matchTimer.ToString("#");
			t2.GetComponent<Text> ().text = matchTimer.ToString("#");
		}
		if (player1.dead == true && player2.dead == true) {
			t1.SetActive(false);
			t2.SetActive(false);
			mainT.SetActive(false);
			back.SetActive(false);
		}
	}

	void SpawnRed() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
		if (player1.dead == false) {
			redEnemy1.gm = this;
			redEnemy1.target = player1.transform;
			Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
//			red.rectTransform.anchoredPosition = transform.TransformVector(spawnPoints1[spawnPointIndex1].position.x - 54.5f, spawnPoints1[spawnPointIndex1].position.z, 0f); 
//			red.transform.SetParent (c.transform);
//			Instantiate (red, red.rectTransform.anchoredPosition, red.rectTransform.rotation);
		}
		if (player2.dead == false) {
			redEnemy2.gm = this;
			redEnemy2.target = player2.transform;
			Instantiate (redEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
		}

	}

	void SpawnBlue() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
		if (player1.dead == false) {
			blueEnemy1.gm = this;
			blueEnemy1.target = player1.transform;
			Instantiate (blueEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		}
		if (player2.dead == false) {
			blueEnemy2.gm = this;
			blueEnemy2.target = player2.transform;
			Instantiate (blueEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
		}
	}

	void SpawnYellow() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
		if (player1.dead == false) {
			yellowEnemy1.gm = this;
			yellowEnemy1.target = player1.transform;
			Instantiate (yellowEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		}
		if (player2.dead == false) {
			yellowEnemy2.gm = this;
			yellowEnemy2.target = player2.transform;
			Instantiate (yellowEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
		}
	}

	void SpawnGreen() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
		if (player1.dead == false) {
			greenEnemy1.gm = this;
			greenEnemy1.pt = w1;
			greenEnemy1.wanderIndex = Random.Range (0,6);
			greenEnemy1.target = player1.transform;
			Instantiate (greenEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		}
		if (player2.dead == false) {
			greenEnemy2.gm = this;
			greenEnemy2.pt = w2;
			greenEnemy2.wanderIndex = Random.Range (0,6);
			greenEnemy2.target = player2.transform;
			Instantiate (greenEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
		}
	}

	void SpawnEnemy()
	{
		switch (wave) {
		case 0:
			InvokeRepeating("SpawnRed", 1.5f, 1.5f);
			break;
		case 1:
			InvokeRepeating("SpawnBlue", 2f, 2f);
			break;
		case 2:
			InvokeRepeating("SpawnRed", 1.5f, 1.5f);
			InvokeRepeating("SpawnBlue", 2.5f, 2.5f);
			break;
		case 3:
			InvokeRepeating("SpawnYellow", 1.5f, 1.5f);
			break;
		case 4:
			InvokeRepeating("SpawnRed", 1.5f, 1.5f);
			InvokeRepeating("SpawnYellow", 2.5f, 2.5f);
			break;
		case 5:
			InvokeRepeating("SpawnRed", 2f, 2f);
			InvokeRepeating("SpawnGreen", 1.5f, 1.5f);
			break;
		case 6:
			InvokeRepeating("SpawnBlue", 2f, 2f);
			InvokeRepeating("SpawnGreen", 1.5f, 1.5f);
			break;
		case 7:
			InvokeRepeating("SpawnYellow", 2f, 2f);
			InvokeRepeating("SpawnGreen", 1.5f, 1.5f);
			break;
		case 8:
			InvokeRepeating("SpawnGreen", 1.5f, 1.5f);
			break;
		}
	}

}
