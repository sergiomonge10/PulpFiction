var newSkin : GUISkin;
var logoTexture : Texture2D;
public var mainCamera : Camera;
public var menuCamera : Camera;

function Start(){
		    var script3 = GetComponent("PauseMenuScript"); 
		    script3.enabled= false;

}

function thePauseMenu() {

    //layout start
    GUI.BeginGroup(Rect(Screen.width / 2 - 150, 50, 300, 250));
    
    //the menu background box
    GUI.Box(Rect(Screen.height,  Screen.width, Screen.height, Screen.width), "");
   
    
    //logo picture
    GUI.Label(Rect(120, 10, 300, 68), logoTexture);
   // mainCamera.camera.active = false;
     //menuCamera.camera.active = true;
    
    ///////pause menu buttons
    //game resume button
    if(GUI.Button(Rect(55, 100, 180, 40), "Resume")) {
		    //resume the game
		    Time.timeScale = 1.0;
		    //disable pause menu
		    var script3 = GetComponent("PauseMenuScript"); 
		    script3.enabled = false;
		    //enable cursor hiding script
		    var script4 = GetComponent("HideCursorSc"); 
		    script4.enabled = true; 
		  //  mainCamera.camera.active = true;
     		//menuCamera.camera.active = false;
    }
    
    //main menu return button (level 0)
    if(GUI.Button(Rect(55, 150, 180, 40), "Main Menu")) {
    Application.LoadLevel(0);
    }
    
    //quit button
    if(GUI.Button(Rect(55, 200, 180, 40), "Quit")) {
    Application.Quit();
    }
    
    //layout end
    GUI.EndGroup(); 
}

function OnGUI () {
    //load GUI skin
    GUI.skin = newSkin;
    
    //show the mouse cursor
    Screen.showCursor = true;
    
    //run the pause menu script
    thePauseMenu();
}