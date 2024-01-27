using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movementInput;
    public float speed;
    public float rotationSpeed;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3.Normalize(movementInput);
    }

    private void FixedUpdate() 
    {
        DoMovement();
        RotateTowardsMovement();
    }

    void DoMovement()
    {
        rb.MovePosition(rb.position + movementInput * Time.fixedDeltaTime * speed);
    }

    void RotateTowardsMovement()
    {
        if (movementInput != Vector3.zero)
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(movementInput), 0.15F * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
