using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public Camera standByCamera;
	SpawnPoint[] spots;
	// Use this for initialization
	void Start () {
		spots = GameObject.FindObjectsOfType<SpawnPoint>();
		Connect ();

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

	void SpawnMyPlayer (){
		if (spots == null) {
			Debug.LogError("No spawnpoints exits");
			return;
		}
		SpawnPoint mySpawnPoint = spots[Random.Range (0, spots.Length)];
		GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate("FirstPersonController", mySpawnPoint.transform.position, mySpawnPoint.transform.rotation, 0);
		standByCamera.enabled = false;
		//Activo los scripts de mouse look y los controladores
		((MonoBehaviour)myPlayerGO.GetComponent("FPSInputController")).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("MouseLook")).enabled = true;

		//Activo la camara
		Camera cameraInChildren = myPlayerGO.GetComponentInChildren<Camera>();
		cameraInChildren.enabled = true;

	}

}
