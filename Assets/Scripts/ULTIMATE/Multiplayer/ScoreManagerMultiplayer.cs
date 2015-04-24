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
		// Set up the reference.
		text = GetComponent <Text> ();
		playerHealth = this.GetComponent<PlayerHealth> ();
		gameover = GameObject.FindGameObjectWithTag("GameOver");
		playerUI = GameObject.FindGameObjectWithTag ("PlayerUI");
		// Reset the score.
		score = 0;
		gameover.SetActive (false);

	}
	
	
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		if(text != null)
			text.text = "Score: " + score;
		Debug.Log ("Score: " + score);

		if (playerHealth.currentHealth <= 0) {
			gameover.SetActive(true);
		}
	}
	public void updateScore(int enemyScore){
		this.score += enemyScore;
		Debug.Log ("score pdated" + this.score);
	}
}
