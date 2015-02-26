using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (new Vector3 (0, 0, transform.position.z * speed * Time.deltaTime));
	}
	
	void OnCollisionEnter(Collision col){
		//Destroy(gameObject);
		if (col.gameObject.tag == "enemy") {
			Destroy(col.gameObject);
		}
	}
}