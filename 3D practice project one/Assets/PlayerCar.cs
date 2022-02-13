using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    // first time coding in 3d : O
    public bool Acceleration;

    float HorizontalInput = 0;
    float VerticalInput = 0;

    public bool usePhysics;
    public float forwardVelocity;
    public float sideVelocity;

    float PhysicsHorizontalInput = 0;
    float PhysicsVerticalInput = 0;

    Vector3 transformPos;
    Rigidbody rigidBody;

    public float speed = 700;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!usePhysics)
        {
            if (!Acceleration)
            {
                HorizontalInput = Input.GetAxis("Horizontal");
                VerticalInput = Input.GetAxis("Vertical");
            }
            else
            {
                HorizontalInput = Input.GetAxisRaw("Horizontal");
                VerticalInput = Input.GetAxisRaw("Vertical");
            }

            Vector3 transformPos = transform.position;
            transformPos.x += speed * HorizontalInput * Time.deltaTime;
            transformPos.z += speed * VerticalInput * Time.deltaTime;
            transform.position = transformPos;
        }
    }

    private void FixedUpdate()
    {
        if (usePhysics)
        {
            if (!Acceleration)
            {
                PhysicsHorizontalInput = Input.GetAxis("Horizontal");
                PhysicsVerticalInput = Input.GetAxis("Vertical");
            }
            else
            {
                PhysicsHorizontalInput = Input.GetAxisRaw("Horizontal");
                PhysicsVerticalInput = Input.GetAxisRaw("Vertical");
            }

            rigidBody.velocity = new Vector3(sideVelocity * PhysicsHorizontalInput * Time.deltaTime, rigidBody.velocity.y, forwardVelocity * PhysicsVerticalInput * Time.deltaTime);
        }
    }
}
