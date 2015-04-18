using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour {

		GameObject screenPrefab;
		public float fadeSpeed = 0.5f;          // Speed that the screen fades to and from black.
		private bool sceneStarting = true;      // Whether or not the scene is still fading in.
		
		void Awake ()
		{

			screenPrefab = GameObject.FindGameObjectWithTag("PlayerUI");
			// Set the texture so that it is the the size of the screen and covers it.
			guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
			// If the scene is starting...
			if (sceneStarting && screenPrefab!=null) {
				screenPrefab.SetActive(false);
				// The scene is no longer starting.
				sceneStarting = false;
				// ... call the StartScene function.
				InvokeRepeating("StartScene",1f,0.1f);
			}
		}
	
	
		void OnLevelWasLoaded(int level) {
			if (level > 0 && level < 4 && PlayerPrefs.GetInt("LevelName") != level) {
				sceneStarting = true;
			}
		}



		void Update ()
		{
			if(Input.GetKeyDown(KeyCode.Return) && !screenPrefab.GetActive()){
				// ... set the colour to clear and disable the GUITexture.
				guiTexture.color = Color.clear;
				guiTexture.enabled = false;
				screenPrefab.SetActive(true);
		}
		}
		
		
		void FadeToClear ()
		{
			// Lerp the colour of the texture between itself and transparent.
			guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
		}
		
		
		void FadeToBlack ()
		{
			// Lerp the colour of the texture between itself and black.
			guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
		}
		
		
		void StartScene ()
		{
			fadeSpeed = fadeSpeed + 0.01f;
			// Fade the texture to clear.
			FadeToClear();
			
			// If the texture is almost clear...
			if(guiTexture.color.a <= 0.05f)
			{
				// ... set the colour to clear and disable the GUITexture.
				guiTexture.color = Color.clear;
				guiTexture.enabled = false;
				screenPrefab.SetActive(true);
			}
		}
}
