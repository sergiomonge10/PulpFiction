using UnityEngine;
using System.Collections;

public class BossArea : MonoBehaviour {

	public bool onAttackRange;

	// Use this for initialization
	void Start () {
		onAttackRange = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			onAttackRange = true;
		}

	}
}
