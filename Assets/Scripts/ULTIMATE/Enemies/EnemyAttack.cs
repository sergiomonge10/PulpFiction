using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	
	public int attackDamage = 1;
	public float chaseRange = 15.0f;
	public float rotationDamping = 6.0f;
	public float attackDistance = 2.0f;
	public float dangerDistance = 3.0f;
	public float trackSpeed = 0.1f;
	public float attackRate = 10.0f;
	public float attackRateFluctuation = 0.0f;

	private bool isAttacking = false;
	private bool playerInRange = false;
	private float attackTime = 0f;
	private float actualAttackRate = 0.0f;
	private float distance = 0f;
	private float awayTime = 0f;
	private EnemyAnimator anim;
	private GameObject player;
	private PlayerHealth playerHealth;
	private EnemyHealth enemyHealth;
	private NavMeshAgent navMesh;
	private Avoider avoider;
	
	void Awake ()
	{
		//We get all depencies we are going to work with
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth> ();
		anim = GetComponent <EnemyAnimator> ();
		navMesh = GetComponent<NavMeshAgent> ();
		avoider = GetComponent<Avoider> ();

		//We setup a random attack rate and reset attackTime
		actualAttackRate = attackRate + (Random.value - 0.5f) * attackRateFluctuation;
		attackTime = -actualAttackRate;
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {//if its the player stop the engage
				playerInRange = true;
			navMesh.Stop();
		}
		else if (collider.gameObject.CompareTag (avoider.packTag)) {//if its another enemy get its position to go away
			avoider.avoidEnemy = collider.transform;
			Debug.Log("Colliding with the enemy");
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) {//if its the player stop the engage
				playerInRange = false;
		} else if (collider.gameObject.CompareTag (avoider.packTag)) {//if its another enemy then we are cool
			avoider.avoidEnemy = null;
		}
	}
	
	void Update ()
	{
		distance = Vector3.Distance (player.transform.position, transform.position);
		if (Time.time > attackTime && Time.time > awayTime) {
			if (distance < dangerDistance) {
					isAttacking = playerHealth.RequestAttack(gameObject);
					if (avoider.ShouldThink ()) {
						if (avoider.avoidEnemy != null && !isAttacking) {
							Debug.Log("moviendome lejos de mi companero");
							moveAway (avoider.avoidEnemy.transform.position);
						}
					}
					if (avoider.ShouldReact ()) {
						avoider.lastReact = Time.fixedTime;
						if (isAttacking) {
							distance = Vector3.Distance (player.transform.position, transform.position);
							if(canAttack (distance)){
								Debug.Log("atacando");
								Attack ();
							}
						} else {
							Debug.Log("moviendome lejos del jugador");
							moveAway(player.transform.position);
						}	
					}
			} else if (distance < chaseRange) {
				navMesh.destination = player.transform.position;
				anim.walk ();
			} else {
				anim.wait ();	
			}
		}
	}
	
	void LookAt ()
	{
		var rotation = Quaternion.LookRotation (player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}
	
	void Attack ()
	{
		Debug.Log("starting to attack");
		if (playerHealth.RequestAttack(gameObject)) {
			LookAt ();
			navMesh.Stop();
			anim.hit();
			playerHealth.TakeDamage(attackDamage,gameObject);
			attackTime = Time.time + anim.getCurrentClipLength();
		}
	}

	void moveAway(Vector3 position){
		playerHealth.CancelAttack(gameObject);
		Vector3 moveDirection = Vector3.Cross(Vector3.up, position);
		navMesh.destination = moveDirection.normalized;
		navMesh.Resume();
		awayTime = Time.time + 5;
		anim.walk();
	}

	bool canAttack(float distance){
		//Debug.Log (distance < attackDistance);
		return playerInRange && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0;
	}
}