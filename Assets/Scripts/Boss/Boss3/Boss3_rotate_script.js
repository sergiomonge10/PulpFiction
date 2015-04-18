 #pragma strict
 
 var target : Transform;
 var turnSpeed : float = 5.0f;
 var speed : float = 100f;
 
 private var _dir : Vector3;
 
 
 function Start () {
  target = GameObject.FindWithTag("Player").transform;
 }
 
 function Update () {
     if(target){
         _dir = target.position - rigidbody.position;
         _dir.Normalize();
         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_dir), turnSpeed * Time.deltaTime);
     }
 }
 
 function OnCollisionEnter(collision : Collision){
 		Debug.Log(collision.transform.tag);
 }
 
 function FixedUpdate() {
     rigidbody.AddForce(_dir * speed);
 }