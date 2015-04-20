using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	private Animator anim;
	private BossCharging bossCharging;
	private GameObject player;
	private PlayerHealth playerHealth;
	private int damage= 50;
	public bool hitting;
	// Use this for initialization

	void Start () {
		GameObject boss = GameObject.FindGameObjectWithTag ("Boss");
		anim = boss.GetComponent<Animator>();
		bossCharging = boss.GetComponent<BossCharging> ();
		player= GameObject.FindGameObjectWithTag("Player");
		if (player != null) {
			playerHealth = (PlayerHealth) player.GetComponent<PlayerHealth>();
		}
		hitting = false;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			anim.SetBool ("Charging", false);
			//anim.SetBool("Hit",true);
			Debug.Log ("Choco contra jugador");
			if(playerHealth!=null && playerHealth.currentHealth > 0){
				playerHealth.TakeDamage (damage, gameObject);
				hitting= true;
				anim.SetBool("Hitting", true);
			}

		}
	}

	void collisionWithPlayer(bool col){
		if (col == true) {
			Debug.Log("Llegue");
			hitting= true;
			anim.SetBool("Backoff", true);
			playerHealth.TakeDamage (damage, gameObject);
		}

	}

	void collisionExitWithPlayer(bool col){
		if (col == true) {
			hitting= false;
			anim.SetBool("Backoff", false);
		}
		
	}

	void OnCollisionExit(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "Player") {
			hitting= false;
			anim.SetBool("Hitting",false);
		}
	}




}
