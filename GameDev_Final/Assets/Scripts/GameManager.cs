using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Player1 player1;
	public Player2 player2;
	public Enemies basicEnemy1;
	public Enemies basicEnemy2;
	public float spawnTime = 1f;
	public Transform[] spawnPoints1;
	public Transform[] spawnPoints2;



	// Use this for initialization
	void Start () {
		// call the SpawnEnemy function once every second afer 1 second.
		InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnEnemy()
	{
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints1.Length);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (basicEnemy1, spawnPoints1[spawnPointIndex].position, spawnPoints1[spawnPointIndex].rotation);
		Instantiate (basicEnemy2, spawnPoints2[spawnPointIndex].position, spawnPoints2[spawnPointIndex].rotation);

	}
}
