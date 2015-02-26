using UnityEngine;
using System.Collections;

public class ButtonClicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clicked(){
		Application.LoadLevel("Scene01");
	}
}
