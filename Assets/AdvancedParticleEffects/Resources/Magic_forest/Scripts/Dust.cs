using UnityEngine;
using System.Collections;

public class Dust : MonoBehaviour {
	
	public ParticleEmitter leaf;
	void OnTriggerEnter(Collider other) {
		//particleEmitter.emit = true;
		StartCoroutine("DustShow");
	}
	IEnumerator DustShow() {
		particleEmitter.emit = true;
		leaf.emit = true;
		yield return new WaitForSeconds(3.0f);
		particleEmitter.emit = false;
		leaf.emit = false;
	}
}
