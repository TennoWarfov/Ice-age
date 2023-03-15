using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammothController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform tr;
    [SerializeField] private Animator animator;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationTorque;
    [SerializeField] private float maxAngularVelocity;

    public Vector2 Input { get; set; }

    private void FixedUpdate()
    {
        Move();
        Rotations();

        animator.SetBool("Moving", Input != Vector2.zero);
        animator.SetFloat("MovingSpeed", 0.1f);
    }

    private void Move()
    {
        var input = new Vector3(0, 0, Input.y);
        rb.AddRelativeForce(input * speed, ForceMode.VelocityChange);
    }

    private void Rotations()
    {
        var input = new Vector3(0, Input.x, 0);

        if (input == Vector3.zero)
        {
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            rb.AddTorque(input * rotationTorque);
        }

        ClampAngularVelocity();
    }

    private void ClampAngularVelocity()
    {
        if(rb.angularVelocity.magnitude > maxAngularVelocity)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * maxAngularVelocity;
        }
    }
}
