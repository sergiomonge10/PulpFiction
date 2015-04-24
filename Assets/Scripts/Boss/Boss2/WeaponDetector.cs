using UnityEngine;
using System.Collections;

public class WeaponDetector : MonoBehaviour {
	
	CyclopAttack cyclop;

	// Use this for initialization
	void Start () {
		cyclop = GetComponentInParent<CyclopAttack> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (cyclop != null && other.gameObject.CompareTag ("Player") && cyclop.isHitting()) {//if its hitting 
			other.BroadcastMessage("TakeDamage", 20, SendMessageOptions.DontRequireReceiver);
			cyclop.StopHitting();
		} 
	}
}
