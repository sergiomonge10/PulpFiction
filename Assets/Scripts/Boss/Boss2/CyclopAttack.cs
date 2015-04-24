using UnityEngine;
using System.Collections;

public class CyclopAttack : MonoBehaviour {

	public int savageDamage = 5;
	public int savageSpeed = 10;
	public int savageBlindDistance = 10;
	public float savageRate = 3f;
	public float fireBallRate = 4f;
	public GameObject fireBall;
	private NavMeshAgent navMesh;
	private bool attacking;
	private bool isSavaging;
	private bool hitting;
	private bool isFireBalling;
	private Transform player;
	private float lastSavageTime;
	private float lastrangedAttack;
	private CyclopAnimator animManager;
	private CyclopHealth healthManager;
	private GameObject enemyHealthUI;

	// Use this for initialization
	void Start () {
		this.attacking = false;
		this.hitting = false;
		this.isFireBalling = false;
		this.lastSavageTime = Time.time;
		this.lastrangedAttack = Time.time;
		this.enemyHealthUI = GameObject.FindGameObjectWithTag("EnemyHealthUI");
		this.animManager = this.gameObject.GetComponent<CyclopAnimator> ();
		this.navMesh = this.gameObject.GetComponent<NavMeshAgent> ();
		this.healthManager = this.gameObject.GetComponentInChildren<CyclopHealth>();
		this.animManager.Idle();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.attacking) {
			if(!this.healthManager.isBerserker()){
				if (!this.isSavaging){
					if(Time.time > this.lastSavageTime) {
						this.animManager.Walk();
						Savage();
					}
				}else if(this.savageBlindDistance > this.navMesh.remainingDistance){
					this.navMesh.SetDestination(new Vector3(player.position.x,player.position.y,player.position.z));
					this.navMesh.acceleration = savageSpeed/2;
					this.navMesh.speed = savageSpeed;
				} else if(navMesh.remainingDistance == 0){
					StopSavage();
				}
			}else{
				if(!this.isFireBalling){
					if(Time.time > this.lastrangedAttack){
						this.animManager.Idle();
						this.animManager.RangedAttack();
						this.navMesh.Stop();
						this.lastrangedAttack = Time.time + this.animManager.GetCurrentClipLength();
						this.isFireBalling = true;
					}else{
						this.navMesh.destination = new Vector3(player.position.x,player.position.y,player.position.z);
						this.navMesh.stoppingDistance = 20;
						LookAt ();
					}
				}else if(Time.time > this.lastrangedAttack){
					LookAt ();
					Transform bossPosition = GameObject.FindGameObjectWithTag("Boss").transform;
					Instantiate(fireBall, new Vector3(bossPosition.position.x,bossPosition.position.y+3,bossPosition.position.z), transform.rotation);
					this.isFireBalling = false;

					this.animManager.Walk();
					this.lastrangedAttack = Time.time + this.fireBallRate;
				}
			}
		}
	}


	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player") && !this.attacking) {//if its prepare to attack
			this.attacking = true;
			this.player = other.transform;
			if(enemyHealthUI != null){
				enemyHealthUI.SetActive(true);
			}
		} 
	}


	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Player") && this.isSavaging) {//if its prepare to attack
			StopSavage();
			other.gameObject.BroadcastMessage("TakeDamage", savageDamage);
			LookAt();
			this.animManager.Hit();
			this.hitting = true;
		} 
	}
	
	void Savage(){
		this.navMesh.SetDestination(new Vector3(player.position.x,player.position.y,player.position.z));
		this.animManager.Savage();
		this.isSavaging = true;
	}

	void StopSavage(){
		this.isSavaging = false;
		this.hitting = false;
		this.lastSavageTime = Time.time + this.savageRate;
		this.navMesh.Stop();
	}

	void LookAt ()
	{
		var rotation = Quaternion.LookRotation (player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * 6.0f);
	}

	public bool isHitting(){
		return hitting;
	}

	public void StopHitting(){
		this.animManager.Idle();
		this.hitting = false;
	}


	public bool isOnSavage(){
		return this.isSavaging;
	}


	public bool setOnAttacking(bool attackingParam){
		return this.attacking = false;
	}



}
