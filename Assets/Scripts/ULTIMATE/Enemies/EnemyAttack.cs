using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
		public float timeBetweenAttacks = 100000f;
		public float attackTime = 0f;
		public int attackDamage = 1;
		public float lookAtDistance = 25.0f;
		public float chaseRange = 15.0f;
		public float rotationDamping = 6.0f;
		private float distance = 0f;
		private Transform target;
		Animator anim;
		GameObject player;
		PlayerHealth playerHealth;
		EnemyHealth enemyHealth;
		NavMeshAgent navMesh;
		bool playerInRange;
		float timer;
	
		void Awake ()
		{
				attackTime = Time.time;
				player = GameObject.FindGameObjectWithTag ("Player");
				playerHealth = player.GetComponent <PlayerHealth> ();
				enemyHealth = GetComponent<EnemyHealth> ();
				anim = GetComponent <Animator> ();
				navMesh = GetComponent<NavMeshAgent> ();
				target = player.transform;

		}
	
		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject == player) {
						playerInRange = true;
						navMesh.Stop ();
				}
		}
	
		void OnTriggerExit (Collider other)
		{
				if (other.gameObject == player) {
						playerInRange = false;
				}
		}
	
		void Update ()
		{
				if (playerHealth.currentHealth > 0) {
						distance = Vector3.Distance (target.position, transform.position);
						if (playerInRange && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {								
								Attack ();
						} else if (distance < chaseRange) {
								navMesh.destination = target.position;
								walk ();
						} else {
								wait ();	
						}


				} else {
						wait ();
				}
		

		}
	
		void lookAt ()
		{
				var rotation = Quaternion.LookRotation (target.position - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
		}
	
		void Attack ()
		{

		if (Time.time > attackTime) {
						lookAt();
						hit ();
						playerHealth.TakeDamage (attackDamage);
						attackTime = Time.time + anim.GetCurrentAnimatorStateInfo(0).length;
				}
		}
	
		void walk ()
		{
				anim.SetBool ("isIdle", false);
				anim.SetBool ("IsWalking", true);
				anim.SetBool ("IsHitting", false);
		}
	
		void hit ()
		{
				anim.SetBool ("isIdle", false);
				anim.SetBool ("IsWalking", false);
				anim.SetBool ("IsHitting", true);
		
		}
	
		void wait ()
		{
				anim.SetBool ("isIdle", true);
				anim.SetBool ("IsWalking", false);
				anim.SetBool ("IsHitting", false);
		}
}