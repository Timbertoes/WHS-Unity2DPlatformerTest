﻿/*
 
 Basic Unity Character Controller Use
 
 - Adapted to C# from Unity Docs at
   http://docs.unity3d.com/Documentation/ScriptReference/CharacterController.Move.html
 
 
*/

using UnityEngine;
using System.Collections;

public class Hero:MonoBehaviour
{
	
	public float speed     = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity   = 20.0f;
	
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}
	
	void Update ()
	{
		
		if (controller.isGrounded)
		{
			// We are grounded, so recalculate
			// move direction directly from axes
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			if (Input.GetButton ("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
			
		}else{
			//Airborne!
			moveDirection.x = Input.GetAxis("Horizontal");
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection.x *= speed;
		}
		
		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;
		
		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);
	
	}
}
