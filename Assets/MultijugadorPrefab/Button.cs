﻿using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown(){
		Application.LoadLevel ("seleccionaArena");
	}

}
