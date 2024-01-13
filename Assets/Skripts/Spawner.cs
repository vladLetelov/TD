using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    private float randomX;
    Vector2 whereToSpawn;
    public float spawnDelay;
    float nextSpawn = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnDelay;
            randomX = Random.Range(-8, 8);
            whereToSpawn = new Vector2(220, 140); // Враги будут спавниться в точке (0, 0)
            GameObject Enemy = Instantiate(obj, whereToSpawn, Quaternion.identity);
            Destroy(Enemy, 1.7f);
        }
    }
}
