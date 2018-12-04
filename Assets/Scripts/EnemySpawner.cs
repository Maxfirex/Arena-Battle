using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public int amount;
    public float spawnTimer;

    private float timer;

    private void Start()
    {
        timer = spawnTimer;
    }

    // Update is called once per frame
    void Update () {

        if (amount > 0)
        {
            timer -= Time.deltaTime;

            SpawnAnEnemy();
        }

	}

    private void SpawnAnEnemy()
    {
        if (timer < 0)
        {
            enemy.transform.localScale = new Vector3(3f, 3f, 3f);

            //Rotation not done
            Instantiate(enemy, new Vector3(Random.Range(-220f, 220f), 0f, Random.Range(-220f, 220f)), Quaternion.identity);

            timer = spawnTimer;
            amount--;
        }
    }
}
