using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour
{
	private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
	private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this
	Animator anim;


	void onStart(){
		anim = this.GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update()
	{
	/**	if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
		}**/
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data

			//stream.SendNext(transform.position);
			//stream.SendNext(transform.rotation);
			stream.SendNext(anim.GetBool("IsWalking"));
			stream.SendNext(anim.GetBool("IsRunning"));
			stream.SendNext(anim.GetBool("IsShooting"));
			stream.SendNext(anim.GetBool("Die"));
			stream.SendNext(anim.GetBool("IsRecharging"));

		}
		else
		{
			// Network player, receive data
			//this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			//this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			anim.SetBool("IsWalking", (bool)stream.ReceiveNext());
			anim.SetBool("IsRunning", (bool)stream.ReceiveNext());
			anim.SetBool("IsShooting", (bool)stream.ReceiveNext());
			anim.SetBool("Die", (bool)stream.ReceiveNext());
			anim.SetBool("IsRecharging", (bool)stream.ReceiveNext());

			
			//myThirdPersonController myC = GetComponent<myThirdPersonController>();
			//myC._characterState = (CharacterState)stream.ReceiveNext();
		}
	}
}