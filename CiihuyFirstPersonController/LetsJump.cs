using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsJump : MonoBehaviour
{
	
	public float jumpSpeed = 3f;
	public float jumpDelay = 2f;
	
	private bool canjump;
	private bool isjumping;
    private Rigidbody rb;
	private float countDown;

	public GameObject myCharacter;
	Animator charAnimator;
	
    // Start is called before the first frame update
    void Start()
    {
        canjump = true;
		rb = GetComponent<Rigidbody>();
		countDown = jumpDelay;

		charAnimator = myCharacter.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if(isjumping && countDown > 0)
			countDown -= Time.deltaTime;
		else{
			canjump = true;
			isjumping = false;
			countDown = jumpDelay;
		}
			
    }
	
	public void StartLetsJump(){
		if(canjump){
			canjump = false;
			isjumping = true;
			rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);

			charAnimator.SetTrigger("jump");
		}
	}
	
}
