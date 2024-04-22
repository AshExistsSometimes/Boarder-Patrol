using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float RotationSpeed = 150.0f;
	public float Gravity = 9.81f;
	[Header("Movement variables")]

	public float ForwardForce = 10.0f; // base vector, no one like its
	public float MaxVelocity = 6f; // total allowed velocity the player can reach.
	public float Accel = 2f; // how fast it takes to reach max velocity.
	public float SlowRate = 0.5f; // how fast to slow the player.

	public Vector3 velocity = Vector3.zero;
	public Rigidbody rb;

	private Vector3 normal;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		print(transform.forward);

		SlopeDetection();

		// funny
		HandleMovement();

		HandleRotation();
	}

	private void HandleRotation()
	{
		if (Input.GetKey(KeyCode.A))
		{
			Debug.Log("A Key Pressed");
			transform.Rotate(Vector3.down * RotationSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			Debug.Log("D Key Pressed");
			transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
		}
	}

	private void HandleMovement()
	{
		// the velocity to apply to the player.
		// (transform.forward * ForwardForce)  this is the target vetor. aka the direction we want to go.
		// -transform.forward.y this is used to reduce the speed when the player is not aligned with the slope.
		// Time.deltaTime  sync with the frame rate and give more control with the speed and accel.
		// Accel acceleration rate for the player.
		velocity += ((transform.forward * ForwardForce) * -transform.forward.y) * Time.deltaTime * Accel;

		// counter force.
		// slows down the player over a given time.
		velocity -= velocity * Time.deltaTime * SlowRate;

		// checks to see if the player is faster than the max velocity allowed.
		if (velocity.magnitude > MaxVelocity)
		{
			// if so, their velocity is capped at max.
			velocity = velocity.normalized * MaxVelocity;
		}

		// we project the velocity on the slope aka place.
		velocity = Vector3.ProjectOnPlane(velocity, normal);

		// we set the rigidbody's velocity with velocity.
		rb.velocity = velocity;
	}

	public void SlopeDetection()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.down, out hit))
		{
			normal = hit.normal;
		}
	}
}
