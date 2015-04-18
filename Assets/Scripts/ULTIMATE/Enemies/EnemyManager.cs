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
			if(playerHealth != null){
				InvokeRepeating ("SpawnEnemies", timerSeconds, timerSeconds);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SpawnEnemies ()
	{
		if (spawnEnemies && !enemiesHaveSpawn) {

			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			if (playerHealth.currentHealth <= 0 && quantity <= 0) {
					return;		
			}
			for(int i=1; i<spawnPoints.Length+1 ; i++){
				int enemySpawnPoint = i%spawnPoints.Length;
				Instantiate (enemy, spawnPoints [enemySpawnPoint].position, spawnPoints [enemySpawnPoint].rotation);
				quantity--;
			}

			if(quantity <= 0){
				enemiesHaveSpawn = true;
			}
		}
	}
	
	void OnTriggerEnter (Collider player) {
		if(player.tag == "Player" && !enemiesHaveSpawn){
			if(spawnPoints.Length > 0 && quantity > 0)
			{
				Debug.Log("Starting coroutine");
				spawnEnemies = true;
			}
		}
	}
	
	IEnumerable waitToSpawn(){
		yield return new WaitForSeconds(timerSeconds);
	}
}
