using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss3_health : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	Animator boss3Anim;
	bool isDead;
	public Slider slider;

	// Use this for initialization
	void Start () {
		startingHealth = 200;
		currentHealth = startingHealth;
		boss3Anim = GetComponent<Animator>();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value= currentHealth;
		Death ();
	}

	public void TakeDamage(int amount){
		if (!isDead) {
			currentHealth = currentHealth-amount;
		} else {
			return;
		}
	}

	void Death(){
		if (currentHealth <= 0) {
			isDead= true;
			Application.LoadLevel (10);
			boss3Anim.SetBool("Die", isDead);
			//StartCoroutine(waitForClip());
			transform.renderer.enabled= false;
		}
	}

	IEnumerator waitForClip(){
		yield return new WaitForSeconds(2);
	}
	
}
