using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jumpForce = 300f;
	public float playerSpeed = 10f;

	private Animator charAnimator;
	private Rigidbody rb;
	private float vertical = 0f;
	private float horizontal = 0f;
	// Use this for initialization
	void Start () {
		charAnimator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		vertical = Input.GetAxis ("Vertical");
		horizontal = Input.GetAxis ("Horizontal");
		Vector3 moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;
		rb.transform.Translate (moveDirection * playerSpeed * Time.deltaTime);
		Quaternion rot = Quaternion.LookRotation (moveDirection);
		transform.rotation = rot;

		charAnimator.SetFloat ("horizontal", moveDirection.z);
		charAnimator.SetFloat ("vertical", moveDirection.x);

		if (Input.GetButtonDown ("Jump")) {
			rb.velocity = new Vector3 (0, jumpForce * Time.deltaTime, 0);
			charAnimator.SetTrigger ("Jump");
		}
	}
}