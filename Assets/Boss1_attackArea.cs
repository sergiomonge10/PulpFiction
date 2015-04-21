using UnityEngine;
using System.Collections;

public class Boss1_attackArea : MonoBehaviour {

	public bool active;
	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider col){
		if (col.tag == "Boss") {
			active = true;
		}
	}

	void OnTriggerExit (Collider col){
		if (col.tag == "Boss") {
			active= false;
		}
	}

	
	void OnTriggerEnter (Collider col){
		if (col.tag == "Boss") {
			active= true;
		}
	}
}
