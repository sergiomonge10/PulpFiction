using UnityEngine;
using System.Collections;

public class PortalLevel : MonoBehaviour {
	GameObject boss = null;
	GameObject player = null;
	BossHealth bhealth = null;
	bool isBossDead = false;
	// Use this for initialization
	void Start () {
		boss = GameObject.FindGameObjectWithTag("Boss");
		if (boss == null) {
			isBossDead = true;
		} else {
			bhealth = boss.GetComponent<BossHealth>();
			if(bhealth==null){
				isBossDead=true;
			}
		}
		player = GameObject.FindGameObjectWithTag("Player");
	}



	// Update is called once per frame
	void Update () {

		
	}


	void OnCollisionEnter(Collision collision) {
		if (bhealth != null) {
			if(bhealth.currentHealth == 0){
				isBossDead = true;
			}
		}
		if (collision.gameObject == player && isBossDead) {
			gameObject.collider.isTrigger = true;
			Debug.Log("changed collider to trigger");
		}	
	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log("Entered on trigger");
		if (other.gameObject == player && isBossDead) {
			Debug.Log("Loading next level");
			int nextLevel = Application.loadedLevel + 1;
			if(nextLevel < Application.levelCount){
				Application.LoadLevel(nextLevel);
			}
		}
	}
}
