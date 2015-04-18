using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	
	private PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime= 8f; // How long between each spawn.
	public int quantity= 10; 
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

	private bool enemiesHaveSpawn = false;
	private bool spawnEnemies = false;
	
	// Use this for initialization
	void Awake () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			this.playerHealth = (PlayerHealth)player.GetComponent<PlayerHealth> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SpawnEnemies ()
	{
		if (this.spawnEnemies && !this.enemiesHaveSpawn) {
			Debug.Log("Spawning first set of enemies");
			if (this.playerHealth.currentHealth <= 0) {
					return;		
			}
			for(int i=1; i<spawnPoints.Length+1 ; i++){//We instantiate first number of enemies on each spawn point
				int enemySpawnPoint = i%spawnPoints.Length;
				Instantiate (enemy, spawnPoints [enemySpawnPoint].position, spawnPoints [enemySpawnPoint].rotation);
				this.quantity--;
			}

			if(quantity <= 0){//if quantity reach to 0 then we don't have more enemies to spawn
				this.enemiesHaveSpawn = true;
			}
		}
	}
	
	void OnTriggerEnter (Collider player) {
		if(player.tag == "Player" && !this.spawnEnemies && this.spawnPoints.Length > 0){//We give permission to the coroutine to start spawning
			this.spawnEnemies = true;
			InvokeRepeating ("SpawnEnemies", 0.1f, this.spawnTime);
		}
	}
}
