using UnityEngine;
using System.Collections;
using Photon;

public class NetworkManager : Photon.MonoBehaviour {
	
	public Camera standByCamera;
	SpawnPoint[] spots;
	string playerName;
	string playerSelected;
	GameObject myPlayerGO;
	public GameObject GreenPlayer;
	public GameObject BlackPlayer;
	public GameObject BluePlayer;
	public GameObject YellowPlayer;
	PhotonView photo;
	string view;
	
	// Use this for initialization
	void Start () {
		spots = GameObject.FindObjectsOfType<SpawnPoint>();
		Connect ();
		playerSelected = "";
		playerName = "";
		view = "";

	
	}
	
	void Connect(){
		PhotonNetwork.ConnectUsingSettings ("DemonCrisis1.0");
//		photo = GameObject.FindGameObjectWithTag ("Player").GetComponent<PhotonView> ();
		
	}
	
	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
		GUILayout.Label (view);
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
			Debug.Log(playerSelected);
			
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
			Debug.Log(myPlayerGO);
			//Activo los scripts de mouse look y los controladores


				myPlayerGO.GetComponent<CharacterController>().enabled= true;
				myPlayerGO.GetComponentInChildren<MouseLook>().enabled = true;
				view= myPlayerGO.GetComponent<PhotonView>().viewID.ToString();
				
				//Activo la camara
				Camera cameraInChildren = myPlayerGO.GetComponentInChildren<Camera> ();
				cameraInChildren.enabled = true;

		} else {
			
			Debug.LogError("No spawnpoints exits");
			return;
		}
	}
	
}

