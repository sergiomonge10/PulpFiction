using UnityEngine;
using System.Collections;
//using UnityEngine.UI.Image;

public class PauseMenuScript : MonoBehaviour {

	GameObject pauseMenu = null;
	GameObject camera = null;
	private bool _mouseOver = false;
	GameObject btnContinue = null;
	GameObject btnMainMenu = null;
	GameObject btnSave = null;
	GameObject btnLoad = null;
	GameObject btnExit = null;
	GameObject healthUI= null;
	GameObject bullets= null;

	void Start () {
		pauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu");
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		btnContinue = GameObject.FindGameObjectWithTag ("PauseMenuContinue");
		btnMainMenu = GameObject.FindGameObjectWithTag ("PauseMenuMainMenu");
		btnSave = GameObject.FindGameObjectWithTag ("PauseMenuSave");
		btnLoad = GameObject.FindGameObjectWithTag ("PauseMenuLoad");
		btnExit = GameObject.FindGameObjectWithTag ("PauseMenuExit");
		healthUI = GameObject.FindGameObjectWithTag ("EvanHealthUI");
		bullets = GameObject.FindGameObjectWithTag ("Bullets");

		if (pauseMenu != null) {
			pauseMenu.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape")) {
			//show the pause menu
			ShowPauseMenu();
			camera.GetComponent<MouseLook>().enabled = false;
			camera.GetComponent<MouseAimCamera>().enabled = false;
			healthUI.SetActive(false);
			bullets.SetActive(false);
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
				Time.timeScale = 0f;
			}else{
				Time.timeScale = 1f;
			}

		}
	}

	public void ResumeGame(){
		ShowPauseMenu();
		camera.GetComponent<MouseLook>().enabled = true;
		camera.GetComponent<MouseAimCamera>().enabled = true;
		healthUI.SetActive(true);
		bullets.SetActive(true);
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void MainMenu(){
		Application.LoadLevel(0);
	}
}
