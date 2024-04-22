using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float RotationSpeed = 150.0f;
	public float ForwardForce = 10.0f;
	public float Gravity = 9.81f;
	public float MaxVelocity = 6f;


    public Rigidbody rb;

	private Vector3 normal;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		SlopeDetection();


		rb.AddForce(Vector3.down * Gravity);
		rb.AddForce(Vector3.ProjectOnPlane(transform.forward * ForwardForce, normal));

		if (rb.velocity.y < -Gravity)// Gravity (y) Cap
		{
			Vector3 _ = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

			Vector3 _v2 = new Vector2(rb.velocity.x, rb.velocity.z);

			_ = _.normalized * -Gravity;

			rb.velocity = new Vector3(_v2.x, _.y, _v2.z);
		}

        if (rb.velocity.x < MaxVelocity || rb.velocity.z < MaxVelocity)// x/z Velocity Cap
        {
            Vector3 _v3 = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

            Vector3 _v4 = new Vector2(rb.velocity.x, rb.velocity.z);

            _v3 = _v3.normalized * MaxVelocity;

            rb.velocity = new Vector3(_v3.x, _v4.y, _v3.z);
        }


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

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;  //Forward
		Vector3 direction = transform.forward * 7;// Gizmo Points Forwards
		Gizmos.DrawRay(transform.position, direction);
	}

	public void SlopeDetection()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.down, out hit))
		{
			normal = hit.normal;


			Debug.DrawRay(transform.position, Vector3.down);

			Debug.DrawRay(hit.point, hit.normal, Color.blue);
		}
	}
}
