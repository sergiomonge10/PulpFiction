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
	bool canMove = true;

	void Start() {
		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController>();
		value = false;
	}

	void Update() { 
		if(canMove){
			if (controller.isGrounded ) {
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				if (Input.GetButton("Jump")){
					moveDirection.y = jumpSpeed;
				}
				if (Input.GetButton("Vertical") || Input.GetButton("Horizontal")){
					value = true;
					anim.SetBool("IsWalking",value);
					if ( Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ){
						speed = 10.0F;
						anim.SetBool("isRunning",true);
					} else {
						anim.SetBool("isRunning",false);
					}
				}else if (!Input.GetButton("Vertical") || !Input.GetButton("Horizantal")){
					value= false;
					anim.SetBool("IsWalking",value);
					anim.SetBool("isRunning",value);
				}
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.SimpleMove (Physics.gravity);
			controller.Move(moveDirection * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other) {
		Cartridge comp_clip = other.GetComponent<Cartridge> ();
		if (comp_clip != null) {
			int bullets_to_charge = comp_clip.getClipBullets ();

			GameObject gundEnd = GameObject.FindGameObjectWithTag ("GunEnd");
			PlayerShooting gunScript = gundEnd.GetComponent<PlayerShooting> ();
			gunScript.RecargeBullets (bullets_to_charge);

			StartCoroutine (Wait (other));
			//Destroy(other.gameObject);
		}
	}

	IEnumerator Wait(Collider other) {
		canMove = false;
		Destroy(other.gameObject);
		anim.SetBool ("IsRecharging", true);
		yield return new WaitForSeconds(2);
		anim.SetBool ("IsRecharging", false);
		canMove = true;
	}
}