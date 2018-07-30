using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    [Tooltip("Thruster Speed Multiplier")][SerializeField] float thrusterSpeed = 100f;
    [Tooltip("Rotation Speed Multiplier")][SerializeField] float rotationSpeed = 10f;


    [Tooltip("Left Thruster")] [SerializeField] Transform leftThruster;
    [Tooltip("Right Thruster")] [SerializeField] Transform rightThruster;

    new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // Checks for thrusting
        {
            rigidbody.AddRelativeForce(Vector3.up * Time.timeScale * thrusterSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Checks for Counter-Clockwise rotation
        {
            //this.transform.Rotate(Vector3.forward * rotationSpeed * Time.timeScale);
            rigidbody.AddForceAtPosition(leftThruster.up * rotationSpeed * Time.timeScale, leftThruster.position);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Checks for Clockwise rotation
        {
            //this.transform.Rotate(-Vector3.forward * rotationSpeed * Time.timeScale);
            rigidbody.AddForceAtPosition(rightThruster.up* rotationSpeed * Time.timeScale, rightThruster.position);
        }
    }
}