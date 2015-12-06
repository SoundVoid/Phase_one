using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	public Player1 player;

	public Enemies[] enemies;
	public Transform[] spawnPoints;
	public Transform[] wanderPoints;


	[System.Serializable]
	public class Wave_Enemy{
		public int index;
		public int amount;
	}

	[System.Serializable]
	public class Wave{
		public int wave; 					//wave we want to affect with these changes
		public Wave_Enemy[] enemies;		//enemies we want to add/spawn only this wave
	};
	public Wave[] waves;

	private Enemies[] currentEnemies;

	private float spawnDelay = 0.4f;		//spawn each enemy after certain time
	private int startingAmount = 8;			//start amount of emenies
	private int addEachWave = 5;			//how much we will add each wave

	private int amountToSpawn = 0;			//Current amount of enemies
	private int spawnedAmount = 0;			//How much we have spawned
	private int currentlyAlive = 0;
	private int leftAmount = 0;
	private int MAX_ENEMY_AMOUNT = 8; 		//maximum amount of emenies in scene

	private int currentWave = 1;			//current wave
	private const byte waitBeforeSpawn = 5;	//How much wait before each wave spawning


	void Start () {

	}

	void Update () {

	}

	void SpawnRed(Enemies redEnemy, int spawnPiontIndex) {
		redEnemy.target = player.transform;
		Instantiate (redEnemy, spawnPoints[spawnPiontIndex].position, spawnPoints[spawnPiontIndex].rotation);
	}
	
	void SpawnBlue(Enemies blueEnemy, int spawnPiontIndex) {
		blueEnemy.target = player.transform;
		Instantiate (blueEnemy, spawnPoints[spawnPiontIndex].position, spawnPoints[spawnPiontIndex].rotation);

	}
	
	void SpawnYellow(Enemies yellowEnemy, int spawnPiontIndex) {
		yellowEnemy.target = player.transform;
		Instantiate (yellowEnemy, spawnPoints[spawnPiontIndex].position, spawnPoints[spawnPiontIndex].rotation);

	}
	
	void SpawnGreen(Enemies greenEnemy, int spawnPiontIndex) {
		greenEnemy.pt = spawnPoints;
		greenEnemy.wanderIndex = Random.Range (0,6);
		greenEnemy.target = player.transform;
		Instantiate (greenEnemy, spawnPoints[spawnPiontIndex].position, spawnPoints[spawnPiontIndex].rotation);

	}

	//This is called when wave is finished
	private void WaveFinished(bool firstLaunch){
		if(!firstLaunch) currentWave ++; //add wave count

		else{
			if(MAX_ENEMY_AMOUNT < 20){
				MAX_ENEMY_AMOUNT++;
			}
		}

		spawnedAmount = 0;
		currentlyAlive = 0;
		amountToSpawn = (startingAmount + (addEachWave* (currentWave-1))); //add amount of enemies for next wave


		leftAmount = EnemyAmountLeft(); //calculate how much enemies there will be next wave
		SetSpawnEnemies ();		//Set current Enemies structure, what enemies to spawn and their order
	}

	private void LaunchNextWave(){
		InvokeRepeating("Spawner",0, spawnDelay); 
	}

	private void SetSpawnEnemies () {
		currentEnemies = new Enemies[leftAmount];
	}

	private int EnemyAmountLeft(){
		return amountToSpawn - spawnedAmount;
	}

	private void Spawner () {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		for (int sp = 0; sp < enemies.Length; sp++) {
			if (enemies[sp].color == "red") {
				SpawnRed(enemies[sp], spawnPointIndex);
			}
			if (enemies[sp].color == "blue") {
				SpawnBlue(enemies[sp], spawnPointIndex);
			}
			if (enemies[sp].color == "yellow") {
				SpawnYellow(enemies[sp], spawnPointIndex);
			}
			if (enemies[sp].color == "green") {
				SpawnGreen(enemies[sp], spawnPointIndex);
			}
		}
	}
	
}