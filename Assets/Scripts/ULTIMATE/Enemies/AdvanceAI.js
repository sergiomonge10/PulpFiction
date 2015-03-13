var Distance;
var lookAtDistance = 25.0;
var chaseRange = 15.0;
var attackRange = 1.5;
var moveSpeed = 5.0;
var Damping = 6.0;
var attackRepeatTime = 25f;
var TheDammage = 2;
private var anim : Animator; 
private var Target : Transform;
private var player : GameObject;
private var playerHealth : PlayerHealth; 

var controller : CharacterController;
var gravity : float = 20.0;
private var MoveDirection : Vector3 = Vector3.zero;

function Start ()
{
	attackTime = Time.time;
	try{
		attackTime = Time.time;
		player = GameObject.FindWithTag("Player");
		anim = GetComponent (Animator);
		if(player!= null){
			Target = player.transform;
			playerHealth = player.GetComponent(PlayerHealth);
		}
	}catch(e){
		Debug.log(e);
	}
	
}

function Update ()
{
	
	Distance = Vector3.Distance(Target.position, transform.position);
	
	if (Distance < lookAtDistance)
	{
		lookAt();
	}

	
	if (Distance < attackRange)
	{
		//attack();
	}
	else if (Distance < chaseRange)
	{
		chase ();
	}
}

function lookAt ()
{
	//renderer.material.color = Color.yellow;
	var rotation = Quaternion.LookRotation(Target.position - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
}

function chase ()
{
	//renderer.material.color = Color.red;
	transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	//moveDirection = transform.forward;
	//moveDirection *= moveSpeed;
	anim.SetBool ("IsWalking", true);
	anim.SetBool ("IsHitting", false);
	//moveDirection.y -= gravity * Time.deltaTime;
	//controller.Move(moveDirection * Time.deltaTime);
}

function attack ()
{
	if (Time.time > attackRepeatTime)
	{
		playerHealth.ApplyDammage (TheDammage);
		Debug.Log("The Enemy Has Attacked");
		attackTime = Time.time + attackRepeatTime;
	}
}

function ApplyDammage ()
{
	chaseRange += 30;
	moveSpeed += 2;
	lookAtDistance += 40;
}