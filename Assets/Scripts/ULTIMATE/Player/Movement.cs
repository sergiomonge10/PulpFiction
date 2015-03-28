using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public Animator anim;
	public CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	public bool value;

	void Start() {
		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController>();
		value = false;
	}

	void Update() { 
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump")){
				moveDirection.y = jumpSpeed;
			}
			if (Input.GetButton("Vertical") || Input.GetButton("Horizontal")){
				value = true;
				anim.SetBool("IsWalking",value);
			}else if (!Input.GetButton("Vertical") || !Input.GetButton("Horizantal")){
				value= false;
				anim.SetBool("IsWalking",value);
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.SimpleMove (Physics.gravity);
		controller.Move(moveDirection * Time.deltaTime);
	}
}