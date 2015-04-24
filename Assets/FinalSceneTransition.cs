using UnityEngine;
using System.Collections;

public class FinalSceneTransition : MonoBehaviour {

	float timer;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.fixedTime;
		Debug.Log (timer);
		if (timer >= 10000) {
			Application.LoadLevel(1);
		}
	}
}
