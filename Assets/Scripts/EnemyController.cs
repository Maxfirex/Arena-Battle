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
    public float rotationTimer = 5;

    private float innerAggroTimer;
    private float innerRotationTimer;
    private bool aggroed = false;
    private bool rotate = false;

    private float cnt = 5f;
    private int cnter = 0;

	// Use this for initialization
	void Start () {
        // Juicy player transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        innerAggroTimer = aggroTimer;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        // Teaching enemy how to move
        EnemyMovement();
	}

    void EnemyMovement()
    {
        // Distance in float which we can measure
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Enemy aggroed
        if (distance <= aggroRange) {
            // Enemy has been aggroed
            aggroed = true; 
        }
        // If out of enemy aggro range, start countdown before stopping the chase
        if (aggroed && distance > aggroRange)
        {
            innerAggroTimer -= Time.deltaTime;

            // Countdown finished, chasing stopped
            if (innerAggroTimer <= 0f)
            {
                aggroed = false;
                innerAggroTimer = aggroTimer;
            }
        }

        // As long as distance is bigger than shooting range and player is in aggro radius, we move
        if (distance > shootingDistance && aggroed)
        {
            // Rotate towards a player
            transform.LookAt(player.transform.position);
            // Moving an enemy towards the player
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        // When not aggroed, start wandering around
        if (!aggroed)
        {
            EnemyWander();
        }
    }
    void EnemyWander()
    {
        innerRotationTimer -= Time.deltaTime;

        // Timer befpre rotating an enemy to a new direction
        if (innerRotationTimer <= 0f) {
            rotate = true;
            innerRotationTimer = rotationTimer;
        } else {
            rotate = false;
        }

        Quaternion rotationTo = transform.rotation;

        // Rotate an enemy to a new direction
        if (rotate)
        {
            rotationTo = Quaternion.Euler(new Vector3(0f, Random.Range(-180f, 180f), 0f));
            innerRotationTimer = rotationTimer;
        }
        // Move the enemy
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationTo, rotationSpeed);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
