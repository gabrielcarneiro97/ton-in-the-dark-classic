using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        if (rb.velocity.magnitude > 0.5f)
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
        if (CheckIfCanWalkForward())
        {
            rb.AddForce(movementInput * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void RotateTowardsMovement()
    {
        if (movementInput != Vector3.zero)
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(movementInput), 0.15F * rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + transform.forward * 0.3f + Vector3.up, Vector3.down * 3);
    }
    bool CheckIfCanWalkForward()
    {
        RaycastHit hit;
        // Debug.Log("Raycast");
        if (Physics.Raycast(transform.position + transform.forward * 0.6f + Vector3.up * 1.2f, Vector3.down, out hit, 20))
        {
            // Debug.Log("Inside Raycast");
            if (hit.collider.tag == "Floor")
            {
                // Debug.LogWarning("Pode anda");
                return true;
            }
            else
            {
                // Debug.LogWarning("Nao pode anda");
            }

        }
        else
        {
            // Debug.LogWarning("Nao achou alvo");
        }
        return false;
    }
}
