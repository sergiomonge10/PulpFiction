using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	
	private PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime= 8f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public int quantity= 10;
	public int timerSeconds = 5;
	private bool enemiesHaveSpawn = false;
	private bool spawnEnemies = false;
	
	// Use this for initialization
	void Awake () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			playerHealth = (PlayerHealth)player.GetComponent<PlayerHealth> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnEnemies && !enemiesHaveSpawn) {
			if(playerHealth!=null && playerHealth.currentHealth > 0 && spawnPoints.Length > 0)
			{
				for (int i=1; i < quantity; i++){
					int enemySpawnPoint = i%spawnPoints.Length;
					StartCoroutine("SpawnEnemies",enemySpawnPoint);	
				}
				enemiesHaveSpawn = true;
			}
		}
	}

	IEnumerator SpawnEnemies (int enemySpawnPoint)
	{

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[enemySpawnPoint].position, spawnPoints[enemySpawnPoint].rotation);
		waitToSpawn();

		// If the player has no health left...
		yield return null;
	}
	
	void OnTriggerEnter (Collider player) {
		if(player.tag == "Player" && !enemiesHaveSpawn){
			spawnEnemies = true;
		}
		Debug.Log("Spawnie mis enemigos");
	}
	
	IEnumerable waitToSpawn(){
		yield return new WaitForSeconds(timerSeconds);
	}
}
