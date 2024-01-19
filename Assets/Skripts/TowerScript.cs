using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float range = 5f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= range && distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        if (closestEnemy != null && fireCountdown <= 0f)
        {
            Shoot(closestEnemy);
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot(GameObject target)
    {
        if (target == null) // если цель не существует, не стрелять
        {
            return;
        }

        GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
