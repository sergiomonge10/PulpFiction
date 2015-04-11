using UnityEngine;
using System.Collections;

public class Cartridge : MonoBehaviour {

	int bullets;

	// Use this for initialization
	void Start () {
		bullets = Random.Range(1,100);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0,0,Time.deltaTime*50));
	}

	public int getClipBullets(){
		return bullets;
	}
}
