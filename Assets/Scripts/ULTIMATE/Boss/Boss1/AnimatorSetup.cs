using UnityEngine;
using System.Collections;

public class AnimatorSetup{

	public float angularSpeedDampTime = 0.6f;
	public float angularResponseTime = 0.5f;
	public float angularSpeed;

	private Animator anim;

	public AnimatorSetup (Animator animator){
	
		anim = animator;
	}

	public void Setup(float angle){

		angularSpeed = angle / angularResponseTime;
		anim.SetFloat ("AngularSpeed", angularSpeed, angularSpeedDampTime, Time.deltaTime);
	}
}
