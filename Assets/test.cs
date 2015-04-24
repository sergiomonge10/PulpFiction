using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	PlayerHealth playerScript;
	// Use this for initialization
	void Start () {
		playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Player") {
			col.gameObject.BroadcastMessage("TakeDamage",2);
		}
	}
}
