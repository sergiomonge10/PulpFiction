using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	 GameObject gameOver = null;
	 GameObject imageGameOver = null;
	 GameObject textGameOver = null;
	 GameObject camara = null;
	 GameObject healthUI= null;
	 GameObject bullets= null;
	 PlayerHealth playerHealth= null;

	// Use this for initialization
	void Start () {
		gameOver = GameObject.FindGameObjectWithTag ("GameOver");
		camara = GameObject.FindGameObjectWithTag ("MainCamera");
		imageGameOver = GameObject.FindGameObjectWithTag ("ImageGameOver");
		textGameOver = GameObject.FindGameObjectWithTag ("TextGameOver");
		healthUI = GameObject.FindGameObjectWithTag ("EvanHealthUI");
		bullets = GameObject.FindGameObjectWithTag ("Bullets");
		playerHealth = (PlayerHealth)GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		if (gameOver != null) {
			gameOver.SetActive(false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		/**if(playerHealth.isDead || playerHealth.currentHealth ==0) {
			//show the GameOver
			ShowGameOver();
			camara.GetComponent<MouseLook>().enabled = false;
			camara.GetComponent<MouseAimCamera>().enabled = false;
			healthUI.SetActive(false);
			bullets.SetActive(false);
		}**/

	}

	public void ShowGameOver(){
		if (gameOver != null) {
			gameOver.SetActive (!gameOver.GetActive ());
			if(gameOver.GetActive()){
				Time.timeScale = 0f;
			}else{
				Time.timeScale = 1f;
			}

		}
	
		//Application.LoadLevel("GameMenu");
	}
}
