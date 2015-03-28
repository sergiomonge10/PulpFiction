using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnCollisionEnter(Collision col){
		Debug.Log("Colisionando");
		if (col.collider.tag == "Player") {
			anim.SetBool("Charging", false);
		}
		
	}
}
