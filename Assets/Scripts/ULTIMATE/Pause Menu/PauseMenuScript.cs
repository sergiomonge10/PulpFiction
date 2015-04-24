using UnityEngine;
using System.Collections;
//using UnityEngine.UI.Image;

public class PauseMenuScript : MonoBehaviour {

	GameObject pauseMenu = null;
	GameObject camera = null;
	private bool _mouseOver = false;
	GameObject healthUI= null;
	GameObject bullets= null;

	void Start () {
		pauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu");
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		healthUI = GameObject.FindGameObjectWithTag ("EvanHealthUI");
		bullets = GameObject.FindGameObjectWithTag ("Bullets");

		if (pauseMenu != null) {
			pauseMenu.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			//show the pause menu
			ShowPauseMenu();

		}
	}
	
	void OnGUI()
	{
		if(!_mouseOver) return;
		//draw your GUI stuff here with Unity's OnGUI code - see ref for details
	}
	void OnMouseOver()
	{
		_mouseOver = true;
	}
	void OnMouseExit()
	{
		_mouseOver = false;
	}
	void ShowPauseMenu(){
		if (pauseMenu != null) {
			pauseMenu.SetActive (!pauseMenu.GetActive ());
			if(pauseMenu.GetActive()){
				StopGame();
			}else{
				ContinueGame();
			}

		}
	}

	public void StopGame(){
		Time.timeScale = 0f;
		camera.GetComponent<MouseLook>().enabled = false;
		camera.GetComponent<MouseAimCamera>().enabled = false;
		healthUI.SetActive(false);
		bullets.SetActive(false);
	}

	public void ContinueGame(){
		Time.timeScale = 1f;
		camera.GetComponent<MouseLook>().enabled = true;
		camera.GetComponent<MouseAimCamera>().enabled = true;
		healthUI.SetActive(true);
		bullets.SetActive(true);
	}

	public void ResumeGame(){
		ShowPauseMenu();
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void MainMenu(){
		Application.LoadLevel(1);
	}
}
