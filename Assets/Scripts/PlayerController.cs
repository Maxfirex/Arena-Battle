using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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
        //Using GetAxisRaw because normalized then properly works (GetAxis has small interpolation of like 200-300ms and simulates analog on gamepad)
        if (PlayerControl.Animations(animator, speed)) {
            rb.AddForce(PlayerControl.Movement(speed, 100f * Time.deltaTime), ForceMode.Impulse);
        } else {
            transform.Translate(PlayerControl.Movement(speed) / 2, Space.Self);
        }
    }
}
