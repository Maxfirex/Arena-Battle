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
    void LateUpdate () {

        if (FeatureControl.FeatureEnabled(FeatureControl.Feature.EnemySpawn))
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        Dictionary<string, float> dictionary = EnemyControl.Spawn(enemy, amount, timer, spawnTimer);

        timer = dictionary["timer"];
        amount = System.Convert.ToInt32(dictionary["amount"]);
    }

}
