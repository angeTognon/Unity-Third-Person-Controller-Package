using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRotationTouchpad : MonoBehaviour
{

    public Transform RotatableH;
    public Transform RotatableV;
    public float RotationSpeed = .1f;
    public bool InvertedV = true;
    public bool ClampedV = true;

    Vector2 currentMousePosition;
    Vector2 mouseDeltaPosition;
    Vector2 lastMousePosition;
	
	public static MyRotationTouchpad mrt;
	[HideInInspector]
	public bool istouchpadactive;

    private void Start()
    {
		mrt = this;
        ResetMousePosition();
    }

    public void ResetMousePosition()
    {
		if(Input.touchCount == 1){
			if(!MyJoystick.js.started){
				currentMousePosition = Input.GetTouch(0).position;
			}
		}else if(Input.touchCount == 2){
			
			if(MyJoystick.js.started){
				currentMousePosition = Input.GetTouch(1).position;
			}else{
				currentMousePosition = Input.GetTouch(0).position;
			}
		}else{
			currentMousePosition = Input.mousePosition;
		}
		
        lastMousePosition = currentMousePosition;
        mouseDeltaPosition = currentMousePosition - lastMousePosition;
    }

    void LateUpdate()
    {
        if (istouchpadactive)
        {
            if(Input.touchCount == 1){
				if(!MyJoystick.js.started){
					currentMousePosition = Input.GetTouch(0).position;
				}
			}else if(Input.touchCount == 2){
				
				if(MyJoystick.js.started){
					currentMousePosition = Input.GetTouch(1).position;
				}else{
					currentMousePosition = Input.GetTouch(0).position;
				}
			}else{
				currentMousePosition = Input.mousePosition;
			}
			
			
            mouseDeltaPosition = currentMousePosition - lastMousePosition;

            if (RotatableH != null)
                RotatableH.transform.Rotate(0f, mouseDeltaPosition.x * RotationSpeed, 0f);
            if (RotatableV != null)
            {
				
				
                if (InvertedV){
					RotatableV.transform.Rotate(Mathf.Clamp(mouseDeltaPosition.y * (RotationSpeed * -1), -3, 3), 0f, 0f);
				}
					
				else{
					RotatableV.transform.Rotate(Mathf.Clamp(mouseDeltaPosition.y * RotationSpeed, -3, 3), 0f, 0f);
				}

				
				if(ClampedV){
					float limitedXRot = RotatableV.transform.localEulerAngles.x;
					if(limitedXRot > 45f && limitedXRot < 320f){
						if(limitedXRot < 180f)
							limitedXRot = 45f;
						else
							limitedXRot = 320f;
						
					}					
					RotatableV.transform.localEulerAngles = new Vector3(limitedXRot, RotatableV.transform.localEulerAngles.y, RotatableV.transform.localEulerAngles.z);
				}
				
            }

            lastMousePosition = currentMousePosition;


        }


    }

    public void ActivateTouchpad()
    {
        ResetMousePosition();
        istouchpadactive = true;
    }

    public void DeactivateTouchpad()
    {
        istouchpadactive = false;
    }
}