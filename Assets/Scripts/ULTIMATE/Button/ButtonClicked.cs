using UnityEngine;
using System.Collections;

public class ButtonClicked : MonoBehaviour {
	GameObject options = null;
	// Use this for initialization
	void Start () {
		options = GameObject.FindGameObjectWithTag ("Options");
		if (options != null) {
			options.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene1(){
		Application.LoadLevel("Scene01");
	}

	public void LoadPlayerSelection(){
		Application.LoadLevel("menuMultiPlayer");
	}

	public void ShowOptions(){
		if (options != null) {
			options.SetActive (!options.GetActive ());
		}
	}
}
