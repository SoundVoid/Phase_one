using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Player1 player1;
	public Player2 player2;

	public Enemies redEnemy1;
	public Enemies redEnemy2;

//	public Enemies blueEnemy1;
//	public Enemies blueEnemy2;

//	public Enemies yellowEnemy1;
//	public Enemies yellowEnemy2;
//
//	public Enemies greenEnemy1;
//	public Enemies greenEnemy2;
//
//	public Enemies Boss1;
//	public Enemies Boss2;
//	public Enemies Boss3;
//	public Enemies Boss4;

	public float spawnTime;
	private float matchTimer = 60.0f;

	public Transform[] spawnPoints1;
	public Transform[] spawnPoints2;

	public Slider healthBar;
	public Slider healthBar2;



	// Use this for initialization

	void Start () {
		// call the SpawnEnemy function once every second afer 1 second.
		healthBar.maxValue = player1.maxHealth;
		healthBar2.maxValue = player2.maxHealth;
		if (matchTimer > 0.0f) {
			matchTimer -= Time.deltaTime;
			InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
		}
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = player1.currentHealth;
		healthBar2.value = player2.currentHealth;
	}

	void SpawnEnemy()
	{
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex1 = Random.Range (0, spawnPoints1.Length);
		int spawnPointIndex2 = Random.Range (0, spawnPoints1.Length);
		redEnemy1.wanderIndex++;
		redEnemy2.wanderIndex++;
//		if (redEnemy1.wanderIndex > 3 || redEnemy2.wanderIndex > 3) {
//			redEnemy1.wanderIndex = 0;
//			redEnemy2.wanderIndex = 0;
//		}

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		redEnemy1.target = player1.transform;
		Instantiate (redEnemy1, spawnPoints1[spawnPointIndex1].position, spawnPoints1[spawnPointIndex1].rotation);

		redEnemy2.target = player2.transform;
		Instantiate (redEnemy2, spawnPoints2[spawnPointIndex2].position, spawnPoints2[spawnPointIndex2].rotation);

	}
}
