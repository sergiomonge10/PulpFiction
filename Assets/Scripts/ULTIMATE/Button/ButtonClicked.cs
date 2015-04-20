using UnityEngine;
using System.Collections;

public class ButtonClicked : MonoBehaviour {
	GameObject options = null;
	GameObject background = null;
	// Use this for initialization
	void Start () {
		options = GameObject.FindGameObjectWithTag ("Options");
		background = GameObject.FindGameObjectWithTag ("BackgroundMainMenuImage");

		if (options != null && background != null) {
			options.SetActive(false);
			background.SetActive(false);

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
		if (options != null && background != null) {
			options.SetActive (!options.GetActive ());
			background.SetActive(!background.GetActive());
		}
	}
}
