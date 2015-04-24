using UnityEngine;
using System.Collections;

public class CyclopAnimator : MonoBehaviour {

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		if (animator != null) {	
		}
	}

	public void Idle(){
		if (animator != null) {
			animator.SetBool("damaged",false);		
			animator.SetBool("rangedAttack",false);		
			animator.SetBool("walk",false);	
		}
	}

	public void Walk(){
		if (animator != null) {
			animator.SetBool("damaged",false);		
			animator.SetBool("walk",true);	
			animator.SetBool("savage",false);		
			animator.SetBool("hit",false);
			animator.SetBool("rangedAttack",false);		
		}
	}

	public void Savage(){
		if (animator != null) {
			animator.SetBool("damaged",false);		
			animator.SetBool("savage",true);
		}
	}

	public void Hit(){
		if (animator != null) {
			animator.SetBool("damaged",false);		
			animator.SetBool("hit",true);		
		}
	}

	public void RangedAttack(){
		if (animator != null) {
			animator.SetBool("rangedAttack",true);		
		}
	}

	public void Dead(){
		if (animator != null) {
			animator.SetBool("damaged",false);		
			animator.SetBool("isDead",true);		
		}
	}

	public void Damaged(){
		if (animator != null) {
			animator.SetBool("damaged",true);		
		}
	}

	public float GetCurrentClipLength(){
		return animator.GetCurrentAnimatorStateInfo (0).length;
	}

}
