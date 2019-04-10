﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRidgidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public new GameObject gameObject;

    // Use this for initialization
    void Start()
    {
        myRidgidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            //camera view test
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
            theGun.isFiring = true;
            

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("test2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Restart()
    {
       
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("test2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate() { 
        myRidgidbody.velocity = moveVelocity;
    }
}

