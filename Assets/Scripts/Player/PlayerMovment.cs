using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    
	public CharacterController controller;
	public float speed = 12.0f;
	
	public float gravity = -9.81f;
	
	Vector3 velocity;
	
	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	
	bool isGrounded;
	int jump = 0;
	
	public float jumpHeight = 5f;

    void Update()
    {
    	isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    
     	float x = Input.GetAxis("Horizontal");
     	float y = Input.GetAxis("Vertical");
     	
     	Vector3 move = transform.right * x +transform.forward * y;
     	
     	controller.Move(move*speed*Time.deltaTime);
     	
     	if(isGrounded)
     	{
     		jump = 0;
     	}
     	
     	if(Input.GetKeyDown("space") && isGrounded && jump != 2)
     	{
     		velocity.y += jumpHeight;
     		jump += 1;
     	}
     	
     	if (isGrounded && velocity.y < 0)
     	{
     		velocity.y = -2f;
     	}
     	
     	velocity.y += gravity * Time.deltaTime;
     	
     	controller.Move(velocity * Time.deltaTime);
    }
}
