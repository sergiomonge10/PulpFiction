using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {

	public bool attack = false;
	private Animator anim = null;
	private GameObject boss = null;
	private GameObject player = null;
	private BossArea bossArea = null;
	private HitScript hitScript = null;


	void Awake(){
		bossArea = (BossArea)this.GetComponent<BossArea>();
		hitScript = (HitScript)this.GetComponent<HitScript> ();
		anim = this.GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bossArea != null) {
			if(bossArea.onAttackRange == true) {
				anim.SetBool ("Attack", true);
				if(hitScript.hitting== true){
					anim.SetBool("Attack", false);
				}
			} 
		} 

		}
}