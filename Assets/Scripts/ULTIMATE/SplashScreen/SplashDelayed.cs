using UnityEngine;
using System.Collections;

public class SplashDelayed : MonoBehaviour {

	public float delayTime = 5;
	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(delayTime);

	}
	
	// Update is called once per frame
	void Update () {
		Application.LoadLevel (1);
	}
}
