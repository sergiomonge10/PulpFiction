using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	public Camera standByCamera;
	SpawnPoint[] spots;
	string playerName;
	string playerSelected;
	GameObject myPlayerGO;
	public GameObject GreenPlayer;
	public GameObject BlackPlayer;
	public GameObject BluePlayer;
	public GameObject YellowPlayer;
	
	// Use this for initialization
	void Start () {
		spots = GameObject.FindObjectsOfType<SpawnPoint>();
		Connect ();
		playerSelected = "";
		playerName = "";
		
	}
	
	void Connect(){
		PhotonNetwork.ConnectUsingSettings ("DemonCrisis1.0");
		
	}
	
	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
	
	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
	}
	
	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
	}
	
	void OnJoinedRoom(){
		SpawnMyPlayer ();
	}
	
	public void SpawnMyPlayer (){
		if (spots != null) {
			
			SpawnPoint mySpawnPoint = spots [Random.Range (0, spots.Length)];
			
			playerSelected = PlayerPrefs.GetString ("characterSelected");
			
			Debug.Log ("ESTADO DE JUGADOR SELECIONADO "+ playerSelected);
			
			if (playerSelected == "Character 1 SELECTED") {
				myPlayerGO = (GameObject)PhotonNetwork.Instantiate ("GreenPlayer", mySpawnPoint.transform.position, mySpawnPoint.transform.rotation, 0);
			}
			if (playerSelected == "Character 2 SELECTED") {
				//SpaceCraft = GameObject.FindGameObjectWithTag("Player02").transform;
				myPlayerGO = (GameObject)PhotonNetwork.Instantiate ("BlackPlayer", mySpawnPoint.transform.position, mySpawnPoint.transform.rotation, 0);
			}
			if (playerSelected == "Character 3 SELECTED") {
				//SpaceCraft = GameObject.FindGameObjectWithTag("Player03").transform;
				myPlayerGO = (GameObject)PhotonNetwork.Instantiate ("BluePlayer", mySpawnPoint.transform.position, mySpawnPoint.transform.rotation, 0);
			}
			if (playerSelected == "Character 4 SELECTED") {
				Debug.Log("CAYO AQUI");
				//GameObject.FindGameObjectWithTag("Player04").transform;
				myPlayerGO = (GameObject)PhotonNetwork.Instantiate ("YellowPlayer", mySpawnPoint.transform.position, mySpawnPoint.transform.rotation, 0);
			}
			
			//GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate("FirstPersonController", mySpawnPoint.transform.position, mySpawnPoint.transform.rotation, 0);
			standByCamera.enabled = false;
			//Activo los scripts de mouse look y los controladores
			((MonoBehaviour)myPlayerGO.GetComponent ("Character Controller")).enabled = true;
			((MonoBehaviour)myPlayerGO.GetComponent ("MouseLook")).enabled = true;
			
			//Activo la camara
			Camera cameraInChildren = myPlayerGO.GetComponentInChildren<Camera> ();
			cameraInChildren.enabled = true;
		} else {
			
			Debug.LogError("No spawnpoints exits");
			return;
		}
	}
	
}

