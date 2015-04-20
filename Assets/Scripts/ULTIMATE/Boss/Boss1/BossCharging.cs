using UnityEngine;
using System.Collections;

public class BossCharging : MonoBehaviour {

	public bool charging;
	private BossIntimidation bossIntimidation;
	private Animator anim;
	private GameObject boss;
	private GameObject player;
	private bool collision;
	private BossArea bossArea;

	void Awake(){
		bossIntimidation = GetComponent<BossIntimidation>();
		bossArea = (BossArea)GameObject.FindGameObjectWithTag ("BossArea").GetComponent<BossArea>();
		anim = GetComponent<Animator>();
		boss = GameObject.Find("Boss");
		player = GameObject.Find ("Player");
		collision = false;
	}

	void Update(){	
		if (bossArea.onAttackRange) {
			Debug.Log("Rango " + bossArea.onAttackRange);
			if (charging) {
				Debug.Log(charging + " estado");
				bossIntimidation.intimidating = false;
				anim.SetBool ("Charging", charging);}
		} else {
			anim.SetBool("Charging", false);
			Debug.Log("Entrando al else");
		}
	}

	void OnCollisionEnter(Collision col){
		Debug.Log("Colisionando");
		if (col.collider.tag == "Player") {
			anim.SetBool("Charging", false);
		}
		
	}
	
}
