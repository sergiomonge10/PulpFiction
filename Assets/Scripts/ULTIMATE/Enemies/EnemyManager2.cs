using UnityEngine;
using System.Collections;

public class EnemyManager2 : MonoBehaviour {

	public PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime= 8f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public int quantity= 10;
	public int timerSeconds = 10;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn ()
	{
		// If the player has no health left...
		if(playerHealth.currentHealth <= 0f)
		{
			// ... exit the function.
			return;
		}
		
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex   = Random.Range (0, spawnPoints.Length);
		Debug.Log (spawnPointIndex);
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		Debug.Log("Instatiate enemy");
		
	}

	void OnTriggerEnter (Collider player) {

		if(player.tag == "Player"){
			for (int i=0; i < quantity; i++){
				Debug.Log("Entre al ciclo");
				//InvokeRepeating ("Spawn", spawnTime, spawnTime);
				Invoke ("Spawn",spawnTime);
				waitToSpawn();
			}
		}
		Debug.Log("Sali del ciclo");
	}

	IEnumerable waitToSpawn(){
		yield return new WaitForSeconds(10);
	}
}
