using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	private Animator anim;
	private BossCharging bossCharging;
	private GameObject player;
	private int damage= 1;
	public bool hitting{ get; set;}
	// Use this for initialization

	void Start () {
		GameObject boss = GameObject.FindGameObjectWithTag ("Boss");
		anim = boss.GetComponent<Animator>();
		bossCharging = boss.GetComponent<BossCharging> ();
		player= GameObject.FindGameObjectWithTag("Player");
		hitting = false;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			anim.SetBool("Charging", false);
			//anim.SetBool("Hit",true);
			Debug.Log("Choco contra jugador");
			//bossCharging.charging = false;
			player.BroadcastMessage ("ApplyDammage",damage);
			hitting =true;

		}	
	}


}
