using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	
	public int attackDamage = 1;
	public float chaseRange = 15.0f;
	public float rotationDamping = 10.0f;
	public float attackDistance = 2.0f;
	public float dangerDistance = 10.0f;
	
	private bool isAttacking = false;
	private float attackTime = 0f;

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
		avoider.lastReact = 0.0f;
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		//Si es el jugador atacamos si tenemos permisos para atacar
		if (other != null && other.gameObject != null && this.navMesh.enabled) {
			if (other.gameObject.CompareTag ("Player") && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {//if its prepare to attack
				Attack (other.gameObject);
			} else if (other.gameObject.CompareTag (avoider.packTag) && !isAttacking) {// si es otro enemigo ajustamos las velocidades para que se alejen
				navMesh.speed = Random.Range (1.0f, 10.0f);
			} else if (playerHealth.currentHealth < 0) {// si el jugador esta muerto esperamos
				navMesh.Stop ();
				anim.wait ();
			}
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.transform.tag == "Player" && this.navMesh.enabled) {
			if(playerHealth.currentHealth > 0){//si el jugador esta vivo y se aleja se cambia la velocidad y deja de atacar
				navMesh.speed =  Random.Range(1.0f,10.0f);
				navMesh.destination = player.transform.position;
			}else{// si el jugador esta muerto y se aleja, esperamos
				navMesh.Stop();
			}
		}
	}
	
	void Update (){
		if (Time.time > attackTime && this.navMesh.enabled) {//Si esta attacando esperamos a que termine la accion
			if (avoider.ShouldReact ()) {//Wait time para bajar el nivel de requests y procesamiento
				if(playerHealth.currentHealth > 0){
					float distance = Vector3.Distance (player.transform.position, transform.position);
					if (distance < dangerDistance) {//Verifica si puede intentar atacar al jugador
						navMesh.speed = 20.0f;
					} else if (distance < chaseRange) {//verifica que persigue al jugador
						if(navMesh.enabled){
						navMesh.destination = player.transform.position;
						anim.walk ();
						}
					}
				} else {
					anim.wait ();	
				}
				avoider.lastReact = Time.fixedTime;
			}
		}
	}
	
	void Attack (GameObject obj)
	{
		LookAt ();
		if (this.navMesh.enabled) {
			this.navMesh.Stop ();
		}
		this.anim.hit();
		this.attackTime = Time.time + this.anim.getCurrentClipLength();
		obj.BroadcastMessage ("TakeDamage", this.attackDamage);
	}

	
	void LookAt ()
	{
		var rotation = Quaternion.LookRotation (player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}
}