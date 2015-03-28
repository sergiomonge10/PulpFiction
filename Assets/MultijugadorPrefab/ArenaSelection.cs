using UnityEngine;
using System.Collections;

public class ArenaSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public void LoadPlayerSelection(){
		Application.LoadLevel("Multiplayer - Scene03");
	}
}
