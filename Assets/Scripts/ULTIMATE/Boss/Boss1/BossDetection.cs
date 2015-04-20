using UnityEngine;
using System.Collections;

public class BossDetection : MonoBehaviour 
{
	public LayerMask ignoreRaycast; //Set up the layers!
	
	public float fieldOfView = 80.0f;
	public bool playerDetected;
	
	private Animator anim;
	private GameObject player;
	private SphereCollider col;
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player"); //Set up the tags!
		anim = GetComponent<Animator>();
		col = GetComponent<SphereCollider>();
	}
	
	void Update()
	{
		//Check to see if player is alive
		anim.SetBool("PlayerDetected", playerDetected);
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject == player)
		{
			playerDetected = false;
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			Debug.DrawRay(transform.position + transform.up / 2, direction, Color.green);
			
			if(angle < fieldOfView)
			{
				RaycastHit hit;
				Debug.Log("Angulo correcto");
				if(Physics.Raycast(transform.position + transform.up / 2, direction, out hit, col.radius, ignoreRaycast))
				{
					Debug.Log("Raycast correcto");
					if(hit.collider.gameObject == player)
					{
						Debug.Log("Colision exitosa");
						playerDetected = true;	
					}
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{
			playerDetected = false;
		}
	}
}