using UnityEngine;
using System.Collections;

public class Avoider : MonoBehaviour
{	
	public string packTag = "Demon";
	public Transform avoidEnemy;
	public float lastThought{ get; set; }
	public float lastReact{ get; set; }

	private float thinkPeriod = 1.5f;
	private float reactPeriod = 1.0f;
	private Vector3 avoidVec = Vector3.zero;
	private Vector3 distVec{ get; set;}

	void Awake ()
	{
		// offset the start of the think ticks to spread the load out a little
		lastThought += thinkPeriod * Random.value;
		lastReact += reactPeriod * Random.value;
	}
	
	public bool ShouldReact ()
	{
		bool shouldReact = (Time.fixedTime - lastReact) > reactPeriod;
		return shouldReact;
	}
	
	public bool ShouldThink ()
	{
		if ((Time.fixedTime - lastThought) > thinkPeriod) {
			lastThought = Time.fixedTime;
			return true;
		} else {
			return false;
		}
	}

}