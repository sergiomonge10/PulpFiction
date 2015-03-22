using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public Animator anim;
	public CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	void Start() {
		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController>();
	}

	void Update() { 
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			if (Input.GetButton("Vertical") || Input.GetButton("Horizantal"))
				anim.SetBool("IsWalking",true);
			else
				anim.SetBool("IsWalking",false);
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.SimpleMove (Physics.gravity);
		controller.Move(moveDirection * Time.deltaTime);
	}
}