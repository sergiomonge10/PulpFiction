#pragma strict
import UnityEngine.UI;

var Health = 100;
var healthSlider : Slider;
private var damaged : boolean; 
var damageImage : Image;   
var flashSpeed : float= 5f;                           
var flashColour : Color = new Color(1f, 0f, 0f, 0.1f);   
var skull : Image;
var Timer = 0.0;

function Start(){
   
   StartCoroutine(addHealth());
 }

function ApplyDammage (TheDammage : int)
{
	Health -= TheDammage;
	damaged = true;
	  // Set the health bar's value to the current health.
    healthSlider.value = Health;
  // skull.color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
	if(Health <= 0)
	{
		Dead();
	}
}
/**
function addHealth()
{
  // skull.color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
  if(Timer >= 5.0){
	if(Health < 100)
		{
		Health += 5;
		healthSlider.value = Health;
		}
	}
}
**/
function Dead()
{
	//RespawnMenu.playerIsDead = true; //VERY IMPORTANT! This line was added in tutorial number 19. If you haven't reached that tutorial yet, go ahead and remove it.
	Debug.Log("Player Died");
}

function Update ()
{
	Timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.
    // If the player has just been damaged...
    
    Debug.Log(Timer);
    
    if(Timer >= 5.0){
    	Timer = 0.0;
    }
    if(damaged)
    {
        // ... set the colour of the damageImage to the flash colour.
        damageImage.color = flashColour;
        skull.color = Color.red; 
        Timer = 0.0;
    }
    // Otherwise...
    else
    {
        // ... transition the colour back to clear.
        damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        skull.color = Color.white;
    }

    // Reset the damaged flag.
    damaged = false;
}



function addHealth ()//Add health to the ship shield
     {
         while (true){ // loops forever...
       		if(!damaged && Timer >= 4.0){
		     if (Health < 100){ // if health < 100...
		   		 // yield new WaitForSeconds(5);
		     	  Health += 10; // increase health and wait the specified time
		     	  healthSlider.value = Health;
		     } else { // if health >= 100, just yield 
		       yield null;
     		}
     		}else{
     		yield null;
     		
     		}
     }
}