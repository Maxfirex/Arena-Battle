using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyControl {

    /// <summary>
    /// Spawns one or more enemies every n seconds
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="amount"></param>
    /// <param name="spawnTime"></param>
    /// <param name="timer"></param>
    public static Dictionary<string, float> Spawn(GameObject enemy, int amount, float spawnTime, float timer)
    {
        if (amount > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                enemy.transform.localScale = new Vector3(3f, 3f, 3f);

                Object.Instantiate(enemy, new Vector3(Random.Range(-220f, 220f), 0f, Random.Range(-220f, 220f)), Quaternion.identity);

                timer = spawnTime;
                amount--;
            }
        }
        return new Dictionary<string, float>() {
            { "timer", timer },
            { "amount", amount }
        };
    }


}