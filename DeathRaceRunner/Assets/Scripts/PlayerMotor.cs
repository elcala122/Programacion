using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private float speed= 5.0f;
	private float verticalVelocity=0.0f;
	private float gravity=12.0f;
	private CharacterController controller;
	private Vector3 MoveVector;
	private float animationDuration=3.0f;
	private bool isDead=false;
	private float startTime;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isDead)
			return;

		if (Time.time-startTime < animationDuration) 
		{
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}

		MoveVector = Vector3.zero;

		if (controller.isGrounded) 
		{
		
			verticalVelocity = -0.5f;

		} else 
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}


		MoveVector.x = Input.GetAxisRaw ("Horizontal")*speed;
		if (Input.GetMouseButton (0)) 
		{
			if (Input.mousePosition.x > Screen.width / 2)
				MoveVector.x = speed;
			else
				MoveVector.x = -speed;
		}

		MoveVector.y = verticalVelocity;

		MoveVector.z = speed;

		controller.Move (MoveVector * Time.deltaTime);
	}

	public void SetSpeed(float modifier)
	{
		speed = 5.0f + modifier;

	}

	private void OnControllerColliderHit(ControllerColliderHit hit){
	
		if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy")
			Death ();
	
		}
	private void Death()
	{
		isDead = true;
		GetComponent<Score> ().OnDeath ();
	}
}
