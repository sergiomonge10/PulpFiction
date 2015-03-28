using UnityEngine;
using System.Collections;

public class BossArea : MonoBehaviour {

	public bool onAttackRange{ get; set;}

	// Use this for initialization
	void Start () {
		onAttackRange = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			Debug.Log("Jonathan es gay");
			onAttackRange = true;
		}

	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player" || col.tag== "Boss") {
			Debug.Log("saliendo del colider");
			onAttackRange = false;
		}

	}
	
}
