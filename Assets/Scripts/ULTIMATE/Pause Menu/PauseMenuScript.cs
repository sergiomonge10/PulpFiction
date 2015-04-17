using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	GameObject pauseMenu = null;
	GameObject continueBtn = null;
	bool isPaused = false;

	void Start () {
		pauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu");
		if (pauseMenu != null) {
			pauseMenu.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape")) {
			//show the pause menu
			ShowPauseMenu();
		}
	}
	
	void ShowPauseMenu(){
		if (pauseMenu != null) {
			pauseMenu.SetActive (!pauseMenu.GetActive ());
			if(pauseMenu.GetActive()){
				Time.timeScale = 0f;
			}else{
				Time.timeScale = 1f;
			}

		}
	}

	public void ResumeGame(){
		ShowPauseMenu();
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void MainMenu(){
		Application.LoadLevel(0);
	}
}
