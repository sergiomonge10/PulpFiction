using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManagerMultiplayer : MonoBehaviour
{
	public int score;        // The player's score.
	PlayerHealth playerHealth;
	GameObject gameover;
	GameObject playerUI;
	Text text;                      // Reference to the Text component.

	
	void Start()
	{
		gameover = GameObject.FindGameObjectWithTag("GameOver");
		// Set up the reference.
		text = GetComponent <Text> ();
		if (this != null) {
			playerHealth = this.GetComponent<PlayerHealth> ();
		}
		playerUI = GameObject.FindGameObjectWithTag ("PlayerUI");
		// Reset the score.
		score = 0;

	}
	
	
	void Update ()
	{	if (this != null) {
			playerHealth = this.GetComponent<PlayerHealth> ();
		}
		// Set the displayed text to be the word "Score" followed by the score value.
		if(text != null)
			text.text = "Score: " + score;
		Debug.Log (this.gameObject);

		if (playerHealth.currentHealth <= 0) {
			gameover.SetActive(true);
		}
	}
	public void updateScore(int enemyScore){
		this.score += enemyScore;
		Debug.Log ("score pdated" + this.score);
	}
}
