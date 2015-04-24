using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
	public int current_bullets = 100; 
	Boss3_health boss3health;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
		//boss3health = GameObject.FindGameObjectWithTag ("Boss").GetComponent<Boss3_health> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
			if(current_bullets > 0){
            	Shoot ();
			}
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

		current_bullets = current_bullets - 1;
		ScoreManager.bullets = current_bullets;

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			shootHit.collider.gameObject.BroadcastMessage("TakeDamage",damagePerShot,SendMessageOptions.DontRequireReceiver);
			gunLine.SetPosition (1, shootHit.point);
		}
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

	public void RecargeBullets (int recharge){
		if (current_bullets < 500) { 
			current_bullets = current_bullets + recharge;
			ScoreManager.bullets = current_bullets;
		}
	}
}
