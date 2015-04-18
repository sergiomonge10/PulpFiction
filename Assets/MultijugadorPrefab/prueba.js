#pragma strict
//var character : CharacterSelect;
var selected;
//var arena : CharacterSelectorMenu;
var arenaSelected;
//var instant : Instantiates;
var PlayerYellow : Transform;
var PlayerGreen : Transform;
var PlayerBlack : Transform;
var PlayerBlue : Transform;


function Start(){
	scenario();
	/**arena = GameObject.FindGameObjectWithTag("CharacterSelectorMenu").GetComponent(CharacterSelectorMenu);
	character = GameObject.FindGameObjectWithTag ("CharacterSelect").GetComponent(CharacterSelect);**/
	arenaSelected = null;
	//PrincipalCharacter();
}

function PrincipalCharacter(){
	selected = PlayerPrefs.GetString("characterSelected");
	if(selected == "Character 1 SELECTED" ){
		//SpaceCraft = GameObject.FindGameObjectWithTag("Player01").transform;
		GameObject.Instantiate(PlayerGreen, transform.position, transform.rotation);
		}
	if(selected == "Character 2 SELECTED" ){
		//SpaceCraft = GameObject.FindGameObjectWithTag("Player02").transform;
		GameObject.Instantiate(PlayerBlack, transform.position, transform.rotation);
		}
	if(selected == "Character 3 SELECTED" ){
		//SpaceCraft = GameObject.FindGameObjectWithTag("Player03").transform;
		GameObject.Instantiate(PlayerBlue, transform.position, transform.rotation);
		}
	if(selected == "Character 4 SELECTED" ){
		//GameObject.FindGameObjectWithTag("Player04").transform;
		GameObject.Instantiate(PlayerYellow, transform.position, transform.rotation);
		}
	
}


function scenario(){
	arenaSelected = PlayerPrefs.GetString("arenaSelected");
	if(arenaSelected == "Arena 1 SELECTED" ){
		Application.LoadLevel ("Multiplayer - Scene02");
		//instant = GameObject.FindGameObjectWithTag ("Instantiate").GetComponent(Instantiates);
		}
		
	if(arenaSelected == "Arena 2 SELECTED" ){
		Application.LoadLevel ("Multiplayer - Scene01");
		//instant = GameObject.FindGameObjectWithTag ("Instantiate").GetComponent(Instantiates);
		}
		
	if(arenaSelected == "Arena 3 SELECTED" ){
		Application.LoadLevel ("Multiplayer - Scene03");
		//instant = GameObject.FindGameObjectWithTag ("Instantiate").GetComponent(Instantiates);
}

}
