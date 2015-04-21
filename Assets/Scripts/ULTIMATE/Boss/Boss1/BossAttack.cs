using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {

	public bool attack = false;
	private Animator anim = null;
	private GameObject boss = null;
	private BossArea bossArea = null;
	private PlayerHealth playerHealth = null;
	private HitScript hitScript = null;
	private Boss1_attackArea area= null;
	private BossDetection detection= null;
	private GameObject player= null;
	public float timer;

	void Awake(){
		bossArea = (BossArea)this.GetComponent<BossArea>();
		hitScript = (HitScript)this.GetComponent<HitScript> ();
		playerHealth = (PlayerHealth)GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		area = (Boss1_attackArea)GameObject.FindGameObjectWithTag ("BossArea").GetComponent<Boss1_attackArea> ();
		detection = (BossDetection)this.GetComponent<BossDetection> ();
		player = GameObject.FindGameObjectWithTag("Player");
		anim = this.GetComponent<Animator>();
		timer = 0;
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (bossArea != null) {
			if(bossArea.onAttackRange == true && playerHealth.isDead == false && area.active == true) {
				if(hitScript.hitting== true){
					anim.SetBool("Attack", false);
					this.transform.rotation = player.transform.rotation;
					this.transform.LookAt(player.transform);
				}else{
					anim.SetBool ("Attack", true);
				}
			}else if(area.active == false){
				anim.SetBool("Attack", false);
				this.transform.rotation = player.transform.rotation;
				this.transform.LookAt(player.transform);
			} 
		} 

	}
	

}