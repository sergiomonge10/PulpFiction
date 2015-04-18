using UnityEngine;
using System.Collections;

public class Cartridge : MonoBehaviour {

	int bullets;
	public int range1 = 1;
	public int range2 = 100;

	// Use this for initialization
	void Start () {
		bullets = Random.Range(range1,range2);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0,0,Time.deltaTime*50));
	}

	public int getClipBullets(){
		return bullets;
	}
}
