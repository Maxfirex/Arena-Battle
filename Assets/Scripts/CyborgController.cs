using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgController : MonoBehaviour {


    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        // Forward run
        bool isRunningForward = Input.GetKey("w");
        

        // Left 90 angle run
        bool isRunningLeft = Input.GetKey("a");
        

        // Right 90 angle run
        bool isRunningRight = Input.GetKey("d");
        
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
    }
}
