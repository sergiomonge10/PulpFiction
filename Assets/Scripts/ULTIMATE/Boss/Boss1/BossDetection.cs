using UnityEngine;
using System.Collections;

public class BossDetection : MonoBehaviour 
{
	public LayerMask ignoreRaycast; //Set up the layers!
	
	public float fieldOfView = 30.0f;
	public bool playerDetected;
	
	private Animator anim;
	private GameObject player;
	private SphereCollider col;
	GameObject bosshealth;
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player"); //Set up the tags!
		anim = GetComponent<Animator>();
		col = GetComponent<SphereCollider>();
		bosshealth = GameObject.FindGameObjectWithTag ("BossSlider");
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
			bosshealth.SetActive(true);
			
			if(angle < fieldOfView)
			{
				RaycastHit hit;
				if(Physics.Raycast(transform.position + transform.up / 2, direction, out hit, col.radius, ignoreRaycast))
				{
					if(hit.collider.gameObject == player)
					{
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
			bosshealth.SetActive(false);
		}
	}
	
}