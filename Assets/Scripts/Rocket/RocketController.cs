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

    enum RocketState { Landed, AlmostLanded, InFlight, Crashed }
    [SerializeField] RocketState currentState;

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
            rigidbody.AddForceAtPosition(leftThruster.up * rotationSpeed * Time.timeScale, leftThruster.position);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Checks for Clockwise rotation
        {
            rigidbody.AddForceAtPosition(rightThruster.up* rotationSpeed * Time.timeScale, rightThruster.position);
        }
    }

    const string tag_LandingPad = "LandingPad";
    const string tag_LaunchPad = "LaunchPad";
    const string tag_RefuelingStation = "RefuelingStation";
    const string tag_Obstacle = "Obstacle";
    const string tag_Ground = "Ground";
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.CompareTag(tag_Obstacle))
        {
            // Take Damage
        }
        else if (collision.gameObject.CompareTag(tag_Ground))
        {
            // Take Damage
        }
        else if (collision.gameObject.CompareTag(tag_RefuelingStation))
        {
            // Start landing procedure and Refuel
        }
        else if (collision.gameObject.CompareTag(tag_LaunchPad))
        {
            // Start landing procedure
        }
        else if (collision.gameObject.CompareTag(tag_LandingPad))
        {
            // Start landing procedure and win
        }
    }
}