//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//
//public class EnemySpawnManager : MonoBehaviour {
//
//	public class SpawnPoints {
//		public Transform pionts;
//		public float spawnDelay;
//	};
//	public SpawnPoints[] spawns;
//
//	public class EnemyType {
//		public Enemies prefabs;
//		public float enemyRatio;
//	};
//	public EnemyType[] enemies;
//
//	private struct Enemy {
//		public int idx;
//		public bool spawned;
//	};
//	private Enemy[] currentEnemies;
//
//	public class Wave_Enemy {
//		public int idx;
//		public int amount;
//	};
//
//	public class Wave {
//		public int wave;
//		public Wave_Enemy[] waveEnemy;
//		public bool spawnOnlyThisWave;
//	};
//	public Wave[] waves;
//
//	public Player1 player;
//	public Transform w;
//
//	private float spawnDelay = 0.4f;
//	private int startingAmt = 10;	//Change to timer
//	public int addEachWave;
//
//	private int amountToSpawn = 0;
//	private int spawnedAmount = 0;
//	private int currentlyAlive = 0;
//	private int leftAmount = 0;
//	private int MAX_ENEMY_AMOUNT = 8;
//
//	private int currentWave = 1;
//	private const byte waitBeforeSpawn = 5;
//
//
//	void Start () {
//
//		WaveFinished (true);
//
//	}
//
//	void Update(){
//
//	}
//
//	public void EnemyKilled(){
//		currentlyAlive--;
//	}
//
//	//This is called when wave is finished
//	private void WaveFinished(bool firstLaunch){
//		if(!firstLaunch) currentWave ++; //add wave count
//
//		else{
//			if(MAX_ENEMY_AMOUNT < 20){
//				MAX_ENEMY_AMOUNT++;
//			}
//		}
//
//		spawnedAmount = 0;
//		currentlyAlive = 0;
//		amountToSpawn = (startingAmt + (addEachWave* (currentWave-1))); //add amount of enemies for next wave
//
//		leftAmount = EnemyAmountLeft(); //calculate how much enemies there will be next wave
//		SetSpawnEnemiesIndexes ();		//Set current Enemies structure, what enemies to spawn and their order
//
//	}
//
//	private void LaunchNextWave(){
//		InvokeRepeating("Spawner",0, spawnDelay); 
//	}
//	
//	//Returns amount, how much emenies we still have to spawn
//	private int EnemyAmountLeft(){
//		return amountToSpawn - spawnedAmount;
//	}
//
//	//Create enemy type index array from enemy types indes - array of enemy numbers to be spawned
//	private void SetSpawnEnemiesIndexes(){
//		//ORIDINARY WAVE
//		//create array of next wave enemies
//		currentEnemies = new Enemy[leftAmount];
//		//set everything to default
//		ResetCurrentEnemies();
//
//		//Loops through all enemy types, to get the ratio and calculate how much this wave they should be spawned
//		//We start from last enemy type because enemy with index 0 is the default enemy which all empty (-1) spots will be filled
//		for(int nn = enemies.Length-1; nn >= 1; nn--){
//			//can this monster be used on start?
//			float ratioAmount = leftAmount/10f;
//			
//			//ratioAmount /= enemyTypes[nn].ratio;
//			//int spawnAmount = Mathf.FloorToInt(ratioAmount);
//			int spawnAmount = Mathf.FloorToInt( ratioAmount*enemies[nn].enemyRatio );
//			
//			if(spawnAmount > 0){
//				//Sets actual enemy indexes in array
//				for(int tt =0; tt <spawnAmount; tt++){
//					int randomPos = Random.Range(0, currentEnemies.Length);
//					//maybe the saved current enemy is busy already, increment till we find empty spot
//					while(currentEnemies[randomPos].idx != -1){
//						randomPos++;
//						if(randomPos > currentEnemies.Length-1) randomPos = 0;
//					}
//					
//					//save enemy type index in array
//					currentEnemies[randomPos].idx = nn;
//				}
//			}
//		}
//	}
//
//	//Reset current enemies to default
//	private void ResetCurrentEnemies(){
//		for(int vv = 0; vv < currentEnemies.Length; vv++){
//			currentEnemies[vv].idx = -1;
//			currentEnemies[vv].spawned = false;
//		}
//	}
//
//	//Spawns actual emenies
//	private void Spawner(){
//		//all enemies have not been spawned, yet
//		//check if scene already does not contain max enemies
//		if(currentlyAlive < MAX_ENEMY_AMOUNT){
//			
//			for(int i =0; i <currentEnemies.Length; i++){
//				//This enemy has not been spawned yet
//				if(!currentEnemies[i].spawned){
//					int thisEnemyTypeIndex = currentEnemies[i].idx;
//					int[] spawnPointIndexes;
//					//===================================================================
//					//random spawn destination
//					int randomPos = Random.Range(0, spawnPointIndexes.Length);
//					
//					for(int j =0; j <spawnPointIndexes.Length; j++){
//						int spawnArrIndex = spawnPointIndexes[randomPos];
//						//is there a cool down on this spawn point
//						if(spawns[spawnArrIndex].pionts.GetComponent<Spawn>().Status()){
//							if (enemies[thisEnemyTypeIndex].prefabs.color == "red") {
//								SpawnRed(enemies[thisEnemyTypeIndex].prefabs, spawnArrIndex);
//							}
//							if (enemies[thisEnemyTypeIndex].prefabs.color == "blue") {
//								SpawnBlue(enemies[thisEnemyTypeIndex].prefabs, spawnArrIndex);
//							}
//							if (enemies[thisEnemyTypeIndex].prefabs.color == "yellow") {
//								SpawnYellow(enemies[thisEnemyTypeIndex].prefabs, spawnArrIndex);
//							}
//							if (enemies[thisEnemyTypeIndex].prefabs.color == "green") {
//								SpawnGreen(enemies[thisEnemyTypeIndex].prefabs, spawnArrIndex);
//							}
//							//mark this enemy as spawned
//							currentEnemies[i].spawned = true;
//							currentlyAlive++;
//							spawnedAmount++;
//							
//							//delay for spawn point 
//							spawns[spawnArrIndex].pionts.gameObject.GetComponent<Spawn>().Spawned(spawns[spawnArrIndex].spawnDelay);
//							
//							return;
//						}
//					}
//				}
//			}
//		}
//
//		else if(currentlyAlive <= 0){
//			CancelInvoke();
//			WaveFinished(false);
//		}
//	}
//
//	void SpawnRed(Enemies redEnemy, int spawnPiontIndex) {
//		redEnemy.target = player.transform;
//		Instantiate (redEnemy, spawns[spawnPiontIndex].pionts.position, spawns[spawnPiontIndex].pionts.rotation);
//	}
//	
//	void SpawnBlue(Enemies blueEnemy, int spawnPiontIndex) {
//		blueEnemy.target = player.transform;
//		Instantiate (blueEnemy, spawns[spawnPiontIndex].pionts.position, spawns[spawnPiontIndex].pionts.rotation);
//
//	}
//	
//	void SpawnYellow(Enemies yellowEnemy, int spawnPiontIndex) {
//		yellowEnemy.target = player.transform;
//		Instantiate (yellowEnemy, spawns[spawnPiontIndex].pionts.position, spawns[spawnPiontIndex].pionts.rotation);
//
//	}
//	
//	void SpawnGreen(Enemies greenEnemy, int spawnPiontIndex) {
//		greenEnemy.pt = w;
//		greenEnemy.wanderIndex = Random.Range (0,6);
//		greenEnemy.target = player.transform;
//		Instantiate (greenEnemy, spawns[spawnPiontIndex].pionts.position, spawns[spawnPiontIndex].pionts.rotation);
//
//	}
//	
//}