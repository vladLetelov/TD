using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemy = 5;

    public float timeSpawn = 2f;
    private float timer;

    public float distance = 3;

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            if (transform.childCount < maxEnemy)
            {
                GameObject spawnedEnemy = Instantiate(enemyPrefab, new Vector3(-110, 10, 90), Quaternion.identity, transform);
                spawnedEnemy.transform.rotation = Quaternion.Euler(0, 180, 0); // Rotate the enemy object
            }
        }
    }
}
