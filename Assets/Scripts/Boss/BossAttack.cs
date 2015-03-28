using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {

	public bool attack;
	private Animator anim;
	private GameObject boss;
	private GameObject player;
	private BossArea bossArea;
	private HitScript hitScript;


	void Awake(){
		bossArea = (BossArea)GameObject.FindGameObjectWithTag ("BossArea").GetComponent<BossArea>();
		hitScript = (HitScript) GameObject.FindGameObjectWithTag("Boss").GetComponent<HitScript>();

		boss = GameObject.FindGameObjectWithTag("Boss");
		player = GameObject.FindGameObjectWithTag ("Player");


		anim = boss.GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bossArea.onAttackRange == true) {
				Debug.Log ("Rango= " + bossArea.onAttackRange);
				anim.SetBool ("Attack", true);
		} else {
			anim.SetBool("Attack", false);
		}

		}
}