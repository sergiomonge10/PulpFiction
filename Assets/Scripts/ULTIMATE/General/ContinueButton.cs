using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	GameObject continueBtn = null;
	// Use this for initialization
	void Start () {
		continueBtn = GameObject.FindGameObjectWithTag ("ContinueButton");
		if (continueBtn != null) {
			Debug.Log(PlayerPrefs.GetInt("LevelName"));
			Debug.Log(PlayerPrefs.GetFloat("PlayerX"));
			if(PlayerPrefs.GetInt("LevelName") < 1 && PlayerPrefs.GetFloat("PlayerX") <= 0 ){
				continueBtn.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
