using UnityEngine;
using System.Collections;

public class Boss1_childCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.transform.tag == "Player") {
			SendMessageUpwards("collisionWithPlayer", true);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.transform.tag == "Player") {
			SendMessageUpwards("collisionExitWithPlayer", true);
		}
	}
}
