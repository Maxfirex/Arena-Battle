using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerControl {

	public static Vector3 Movement(float speed, float jump = 0f)
    {
        //value for moving forwards and backwards
        float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        //value for moving left and right
        float horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        return new Vector3(horizontal, jump, vertical).normalized;
    }

    public static bool Animations(Animator animator, float speed)
    {
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

        return isJumping;
    }
}