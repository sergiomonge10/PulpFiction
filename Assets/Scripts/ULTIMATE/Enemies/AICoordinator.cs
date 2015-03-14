using UnityEngine;
using System.Collections.Generic;

public class AICoordinator : MonoBehaviour {
	
	public float attackDistance = 1.0f;
	public float dangerDistance = 2.0f;
	
	public float attackRate = 10.0f;
	public float attackRateFluctuation = 0.0f;
	
	public float separation = 1.25f;
	public float moveSpeed = 2.0f;
	
	private List<EnemyAttack> ais;
	
	void Start()
	{
		ais = new List<EnemyAttack>();
		
		// record everything spawned at the beginning of the game
		foreach(EnemyAttack e in GameObject.FindObjectsOfType<EnemyAttack>())
		{
			OnSpawned(e.gameObject);
		}
	}
	
	void OnSpawned(GameObject obj)
	{
		var enemy = obj.GetComponent<EnemyAttack>();
		if(enemy != null && !ais.Contains(enemy))
		{
			ais.Add(enemy);
		}
	}
	
	void OnDeath(GameObject victim)
	{
		var enemy = victim.GetComponent<EnemyAttack>();
		if(enemy != null && ais.Contains(enemy))
		{
			ais.Remove(enemy);
		}
	}
	
	void FixedUpdate()
	{
		var dead = new List<int>();
		
		for(int i = 0; i < ais.Count; i++)
		{
			EnemyAttack ai = ais[i];
			if(ai == null)
			{
				dead.Add(i);
				continue;
			}
			
			ai.dangerDistance = dangerDistance;
			ai.attackDistance = attackDistance;
			ai.attackRate = attackRate;
			ai.attackRateFluctuation = attackRateFluctuation;

		}
		
		foreach(int j in dead)
		{
			ais.RemoveAt(j);
		}
	}
}
