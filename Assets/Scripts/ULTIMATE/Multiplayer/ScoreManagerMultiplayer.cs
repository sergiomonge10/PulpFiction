using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManagerMultiplayer : MonoBehaviour
{
	public int score;        // The player's score.
	
	
	Text text;                      // Reference to the Text component.

	
	void Start()
	{
		// Set up the reference.
		text = GetComponent <Text> ();
		// Reset the score.
		score = 0;
	}
	
	
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		if(text != null)
			text.text = "Score: " + score;
		Debug.Log ("Score: " + score);
	}
	public void updateScore(int enemyScore){
		this.score += enemyScore;
		Debug.Log ("score pdated" + this.score);
	}
}
