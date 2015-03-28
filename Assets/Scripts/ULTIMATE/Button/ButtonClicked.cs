using UnityEngine;
using System.Collections;

public class ButtonClicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
}
