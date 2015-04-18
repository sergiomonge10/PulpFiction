using UnityEngine;
using System.Collections;

public class Boss3_particle : MonoBehaviour {

	public GameObject particle;
	public double timer;
	public double inParticle;
	public double actionTime;
	public GameObject player;
	public bool firstAttack;
	Animator bossAnim;

	// Use this for initialization
	void Start () {
		particle = GameObject.FindGameObjectWithTag ("Particle");
		player= GameObject.FindGameObjectWithTag("Player");
		actionTime = Time.time;
		timer = 0.0;
		firstAttack = true;
		bossAnim = GameObject.FindGameObjectWithTag ("Boss").GetComponent<Animator>();
		particle.renderer.enabled= false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (Time.time > actionTime) {
			bossAnim.SetBool ("Atacando", false);
			if (timer > 6.0) {
				bossAnim.SetBool ("Atacando", true);
				Debug.Log ("Esta atacando " + bossAnim.GetBool ("Atacando"));
				actionTime = Time.time + getCurrentClipLength ();
				if (inParticle < 6.0) {
					if (firstAttack == true) {
						particle.transform.position = player.transform.position;
						Debug.Log ("Atacando");
						firstAttack = false;
					}
					particle.renderer.enabled = true;
					inParticle += Time.deltaTime;

					if (inParticle > 6.0) {
						inParticle = 0.0;
					}
				}
				Debug.Log ("Esta atacando " + bossAnim.GetBool ("Atacando"));
				timer = 0.0;
				firstAttack = true;
			}
		}
	}

	public double getCurrentClipLength(){
		return bossAnim.GetCurrentAnimatorStateInfo (0).length;
		
	}

	IEnumerator waitForNextAttack() {
		yield return new WaitForSeconds(10);
	}

	IEnumerator attackTime() {
		yield return new WaitForSeconds(5);
	}
}
