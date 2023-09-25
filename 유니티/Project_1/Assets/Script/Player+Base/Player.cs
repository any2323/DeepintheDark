using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public bool DoubleJump = false;
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    int jumpCount = 0;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;
    Animator ani;

    Vector2 directionalInput;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        ani = GetComponent<Animator>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {
        CalculateVelocity();
        controller.Move(velocity * Time.deltaTime);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
            if(controller.collisions.below && DoubleJump)
            {
                jumpCount = 0;
            }
        }
    }

    public void SetDirectinalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpDown()
    {
        if (controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        if (DoubleJump)
        {
            if (!controller.collisions.below && (jumpCount <1))
            {
                ani.SetTrigger("Double Jump");
                velocity.y = jumpVelocity;
                jumpCount++;
            }
        }
    }

    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }
}