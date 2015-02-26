﻿using UnityEngine;
using System.Collections;

public class fade : MonoBehaviour {

	// Update is called once per frame
	public Texture2D fadeTexture;
	public float fadeSpeed = 0.5f;
	public int drawDepth = -1000;
	public int levelTo;
	private float alpha = 1.0f; 
	private int fadeDir = -1;
	private Color color;
	
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;  
		alpha = Mathf.Clamp01(alpha);   
		
		color = GUI.color;
		color.a = alpha;
		GUI.color = color;
		
		GUI.depth = drawDepth;
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

		if( ElapsedTime() >= 2 && fadeDir == -1){
			fadeDir = 1;
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		
		if( ElapsedTime() >= 4 ){
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
	
	private float ElapsedTime(){
		return Time.time - startTime;
	}
}
