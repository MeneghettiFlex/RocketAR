using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [Tooltip("Thruster Speed Multiplier")] [SerializeField] float thrusterSpeed = 100f;
    [Tooltip("Rotation Speed Multiplier")] [SerializeField] float rotationSpeed = 10f;

    [Tooltip("Left Thruster")] [SerializeField] Transform leftThruster;
    [Tooltip("Right Thruster")] [SerializeField] Transform rightThruster;

    new Rigidbody rigidbody;

    enum RocketState { Landed, AlmostLanded, InFlight, Crashed }
    [SerializeField] RocketState currentState;

    bool isThrusting = false;
    bool isRotatingClock = false;
    bool isRotatingCounterClock = false;

    private void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();

        StartCoroutine(Thrust());
        StartCoroutine(RotateClock());
        StartCoroutine(RotateCounterClock());
    }

#if UNITY_ANDROID || UNITY_IOS

#else
    void FixedUpdate()
    {
        CheckInputs();
    }
#endif

    private void CheckInputs()
    {
        if (GameManager.instance.GetCurrentState() != GameManager.GameState.GamePlay) // Ensure that the player only control the rocket when the game is playing.
        {
            return;
        }

        isThrusting = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // Checks for thrusting
        //{
        //Thrust()
        //}

        isRotatingCounterClock = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);

        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Checks for Counter-Clockwise rotation
        //{
        //    RotateCounterClock();
        //}

        isRotatingClock = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        //else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Checks for Clockwise rotation
        //{
        //    RotateClock();
        //}
    }

    IEnumerator Thrust()
    {
        while (true)
        {
            if (isThrusting)
            {
                rigidbody.AddRelativeForce(Vector3.up * Time.timeScale * thrusterSpeed);
            }
            yield return null;
        }
    }

    IEnumerator RotateCounterClock()
    {
        while (true)
        {
            if (isRotatingCounterClock)
            {
                rigidbody.AddForceAtPosition(leftThruster.up * rotationSpeed * Time.timeScale, leftThruster.position);
            }
            yield return null;
        }
    }

    IEnumerator RotateClock()
    {
        while (true)
        {
            if (isRotatingClock)
            {
                rigidbody.AddForceAtPosition(rightThruster.up * rotationSpeed * Time.timeScale, rightThruster.position);
            }
            yield return null;
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
        if (collision.gameObject.CompareTag(tag_Obstacle))
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