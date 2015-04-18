using UnityEngine;
using System.Collections;

public class EnemyManager2 : MonoBehaviour {
	
	private PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime= 8f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public int quantity= 10;
	public int timerSeconds = 10;
	private bool enemiesHaveSpawn = false;
	
	// Use this for initialization
	void Awake () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			playerHealth = (PlayerHealth)player.GetComponent<PlayerHealth> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Spawn (int spawnPointIndex)
	{
		
		waitToSpawn();
		// If the player has no health left...
		if(playerHealth!=null && playerHealth.currentHealth <= 0f)
		{
			return;
		}
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
	
	void OnTriggerEnter (Collider player) {
		if(player.tag == "Player" && !enemiesHaveSpawn){
			for (int i=0; i < quantity; i++){
				int enemySpawnPoint = i%spawnPoints.Length;
				Spawn(enemySpawnPoint);
				
			}
			enemiesHaveSpawn = true;
		}
		Debug.Log("Spawnie mis enemigos");
	}
	
	IEnumerable waitToSpawn(){
		yield return new WaitForSeconds(timerSeconds);
	}
}
