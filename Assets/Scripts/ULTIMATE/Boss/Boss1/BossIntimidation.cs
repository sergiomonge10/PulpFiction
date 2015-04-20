using UnityEngine;
using System.Collections;

public class BossIntimidation : MonoBehaviour {

	public bool intimidating;
	public int intimidateCount = 0;
	private int resetIntimidateCount= 0;

	private BossDetection bossDetection;
	private GameObject detectionSphere;
	private BossCharging bossCharging;
	private Animator anim;
	private GameObject player;
	private SphereCollider col;

	void Awake(){
		anim = GetComponent<Animator> ();
	//detectionSphere = GameObject.FindGameObjectWithTag ("SphereCollider");
		bossDetection = GetComponent<BossDetection>();
		bossCharging = GetComponent<BossCharging> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		col = GetComponent<SphereCollider>();

	}

	void Update(){
		RaycastHit hit;
		if (bossDetection.playerDetected) {
			if(Physics.Raycast(transform.position + transform.up /2, transform.forward, out hit, col.radius)){
				if(hit.collider.gameObject == player && !intimidating){
					intimidating = true;
					Debug.Log("Estado de intimidating " + intimidating);
				}
			}
		}
		if (intimidating) {

			anim.SetBool ("Intimidating", intimidating);
			//float intimidateExit= anim.GetFloat ("IntimidateExit");
			//intimidateCount++;

			if(intimidateCount == 2){
				bossCharging.charging = true;
			//	anim.SetBool("FirstAttack", false);
				intimidateCount = 0;
				Debug.Log("Cambiando charging a " +bossCharging.charging );
			}
		} else {
		
			anim.SetBool("Intimidating", intimidating);
		}
	}
	

}
