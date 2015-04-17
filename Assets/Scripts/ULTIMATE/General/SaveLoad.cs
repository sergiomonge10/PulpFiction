using UnityEngine;
using System.Collections;

public class SaveLoad : MonoBehaviour {

	private bool canLoadPosition = false;
	private string loadPosition = "true";  //set to "true" is you want to load position or "false" to load only level
	private bool loadLevel = true;
	private MouseLook look1;
	private Transform playerPosition;
	private float playerX;
	private float playerY;
	private float playerZ;

	void Start(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			playerPosition = player.transform;	
		}
		PlayerPrefs.SetString("LoadPosition",loadPosition); //set loadPosition true or false
		if (playerPosition != null && canLoadPosition) {
			LoadPlayer();
		}
	}

	void OnLevelWasLoaded(int level) {
		if (level > 0 && level < 4 && PlayerPrefs.GetInt("LevelName") == level) {
			canLoadPosition = true;
			loadLevel = false;
		}
	}

	public void SavePlayer(){
		if(PlayerPrefs.GetString("LoadPosition") == "true"){   //save current position 
			playerX =(playerPosition.transform.position.x);
			playerY =(playerPosition.transform.position.y);
			playerZ =(playerPosition.transform.position.z);  
			PlayerPrefs.SetFloat("PlayerX",playerX);
			PlayerPrefs.SetFloat("PlayerY",playerY);
			PlayerPrefs.SetFloat("PlayerZ",playerZ);        
			PlayerPrefs.SetString("LoadPosition", "true");   //allow the load position
			Debug.Log("Saved to " + " X: " + PlayerPrefs.GetFloat("PlayerX") + " Y: " + PlayerPrefs.GetFloat("PlayerY") + " Z: " + PlayerPrefs.GetFloat("PlayerZ"));
			loadLevel = false;
		}
		PlayerPrefs.SetInt("LevelName", Application.loadedLevel);   //save current level
	}
	
	public void LoadPlayer(){   //load player position on saved level
		Debug.Log("Starting to load info");
		Debug.Log ("Load Level" + loadLevel);
		Debug.Log ("Can load position" + PlayerPrefs.GetString ("LoadPosition"));
		Debug.Log ("Can load?" + (loadLevel == false && PlayerPrefs.GetString ("LoadPosition") == "true"));
		if(loadLevel == false && PlayerPrefs.GetString("LoadPosition") == "true"){
			playerPosition.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), 
			                                      PlayerPrefs.GetFloat("PlayerY")+2,
			                                      PlayerPrefs.GetFloat("PlayerZ"));
			Debug.Log("Loaded to " + " X: " + PlayerPrefs.GetFloat("PlayerX") + " Y: " + PlayerPrefs.GetFloat("PlayerY") + " Z: " + PlayerPrefs.GetFloat("PlayerZ"));
			Debug.Log("LOAD POS");
		}
	}

	public void LoadSavedLevel(){
		Application.LoadLevel(PlayerPrefs.GetInt("LevelName"));
	}
}
