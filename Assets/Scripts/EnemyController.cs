using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Transform player;
    public float shootingDistance = 25f;
    public float moveSpeed = 3f;
    public float aggroRange = 40f;
    public float aggroTimer = 5f;
    public float rotationSpeed = 1.25f;
    public float rotationTimer = 5f;

    private float timer;
    private float rotTimer;
    private bool aggroed = false;
    private bool rotate = false;

	// Use this for initialization
	void Start () {
        // Juicy player transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rotTimer = rotationTimer;
	}
	
	// Update is called once per frame
	void Update () {
        // Teaching enemy how to move
        EnemyMovement();
	}

    void EnemyMovement()
    {
        // Distance in float which we can measure
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // If player in aggro range, start running towards him
        if (distance <= aggroRange)
        {
            // Enemy has been aggroed
            aggroed = true;
            // Invoking aggro timer method
            InvokeRepeating("AggroTimerCountdown", aggroTimer, 1f);
        }
            // As long as distance is bigger than shooting range and player is in aggro radius, we move
        if (distance > shootingDistance && aggroed)
        {
            // Rotate towards a player
            transform.LookAt(player.position);
            // Moving an enemy towards the player
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            EnemyWander();
        }
    }
    // Aggro timer
    void AggroTimerCountdown()
    {
        // If aggro timer is over, reset aggro
        if (timer == 0)
        {
            // Reset aggro
            aggroed = false;
            // Stop aggro timer
            CancelInvoke("AggroTimerCountdown");
        } else
        {
            // Aggro timer is ticking
            timer--;
        }

    }

    void EnemyRotationCountdown()
    {
        if (rotTimer == 0)
        {
            rotate = true;
            CancelInvoke("EnemyRotationCountdown");
        } else
        {
            rotate = false;
            rotTimer--;
        }
    }

    void EnemyWander()
    {
        InvokeRepeating("EnemyRotationCountdown", rotTimer, 1f);

        Quaternion rotationTo = transform.rotation;

        if (rotate)
        {
            rotationTo = Quaternion.Euler(new Vector3(0f, Random.Range(-180f, 180f), 0f));
            rotTimer = rotationTimer;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationTo, Time.deltaTime * rotationSpeed);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
