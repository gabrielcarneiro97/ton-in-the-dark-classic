using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movementInput;
    public float speed;
    public float rotationSpeed;
    public Animator animator, lanternAnimator;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        if(rb.velocity.magnitude > 0.5f)
        {
            animator.SetBool("isWalking", true);
            lanternAnimator.SetBool("isWalking", true);
            animator.speed = rb.velocity.magnitude / 6;
        }
        else
        {
            animator.speed = 1;
            animator.SetBool("isWalking", false);
            lanternAnimator.SetBool("isWalking", false);
        }
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
        rb.AddForce(movementInput * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    void RotateTowardsMovement()
    {
        if (movementInput != Vector3.zero)
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(movementInput), 0.15F * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
