#pragma strict
//this is the currently selected object. Unused variable at the moment.
static var currentObject : GameObject;

//these are simply pieces of geometry with an alpha texture on them. 
//You can create any kind of glow geometry to fit your character, vehicle, etc.
var character1Glow : GameObject;
var character2Glow : GameObject;
var character3Glow : GameObject;
//var character4Glow : GameObject;
var arenaSelected;

function Start()
{
character1Glow.renderer.enabled = false;  // We're going to make sure all of the highlighted glows are OFF at scene start.
character2Glow.renderer.enabled = false;
character3Glow.renderer.enabled = false;
//character4Glow.renderer.enabled = false;
}

function Update() 
{ 
if (Input.GetMouseButtonUp (0)) {
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	var hit : RaycastHit;
	
	if (Physics.Raycast (ray, hit, 100))
		{
				// The pink text is where you would put the name of the object you want to click on (has attached collider).
				
	            if(hit.collider.name == "_Character1") 
				SelectedArena1(); //Sends this click down to a function called "SelectedCharacter1(). Which is where all of our stuff happens.
			
				if(hit.collider.name == "_Character2")
				SelectedArena2();
					
				if(hit.collider.name == "_Character3")
				SelectedArena3();
		
				//if(hit.collider.name == "_Character4")
				//SelectedCharacter4();
		}                
	} 
}

function SelectedArena1() {
				Debug.Log ("Arena 1 SELECTED"); //Print out in the Unity console which character was selected.
				arenaSelected = "Arena 1 SELECTED";
				PlayerPrefs.SetString("arenaSelected", arenaSelected);
				character1Glow.renderer.enabled = true; //these lines turn on or off the appropriate character glow.
				character2Glow.renderer.enabled = false;
				character3Glow.renderer.enabled = false;
				//character4Glow.renderer.enabled = false; 
}

function SelectedArena2() {
				Debug.Log ("Arena 2 SELECTED");
				arenaSelected = "Arena 2 SELECTED";
				PlayerPrefs.SetString("arenaSelected", arenaSelected);
				character2Glow.renderer.enabled = true;
				character1Glow.renderer.enabled = false;
				character3Glow.renderer.enabled = false;
				//character4Glow.renderer.enabled = false;
}

function SelectedArena3() {
				Debug.Log("Arena 3 SELECTED");
				arenaSelected = "Arena 3 SELECTED";
				PlayerPrefs.SetString("arenaSelected", arenaSelected);
				character3Glow.renderer.enabled = true;
				character1Glow.renderer.enabled = false;
				character2Glow.renderer.enabled = false;
				//character4Glow.renderer.enabled = false;
}

/**function SelectedCharacter4() {
				Debug.Log ("Character 4 SELECTED");
				//character4Glow.renderer.enabled = true;
				character3Glow.renderer.enabled = false;
				character2Glow.renderer.enabled = false;
				character1Glow.renderer.enabled = false;
}**/