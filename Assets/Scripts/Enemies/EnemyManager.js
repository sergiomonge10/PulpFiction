import UnityEngine.UI;

var playerHealth : PlayerHealth;       // Reference to the player's heatlh.
var enemy : GameObject;                // The enemy prefab to be spawned.
var spawnTime : float = 8f;            // How long between each spawn.
var spawnPoints : Transform[];         // An array of the spawn points this enemy can spawn from.
var quantity= 10;
public var timerSeconds = 10;
var enemiesHaveSpawn = false;


function Start ()
{
    // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
    //InvokeRepeating ("Spawn", spawnTime, spawnTime);
}
/**
function Update(){

if(GameObject.FindGameObjectsWithTag("Enemy").Length == 10){
	CancelInvoke();
}
}**/

function Spawn (spawnPointIndex: int)
{
    // If the player has no health left...
    if(playerHealth.Health <= 0f)
    {
        // ... exit the function.
        return;
    }

    // Find a random index between zero and one less than the number of spawn points.
    
    // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
    Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    Debug.Log("Instatiate enemy");
    
}
function CountDown(){
 
   timerSeconds--;
 
   if(timerSeconds < 1){
 
     print ("Count down finished");
 
     CancelInvoke("Spawn");
 
   }
 
 }

function OnTriggerEnter (player : Collider) {
				if(player.tag == "Player" && !enemiesHaveSpawn){
			for (i=0; i < quantity; i++){
				var enemySpawnPoint = i%spawnPoints.Length;
				Spawn(enemySpawnPoint);
				yield WaitForSeconds(5);
			}
			enemiesHaveSpawn = true;
		}
		Debug.Log("Spawnie mis enemigos");
	}