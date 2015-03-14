using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public GameObject bullet_var;
	float speed = 20f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Camera cam = Camera.main;
		if(Input.GetButtonDown("Fire1")){
			//transform.Translate(new Vector3 (0,0,transform.position.z * speed * Time.deltaTime));
			GameObject theBullet = (GameObject)Instantiate(bullet_var,cam.transform.position + cam.transform.forward,cam.transform.rotation);
			theBullet.rigidbody.AddForce(cam.transform.forward * speed, ForceMode.Impulse);
		}
		
	}
}
