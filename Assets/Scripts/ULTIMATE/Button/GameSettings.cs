using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {
	
	public bool showOptions = false;
	public float shadowDrawDistance;
	public int ResX;
	public int ResY;
	public bool Fullscreen;
	// Use this for initialization
	void Start () {
		showOptions = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncreaseQuality(){
		QualitySettings.IncreaseLevel();
		Debug.Log ("Increased quality");
	}

	public void DecreaseQuality(){
		QualitySettings.DecreaseLevel();
		Debug.Log ("Increased quality");
	}

	public void AntiAliasing(int antiAlising){
		QualitySettings.antiAliasing = antiAlising;
		Debug.Log (antiAlising + " AA");
	}

	public void TrippleBuffering(bool activate){
		if (activate) {
			QualitySettings.maxQueuedFrames = 3;
			Debug.Log ("Triple buffering on");
		} else {
			QualitySettings.maxQueuedFrames = 0;
			Debug.Log ("Triple buffering off");
		}
	}

	public void AnisotropicFiltering(bool activate){
		if (activate) {
			//QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
			Debug.Log ("Force enable anisotropic filtering!");
		} else {
			//QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
			Debug.Log ("Disable anisotropic filtering!");
		}
	}

	public void SetHz(int hz){
		Screen.SetResolution(ResX, ResY, Fullscreen, hz);
		Debug.Log (hz+"Hz");
	}

	public void SetResolution(int type){
		if (type == 480) {
			SetResolution(640, 480, Fullscreen);
		}else if(type == 720){
			SetResolution(1280, 720, Fullscreen);
		}else if(type == 1080){
			SetResolution(1920, 1080, Fullscreen);
		}
	}
	
	public void SetResolution(int ResX, int ResY, bool Fullscreen){
		Screen.SetResolution(ResX, ResY, Fullscreen);
		this.ResX = ResX;
		this.ResY = ResY;
		Debug.Log (ResY);
	}

	public void VSync(bool activate){
		if (activate) {
			QualitySettings.vSyncCount = 1;
		} else {
			QualitySettings.vSyncCount = 0;	
		}
	}

	/*void OnGUI() {
		if(showOptions) {
			//INCREASE QUALITY PRESET
			if(GUI.Button(new Rect(810, 100, 300, 100), "Increase Quality")) {
				IncreaseQuality();
			}
			//DECREASE QUALITY PRESET
			if(GUI.Button(new Rect(810, 210, 300, 100), "Decrease Quality")) {
				DecreaseQuality();
			}
			//0 X AA SETTINGS
			if(GUI.Button(new Rect(810, 320, 65, 100), "No AA")) {
				AntiAliasing(0);
			}
			//2 X AA SETTINGS
			if(GUI.Button(new Rect(879, 320, 65, 100), "2x AA")) {
				AntiAliasing(2);
			}
			//4 X AA SETTINGS
			if(GUI.Button(new Rect(954, 320, 65, 100), "4x AA")) {
				AntiAliasing(4);
			}
			//8 x AA SETTINGS
			if(GUI.Button(new Rect(1028, 320, 65, 100), "8x AA")) {
				AntiAliasing(8);
			}
			//TRIPLE BUFFERING SETTINGS
			if(GUI.Button(new Rect(810, 430, 140, 100), "Triple Buffering On")) {
				TrippleBuffering(true);
			}
			if(GUI.Button(new Rect(955, 430, 140, 100), "Triple Buffering Off")) {
				TrippleBuffering(false);
			}
			//ANISOTROPIC FILTERING SETTINGS
			if(GUI.Button(new Rect(190, 100, 300, 100), "Anisotropic Filtering On")) {
				AnisotropicFiltering(true);
			}
			if(GUI.Button(new Rect(190, 210, 300, 100), "Anisotropic Filtering Off")) {
				AnisotropicFiltering(true);
			}
			//RESOLUTION SETTINGS
			//60Hz
			if(GUI.Button(new Rect(190, 320, 300, 100), "60Hz")) {
				SetHz(60);
			}
			//120Hz
			if(GUI.Button(new Rect(190, 430, 300, 100), "120Hz")) {
				SetHz(120);
			}
			//1080p
			if(GUI.Button(new Rect(500, 430, 93, 100), "1080p")) {
				SetResolution(1920, 1080, Fullscreen);
			}
			//720p
			if(GUI.Button(new Rect(596, 430, 93, 100), "720p")) {
				SetResolution(1280, 720, Fullscreen);
			}
			//480p
			if(GUI.Button(new Rect(692, 430, 93, 100), "480p")) {
				SetResolution(640, 480, Fullscreen);
			}
			if(GUI.Button(new Rect(500, 0, 140, 100), "Vsync On")) {
				VSync(true);
			}
			if(GUI.Button(new Rect(645, 0, 140, 100), "Vsync Off")) {
				VSync(false);
			}
		}
	}*/
}