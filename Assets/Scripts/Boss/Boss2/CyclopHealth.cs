using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CyclopHealth : MonoBehaviour {

	public int health = 250;
	public int currentHealth = 250;
	private bool bersekMode = false;
	private bool isDead = false;
	private float dyingAnimDuration = 0f;
	private CyclopAnimator animManager;
	private CyclopAttack attackManager;
	public Slider healthSlider = null;

	// Use this for initialization
	void Start () {
		this.animManager = this.gameObject.GetComponentInParent<CyclopAnimator> ();
		this.attackManager = this.gameObject.GetComponentInParent<CyclopAttack> ();
	}

	void Update(){
		if (this.isDead) {
			if(Time.time > this.dyingAnimDuration){
				this.gameObject.renderer.enabled = false;
			}		
		}
	}

	public bool TakeDamage(int ammount){
		if (!this.attackManager.isOnSavage ()) {
			this.animManager.Damaged ();
			this.currentHealth = this.currentHealth - ammount;
			if (!this.bersekMode && this.currentHealth < 100) {
				Debug.Log("On Berserker mode");
				this.bersekMode = true;
			}
			healthSlider.value = currentHealth;
			if(currentHealth < 0){
				Die();
			}
		}
		return true;
	}

	void Die(){
		this.animManager.Dead();
		this.isDead = true;
		NavMeshAgent mesh = GetComponentInParent<NavMeshAgent>();
		attackManager.setOnAttacking (false);
		mesh.enabled = false;
		this.dyingAnimDuration = Time.time + this.animManager.GetCurrentClipLength ();
	}
	public bool isBerserker(){
		return this.bersekMode;
	}
}
