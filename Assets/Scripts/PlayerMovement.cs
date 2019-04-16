using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRidgidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

	// Use this for initialization
	void Start () {
        myRidgidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

	}
     
    void FixedUpdate ()
    {
        myRidgidbody.velocity = moveVelocity;
    }
}
