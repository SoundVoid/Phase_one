using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Player1 player;
	public Player2 player2;
	public Enemies basicEnemy;
	public Enemies fierceEnemy;
	public Transform[] spawnPoints;
	public Slider healthBar;
	public Slider healthBar2;
	// Use this for initialization
	void Start () {
		// call the SpawnEnemy function once every second afer 1 second.
		healthBar.maxValue = player.maxHealth;
		healthBar2.maxValue = player2.maxHealth;
		//InvokeRepeating("SpawnEnemy", 1f, 1f);
	
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = player.currentHealth;
		healthBar2.value = player.currentHealth;
	}

	void SpawnEnemy()
	{

		// we could randomize fierce vs. basic

		//instantiate new enemy
		Enemies newEnemy = (Enemies) Instantiate(basicEnemy, spawnPoints[Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);
		//set enemy's target to player
		newEnemy.target = player.transform;
		//activating my game objects, for some reason they're deactivated!!!
		newEnemy.gameObject.SetActive(true);

	}
}
