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
			SendMessageUpwards("collisionWithPlayer", col.gameObject, SendMessageOptions.DontRequireReceiver);
			transform.parent.gameObject.GetComponent<HitScript>().collisionWithPlayer(col.gameObject);
			//Debug.Log("Hitting player");
		}
	}

	void OnTriggerExit(Collider col){
		if (col.transform.tag == "Player") {
			SendMessageUpwards("collisionExitWithPlayer", col.gameObject);
		}
	}

	void OnTriggerStay(Collider col){
		if (col.transform.tag == "Player") {
			SendMessageUpwards("collisionExitWithPlayer", col.gameObject, SendMessageOptions.DontRequireReceiver);
			//transform.parent.gameObject.GetComponent<HitScript>().collisionWithPlayer(col.gameObject);

		}
	}
	/**

	void TakeDamage(int ammount){
		SendMessageUpwards("TakeDamage", ammount);
	}
	**/
}
