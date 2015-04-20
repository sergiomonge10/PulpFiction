using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BossHealth : MonoBehaviour
{
	public int startingHealth;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;
	
	
	Animator anim;
	bool isDead;
	bool isSinking;
	public Slider healthSlider = null;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		startingHealth = 100;
		currentHealth = startingHealth;
		
	}
	
	
	void Update ()
	{
		if(isSinking)
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
		healthSlider.value = currentHealth;
	}
	
	
	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;

		
		currentHealth -= amount;
	
		if(currentHealth <= 0)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{
		isDead = true;
		anim.SetBool ("Death", true);

	}
	

}
