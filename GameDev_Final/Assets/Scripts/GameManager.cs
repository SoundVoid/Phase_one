using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Player1 player1;
	public Player2 player2;
	
	public Enemies redEnemy1;
	public Enemies redEnemy2;
<<<<<<< HEAD
	
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
	
	public int wave = 0;
=======

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
>>>>>>> bbe6fe17af84e5e9e36e72548c36eb0b04a4f88a
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float spawnTime;
<<<<<<< HEAD
	
=======

>>>>>>> bbe6fe17af84e5e9e36e72548c36eb0b04a4f88a
	public Transform[] spawnPoints1;
	public Transform[] spawnPoints2;
	
	public Slider healthBar;
	public Slider healthBar2;
	
	public Transform[] w1;
	public Transform[] w2;
	//public GameObjects[] enemyArray;
<<<<<<< HEAD
	
	private GameObject[] enemyWave1;
	private GameObject[] enemyWave2;
	private float matchTimer = 60.0f;
	private float prepTimer = 5.0f;
	
	private bool gameOver;
	private bool restart;
	
	private int n = 0;
	private int m = 0;
	
	
=======
	public bool grace = false;

	private GameObject[] enemyWave1;
	private GameObject[] enemyWave2;
	private float matchTimer = 30.0f;
	public float prepTimer = 5.0f;

	private bool gameOver;
	private bool restart;

	private int n = 0;
	private int m = 0;


>>>>>>> bbe6fe17af84e5e9e36e72548c36eb0b04a4f88a
	// Use this for initialization
	
	void Start () {
<<<<<<< HEAD
		
		gameOver = false;
		restart = false;
		
		// call the SpawnEnemy function once every second afer 1 second.
		healthBar.maxValue = player1.maxHealth;
		healthBar2.maxValue = player2.maxHealth;
		
		//InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
		//StartCoroutine (SpawnWaves ());
		SpawnEnemy();
		
=======

		gameOver = false;
		restart = false;

		// call the SpawnEnemy function once every second afer 1 second.
		healthBar.maxValue = player1.maxHealth;
		healthBar2.maxValue = player2.maxHealth;

		//InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
		//StartCoroutine (SpawnWaves ());
		SpawnEnemy();

>>>>>>> bbe6fe17af84e5e9e36e72548c36eb0b04a4f88a
	}
	
	// Update is called once per frame
	void Update () {
		int temp;
		healthBar.value = player1.currentHealth;
		healthBar2.value = player2.currentHealth;
<<<<<<< HEAD
		
=======

>>>>>>> bbe6fe17af84e5e9e36e72548c36eb0b04a4f88a
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Debug.Log ("Reset");
				Application.LoadLevel (Application.loadedLevel);
			}
		}
<<<<<<< HEAD
		
		int num = 0;
		//		if (matchTimer > 0.0f) {
		//			matchTimer -= Time.deltaTime;
		//			if (matchTimer <= 10.0f && matchTimer > 9.9f) {
		////				wave = 3;
		////				CancelInvoke ();
		////				Start ();
		//			}
		//		} 
=======

>>>>>>> bbe6fe17af84e5e9e36e72548c36eb0b04a4f88a
		if (matchTimer > 0.0f) {
			prepTimer = 10.0f;
			matchTimer -= Time.deltaTime;
		} else {
			if (prepTimer > 0.0f) {
				prepTimer -= Time.deltaTime;
<<<<<<< HEAD
				wave = 1;
=======
				//wave = 1;
				temp = wave;
				wave = Random.Range (1, 8);
				if (temp == wave) {
					wave = (wave + temp) % 8;
				}
>>>>>>> bbe6fe17af84e5e9e36e72548c36eb0b04a4f88a
				CancelInvoke();
				Start();
			}
			else {
				matchTimer = 20.0f;
			}
		}
<<<<<<< HEAD
		
		//		if (prepTimer > 0.0f) {
		//			wave = 3;
		//			CancelInvoke ();
		//			prepTimer -= Time.deltaTime;
		//		}
	}
	
	void SpawnRed() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
		
		redEnemy1.target = player1.transform;
		Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		
=======

		if (matchTimer <= 0f ) {
			grace = true;
		}
		if (prepTimer <= 0f) {
			grace = false;
			player1.gotItem = false;
			player2.gotItem = false;
		}

	}

	void SpawnRed() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);

		redEnemy1.gm = this;
		redEnemy1.target = player1.transform;
		Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		//enemyWave1[n] = (GameObject) Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);

		redEnemy2.gm = this;
>>>>>>> bbe6fe17af84e5e9e36e72548c36eb0b04a4f88a
		redEnemy2.target = player2.transform;
		Instantiate (redEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
		
	}
	
	void SpawnBlue() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
		
		blueEnemy1.target = player1.transform;
		Instantiate (blueEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		
		blueEnemy2.target = player2.transform;
		Instantiate (blueEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
	}
	
	void SpawnYellow() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
		
		yellowEnemy1.target = player1.transform;
		Instantiate (yellowEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		
		yellowEnemy2.target = player2.transform;
		Instantiate (yellowEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
	}
	
	void SpawnGreen() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
		
		greenEnemy1.pt = w1;
		greenEnemy1.wanderIndex = Random.Range (0,6);
		greenEnemy1.target = player1.transform;
		Instantiate (greenEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		
		greenEnemy2.pt = w2;
		greenEnemy2.wanderIndex = Random.Range (0,6);
		greenEnemy2.target = player2.transform;
		Instantiate (greenEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
	}
	
	void SpawnEnemy()
	{
		switch (wave) {
		case 0:
			InvokeRepeating("SpawnRed", 1.0f, 1.0f);
			wave = 1;
			break;
		case 1:
			InvokeRepeating("SpawnBlue", 2.5f, 2.5f);
			wave = 2;
			break;
		case 2:
			InvokeRepeating("SpawnRed", 1.0f, 1.0f);
			InvokeRepeating("SpawnBlue", 2.5f, 2.5f);
			wave = 3;
			break;
		case 3:
			InvokeRepeating("SpawnYellow", 1.0f, 1.0f);
			wave = 4;
			break;
		case 4:
			InvokeRepeating("SpawnRed", 1.0f, 1.0f);
			InvokeRepeating("SpawnYellow", 1.5f, 1.5f);
			wave = 5;
			break;
		case 5:
			InvokeRepeating("SpawnRed", 1.0f, 1.0f);
			InvokeRepeating("SpawnGreen", 1.1f, 1.1f);
			break;
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < 10; i++)
			{
				int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
				int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);
				
				//				redEnemy1.target = player1.transform;
				//				Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				//				
				//				redEnemy2.target = player2.transform;
				//				Instantiate (redEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
				//
				//				blueEnemy1.target = player1.transform;
				//				Instantiate (blueEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				//				
				//				blueEnemy2.target = player2.transform;
				//				Instantiate (blueEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
				
				yellowEnemy1.target = player1.transform;
				Instantiate (yellowEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				
				yellowEnemy2.target = player2.transform;
				Instantiate (yellowEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
				
				//				greenEnemy1.pt = w1;
				//				greenEnemy1.wanderIndex = Random.Range (0,6);
				//				greenEnemy1.target = player1.transform;
				//				Instantiate (greenEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				//				
				//				greenEnemy2.pt = w2;
				//				greenEnemy2.wanderIndex = Random.Range (0,6);
				//				greenEnemy2.target = player2.transform;
				//				Instantiate (greenEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
				
				
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restart = true;
				break;
			}
		}
	}
	
	public void GameOver ()
	{
		gameOver = true;
	}

	void SpawnBlue() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);

		blueEnemy1.gm = this;
		blueEnemy1.target = player1.transform;
		Instantiate (blueEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);

		blueEnemy2.gm = this;
		blueEnemy2.target = player2.transform;
		Instantiate (blueEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
	}

	void SpawnYellow() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);

		yellowEnemy1.gm = this;
		yellowEnemy1.target = player1.transform;
		Instantiate (yellowEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);

		yellowEnemy2.gm = this;
		yellowEnemy2.target = player2.transform;
		Instantiate (yellowEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
	}

	void SpawnGreen() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);

		greenEnemy1.gm = this;
		greenEnemy1.pt = w1;
		greenEnemy1.wanderIndex = Random.Range (0,6);
		greenEnemy1.target = player1.transform;
		Instantiate (greenEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);

		greenEnemy2.gm = this;
		greenEnemy2.pt = w2;
		greenEnemy2.wanderIndex = Random.Range (0,6);
		greenEnemy2.target = player2.transform;
		Instantiate (greenEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
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

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < 10; i++)
			{
				int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
				int spawnPointIndex2 = Random.Range (0, spawnPoints2.Length);

//				redEnemy1.target = player1.transform;
//				Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
//				
//				redEnemy2.target = player2.transform;
//				Instantiate (redEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
//
//				blueEnemy1.target = player1.transform;
//				Instantiate (blueEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
//				
//				blueEnemy2.target = player2.transform;
//				Instantiate (blueEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);

				yellowEnemy1.target = player1.transform;
				Instantiate (yellowEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				
				yellowEnemy2.target = player2.transform;
				Instantiate (yellowEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);

//				greenEnemy1.pt = w1;
//				greenEnemy1.wanderIndex = Random.Range (0,6);
//				greenEnemy1.target = player1.transform;
//				Instantiate (greenEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
//				
//				greenEnemy2.pt = w2;
//				greenEnemy2.wanderIndex = Random.Range (0,6);
//				greenEnemy2.target = player2.transform;
//				Instantiate (greenEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);


				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restart = true;
				break;
			}
		}
	}

	public void GameOver ()
	{
		gameOver = true;
	}
}
