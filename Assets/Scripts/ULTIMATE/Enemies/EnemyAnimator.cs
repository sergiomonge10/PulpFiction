using UnityEngine;
using System.Collections;

public class EnemyAnimator : MonoBehaviour
{
		public AudioClip walkAudio;
		public AudioClip roarAudio;
		public AudioClip attackAudio;
		public Animator anim;
	
		void Awake ()
		{
				anim = GetComponent <Animator> ();
		}
	
		public void walk ()
		{
				if (!anim.GetBool ("IsWalking")) {
						anim.SetBool ("isIdle", false);
						anim.SetBool ("IsWalking", true);
						anim.SetBool ("IsHitting", false);
						if (walkAudio != null) {
								audio.clip = walkAudio;
								audio.Play ();
						}
				}
		}
	
		public void hit ()
		{
				anim.SetBool ("isIdle", false);
				anim.SetBool ("IsWalking", false);
				anim.SetBool ("IsHitting", true);
				if (attackAudio != null) {
			
						audio.PlayOneShot (attackAudio, 0.7F);
				}
		
		}
	
		public void wait ()
		{
				anim.SetBool ("isIdle", true);
				anim.SetBool ("IsWalking", false);
				anim.SetBool ("IsHitting", false);
				if (roarAudio != null) {
						audio.clip = roarAudio;
						audio.Play ();
				}
		}

	public float getCurrentClipLength(){
		return anim.GetCurrentAnimatorStateInfo (0).length;

	}
}