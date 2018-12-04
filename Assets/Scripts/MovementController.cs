using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float speed = 10f;
    public float jump = 10f;

    Animator animator;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate () {
        //value for moving forwards and backwards
        float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        //value for moving left and right
        float horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        //Using GetAxisRaw because normalized then properly works (GetAxis has small interpolation of like 200-300ms and simulates analog on gamepad)

        animator.speed = speed * 0.045f;

        bool isRunningForward = Input.GetKey(KeyCode.W);
        bool isRunningLeft = Input.GetKey(KeyCode.A);
        bool isRunningRight = Input.GetKey(KeyCode.D);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);

        animator.SetBool("IsJumping", isJumping);

        // Left 45 angle run
        bool isRunningLeftAngle = (isRunningLeft && isRunningForward) ? true : false;
        animator.SetBool("IsRunningLeftAngle", isRunningLeftAngle);
        // Right 45 angle run
        bool isRunningRightAngle = (isRunningRight && isRunningForward) ? true : false;
        animator.SetBool("IsRunningRightAngle", isRunningRightAngle);

        if (!isRunningLeftAngle && !isRunningRightAngle)
        {
            animator.SetBool("IsRunningForward", isRunningForward);
            animator.SetBool("IsRunningLeft", isRunningLeft);
            animator.SetBool("IsRunningRight", isRunningRight);
        }
        else
        {
            animator.SetBool("IsRunningForward", false);
            animator.SetBool("IsRunningLeft", false);
            animator.SetBool("IsRunningRight", false);
        }
        if (isJumping)
        {
            rb.AddForce(horizontal, 100f * Time.deltaTime, vertical, ForceMode.Impulse);
        }
        else
        {
            transform.Translate(new Vector3(horizontal, 0, vertical).normalized / 2, Space.Self);
        }
    }
}
