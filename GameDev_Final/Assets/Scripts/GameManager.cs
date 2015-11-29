using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Player1 player1;
	public Player2 player2;

	public Enemies redEnemy1;
	public Enemies redEnemy2;

	public Enemies blueEnemy1;
	public Enemies blueEnemy2;

	public Enemies yellowEnemy1;
	public Enemies yellowEnemy2;

	public Enemies greenEnemy1;
	public Enemies greenEnemy2;
//
//	public Enemies Boss1;
//	public Enemies Boss2;
//	public Enemies Boss3;
//	public Enemies Boss4;

	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float spawnTime;

	public Transform[] spawnPoints1;
	public Transform[] spawnPoints2;

	public Slider healthBar;
	public Slider healthBar2;
	
	public Transform[] w1;
	public Transform[] w2;

	private float matchTimer = 300.0f;

	private bool gameOver;
	private bool restart;


	// Use this for initialization

	void Start () {

		gameOver = false;
		restart = false;

		// call the SpawnEnemy function once every second afer 1 second.
		healthBar.maxValue = player1.maxHealth;
		healthBar2.maxValue = player2.maxHealth;

		//InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
		//StartCoroutine (SpawnWaves ());
		//SpawnEnemy();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = player1.currentHealth;
		healthBar2.value = player2.currentHealth;

		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Debug.Log ("Reset");
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		int num = 0;
		if (matchTimer > 0.0f) {
			matchTimer -= Time.deltaTime;
		} 
	}

	void SpawnRed() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints1.Length);

		redEnemy1.target = player1.transform;
		Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		
		redEnemy2.target = player2.transform;
		Instantiate (redEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
	}

	void SpawnBlue() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints1.Length);

		blueEnemy1.target = player1.transform;
		Instantiate (blueEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		
		blueEnemy2.target = player2.transform;
		Instantiate (blueEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
	}

	void SpawnYellow() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints1.Length);

		yellowEnemy1.target = player1.transform;
		Instantiate (yellowEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
		
		yellowEnemy2.target = player2.transform;
		Instantiate (yellowEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);
	}

	void SpawnGreen() {
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints1.Length);

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
	
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < 10; i++)
			{
				int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
				int spawnPointIndex2 = Random.Range (0, spawnPoints1.Length);

				redEnemy1.target = player1.transform;
				Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				
				redEnemy2.target = player2.transform;
				Instantiate (redEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);

				blueEnemy1.target = player1.transform;
				Instantiate (blueEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				
				blueEnemy2.target = player2.transform;
				Instantiate (blueEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);

				yellowEnemy1.target = player1.transform;
				Instantiate (yellowEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				
				yellowEnemy2.target = player2.transform;
				Instantiate (yellowEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);

				greenEnemy1.pt = w1;
				greenEnemy1.wanderIndex = Random.Range (0,6);
				greenEnemy1.target = player1.transform;
				Instantiate (greenEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);
				
				greenEnemy2.pt = w2;
				greenEnemy2.wanderIndex = Random.Range (0,6);
				greenEnemy2.target = player2.transform;
				Instantiate (greenEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);


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
