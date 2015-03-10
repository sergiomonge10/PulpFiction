﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLenght = 100;
	float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		//float h = Input.GetAxisRaw ("Horizontal");
		//float v = Input.GetAxisRaw ("Vertical");
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);
	}

	void Move(float h, float v)
	{
		movement.Set (v, 0f, h);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		Debug.Log(floorMask);
		Debug.Log(camRay);
		Debug.Log(camRayLenght);
		if(Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
		{
			Debug.Log("MAE");
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		//anim.SetBool ("IsWalking", walking);
	}
}
