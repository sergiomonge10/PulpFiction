using UnityEngine;
using System.Collections;

public class BossAnimation : MonoBehaviour {

	private Transform player;
	private BossDetection bossDetection;
	private Animator anim;
	private AnimatorSetup animSetup;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		bossDetection = GetComponent<BossDetection>();
		anim = GetComponent<Animator> ();
		animSetup = new AnimatorSetup (anim);
	}

	void Update(){
		AnimSetup ();
	}

	void OnAnimatorMove(){
	
		transform.position = anim.rootPosition;
		transform.rotation = anim.rootRotation;
	}

	public void AnimSetup(){
		float angle;

		if (bossDetection.playerDetected) {

			angle = FindAngle(transform.forward, player.position - transform.position, transform.up);
		
		}else{

			angle = 0.0f;

		}

		animSetup.Setup(angle);
	}

	float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector){

		if (toVector == Vector3.zero) {
		
			return 0.0f;
		}
		float angle = Vector3.Angle(fromVector, toVector);
		Vector3 normal = Vector3.Cross(fromVector, toVector);

		angle *= Mathf.Sign(Vector3.Dot(normal, upVector));
		angle *= Mathf.Deg2Rad;

		return angle;

	}
}
