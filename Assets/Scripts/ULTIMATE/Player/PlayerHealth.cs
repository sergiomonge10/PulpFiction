using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public GameObject damageImage;
	public GameObject skull;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	private List<GameObject> attackers;
	public int simultaneousAttackers = 2;
	public float recuperationSpeed=6.0f;
	GameObject gameOver;

	
	Animator anim;
	AudioSource playerAudio;
	PlayerMovement playerMovement;
	PlayerShooting playerShooting;
	public bool isDead;
	bool damaged;
	double Timer = 0.0;
	GameObject bosshealth;
	GameObject camara = null;
	GameObject healthUI= null;
	GameObject bullets= null;
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <PlayerMovement> ();
		playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
		attackers = new List<GameObject>();
		StartCoroutine(addHealth());
		isDead = false;
		healthSlider = (Slider)GameObject.FindGameObjectWithTag ("PlayerHealthSlider").GetComponent<Slider>();
		damageImage = GameObject.FindGameObjectWithTag ("DamageImage");
		bosshealth = GameObject.FindGameObjectWithTag ("BossSlider");
		skull = GameObject.FindGameObjectWithTag ("Skull");
		gameOver = GameObject.FindGameObjectWithTag ("GameOver");
		healthUI = GameObject.FindGameObjectWithTag ("EvanHealthUI");
		bullets = GameObject.FindGameObjectWithTag ("Bullets");
		camara = GameObject.FindGameObjectWithTag ("MainCamera");

		if (bosshealth != null) {
			bosshealth.SetActive(false);
		}

		gameOver.SetActive (false);

	}

	
	void Update ()
	{
		Timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.
		// If the player has just been damaged...
		addHealth ();
		
		if(Timer >= 5.0){
			Timer = 0.0;
		}
		
		if(damaged)
		{
			damageImage.GetComponent<Image>().color = flashColour;
			skull.GetComponent<Image>().color = Color.red; 
			Timer = 0.0;
		}
		else
		{
			damageImage.GetComponent<Image>().color = Color.Lerp (damageImage.GetComponent<Image>().color, Color.clear, flashSpeed * Time.deltaTime);
			skull.GetComponent<Image>().color = Color.white;
		}
		damaged = false;
	}
	
	
	public bool TakeDamage (int amount)
	{
		Debug.Log("Bajando daño");
		damaged = true;
		
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}

		
		return true;
	}
	
	
	void Death ()
	{
		isDead = true;
		anim.SetBool ("Die", true);
		gameOver.GetComponent<GameOver> ().ShowGameOver();
		camara.GetComponent<MouseLook>().enabled = false;
		camara.GetComponent<MouseAimCamera>().enabled = false;
		healthUI.SetActive(false);
		bullets.SetActive(false);
		gameOver.SetActive (true);
	}
	
	
	public void CancelAttack(GameObject attacker){
		attackers.Remove (attacker);
	}
	
	public bool RequestAttack(GameObject requestor)
	{
		attackers.RemoveAll(item => item == null);
		
		if(attackers.Count < simultaneousAttackers)
		{
			if(!attackers.Contains(requestor)){
				attackers.Add(requestor);
			}
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public void RestartLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	IEnumerator addHealth ()//Add health to the ship shield
	{
		while (true){ // loops forever...
			if(!damaged && Timer >= recuperationSpeed){
				if (currentHealth < 100){ // if health < 100...
					//yield new WaitForSeconds(5);
					currentHealth += 10; // increase health and wait the specified time
					healthSlider.value = currentHealth;
				} else { 
					yield return null;
				}
			}else{
				yield return null;
				
			}
		}
	}
}
