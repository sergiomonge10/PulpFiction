using UnityEngine;
using System.Collections;

public class PortalLevel : MonoBehaviour {
	BossHealth bhealth = null;
	bool isBossDead = false;

	// Use this for initialization
	void Start () {
		GameObject boss = GameObject.FindGameObjectWithTag("Boss");
		if (boss == null) {
			isBossDead = true;
		} else {
			this.bhealth = boss.GetComponent<BossHealth>();
			if(this.bhealth==null){
				this.isBossDead=true;
			}
		}
	}
	
	void Update () {	
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player" && !this.isBossDead) {
			if (this.bhealth.currentHealth <= 0) {
				this.isBossDead = true;
				gameObject.collider.isTrigger = true;
			}
		} else if(this.isBossDead) {
			gameObject.collider.isTrigger = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log("Loading next level");
			int nextLevel = Application.loadedLevel + 1;
			if(nextLevel < Application.levelCount){
				Application.LoadLevel(nextLevel);
			}
		}
	}
}
