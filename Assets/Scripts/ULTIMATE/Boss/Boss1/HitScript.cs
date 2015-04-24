using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	private Animator anim;
	private BossCharging bossCharging;
	private GameObject player;
	private PlayerHealth playerHealth;
	private int damage= 10;
	public bool hitting;
	// Use this for initialization

	void Start () {
		anim = this.GetComponent<Animator>();
		bossCharging = this.GetComponent<BossCharging> ();
		player= GameObject.FindGameObjectWithTag("Player");

		if (player != null) {
			playerHealth = (PlayerHealth) player.GetComponent<PlayerHealth>();
		}
		hitting = false;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player" && anim != null) {
			anim.SetBool ("Charging", false);
			//anim.SetBool("Hit",true);
			Debug.Log ("Choco contra jugador");
			collision.gameObject.BroadcastMessage("TakeDamage",damage);
			hitting= true;
			anim.SetBool("Hitting", true);
		}
	}

	public void collisionWithPlayer(GameObject obj){
		if (obj != null) {
			hitting= true;
//			anim.SetBool("Backoff", true);
			Debug.Log("Bajando vida");
			Debug.Log(playerHealth);
			playerHealth.TakeDamage(damage);
			//obj.BroadcastMessage("TakeDamage",damage); 
		}

	}

	void collisionExitWithPlayer(GameObject obj){
		if (obj != null && anim != null) {
			hitting= false;
			anim.SetBool("Backoff", false);
		}
		
	}

	void OnCollisionExit(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "Player" && anim != null) {
			hitting= false;
			anim.SetBool("Hitting",false);
		}
	}

	void backOff(){
		if (anim != null) {
			anim.SetBool ("Backoff", true);
		}
	}




}
