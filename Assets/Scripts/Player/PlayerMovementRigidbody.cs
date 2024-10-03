using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementRigidbody : MonoBehaviour, IControllable
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private float acceleration = 0.1f;

    private bool isGrounded;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyVerticalMoving()
    {
        throw new System.NotImplementedException();
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector2 inputDirection)
    {
        MovementLogic(inputDirection);
    }

    private void MovementLogic(Vector2 inputDirection)
    {
        float moveHorizontal = 0;

        float moveVertical = 0;


        //Vertical/Forward movement

        if (inputDirection.y == 0)
            moveVertical = 0;

        else if (inputDirection.y > 0)

            if (rb.velocity.z <= speed)
                moveVertical = 1;
            else
                moveVertical = 0;

        else if (inputDirection.y < 0)

            if (rb.velocity.z >= speed * -1)
                moveVertical = -1;
            else
                moveVertical = 0;

        else
            moveVertical = 0;


        //Horizontal/Side movement

        if (inputDirection.x == 0)
            moveHorizontal = 0;

        else if (inputDirection.x > 0)

            if (rb.velocity.x <= speed)
                moveHorizontal = 1;
            else
                moveHorizontal = 0;

        else if (inputDirection.x < 0)

            if (rb.velocity.x >= speed * -1)
                moveHorizontal = -1;
            else
                moveHorizontal = 0;

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        rb.velocity = rb.velocity - new Vector3(rb.velocity.x * acceleration, 0, rb.velocity.z * acceleration);

        //transform.LookAt(transform.position + new Vector3(rb.velocity.x, 0, rb.velocity.z));
    }
}
