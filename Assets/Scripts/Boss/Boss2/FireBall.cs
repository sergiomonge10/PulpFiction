using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public float movementSpeed = 10;
	public float maxExistenceTime = 10f;
	public int damage = 10; 
	private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		this.initialPosition = transform.position;
		this.maxExistenceTime += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time < maxExistenceTime) {
			transform.position += transform.forward * Time.deltaTime * movementSpeed;
			transform.Rotate(Vector3.right * Time.deltaTime);
		} else {
			this.gameObject.renderer.enabled =false;
			GameObject.Destroy(this.gameObject);	
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals ("Player")) {
			other.gameObject.BroadcastMessage("TakeDamage",damage,SendMessageOptions.DontRequireReceiver);	
			this.gameObject.renderer.enabled =false;
			GameObject.Destroy(this.gameObject);	
		}
	}
}
