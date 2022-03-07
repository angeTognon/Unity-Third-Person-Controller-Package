using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MyPlayer : MonoBehaviour {
	public float speed, turnSpeed;
	private Rigidbody rb;
	public MyJoystick joystick;
	public float yy;

	public GameObject myCharacter;
	Animator charAnimator;
	
	void Start () {
		rb = GetComponent<Rigidbody> ();
		charAnimator = myCharacter.GetComponent<Animator>();
	}
	
	void FixedUpdate () {
		
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * (speed * joystick.Vertical());
        this.gameObject.transform.position += this.gameObject.transform.right * Time.deltaTime * (turnSpeed* joystick.Horizontal());

		// walking forward
		if(joystick.Vertical() > 0.2) 
		{
			DisableAllMovementAnim();
			charAnimator.SetBool("isWalking", true);

		}else if(joystick.Vertical() == 0)
		{
			charAnimator.SetBool("isWalking", false);
		}
		// walking backward

		if(joystick.Vertical() < -0.2)
		{
			DisableAllMovementAnim();
			charAnimator.SetBool("isWalkingBackward", true);
		}else if(joystick.Vertical() == 0)
		{
			charAnimator.SetBool("isWalkingBackward", false);
		}

		if(joystick.Horizontal() > 0.5)
		{
			transform.Rotate(0,yy*Time.deltaTime,0);
		}else if(joystick.Horizontal() < -0.5)
		{
			transform.Rotate(0,-yy*Time.deltaTime,0);
		}


		// strafe Right
		/*if(joystick.Horizontal() > 0.5)
		{
			DisableAllMovementAnim();
			charAnimator.SetBool("StrafeRight", true);
		}else if(joystick.Horizontal() == 0)
		{
			charAnimator.SetBool("StrafeRight", false);
		}
		// starfe Left

		if(joystick.Horizontal() < -0.5)
		{
			DisableAllMovementAnim();
			charAnimator.SetBool("StrafeLeft", true);
		}else if(joystick.Vertical() == 0)
		{
			charAnimator.SetBool("StrafeLeft", false);
		}*/


		// checking

		if ((joystick.Vertical() > 0) && (charAnimator.GetBool ("s2") == true))
			{
				charAnimator.SetBool("s2", false);
				charAnimator.SetBool("pitoW", true);
			}
		else{
			charAnimator.SetBool("pitoW", false);
		}
    }
	public void DisableAllMovementAnim()
	{
			charAnimator.SetBool("isWalkingBackward", false);
			charAnimator.SetBool("isWalking", false);
			//charAnimator.SetBool("StrafeLeft", false);
			//charAnimator.SetBool("StrafeRight", false);
	}
}