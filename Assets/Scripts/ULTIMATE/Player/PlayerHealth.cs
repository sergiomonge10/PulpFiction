using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
	public Image skull;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
	double Timer = 0.0;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
		StartCoroutine(addHealth());
    }


    void Update ()
    {
		Timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.
		// If the player has just been damaged...
		
		if(Timer >= 5.0){
			Timer = 0.0;
		}

        if(damaged)
        {
            damageImage.color = flashColour;
			skull.color = Color.red; 
			Timer = 0.0;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			skull.color = Color.white;
		}
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        //playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        //playerShooting.DisableEffects ();

        //anim.SetTrigger ("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;

		Destroy (gameObject, 2f);
    }


    public void RestartLevel ()
    {
        Application.LoadLevel (Application.loadedLevel);
    }

	IEnumerator addHealth ()//Add health to the ship shield
	{
		while (true){ // loops forever...
			if(!damaged && Timer >= 4.0){
				if (currentHealth < 100){ // if health < 100...
					// yield new WaitForSeconds(5);
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
