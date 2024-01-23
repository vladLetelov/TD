using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TowerType
{
    Type1,
    Type2
}

public class TowerScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float range = 5f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public TowerType towerType;
    public int towerPrice = 100; // ÷ена за башню

    // дополнительные переменные дл€ башни
    public bool isBuilt = false; // булева€ переменна€, чтобы проверить, построена ли башн€

    private CoinCounter coinCounter; // ссылка на скрипт отвечающий за монеты игрока

    void Start()
    {
        coinCounter = FindObjectOfType<CoinCounter>(); // Ќайдите объект CoinCounter в сцене
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Update()
    {
        if (isBuilt) // только если башн€ построена, она может стрел€ть
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
    }

    void Shoot(GameObject target)
    {
        if (target == null) // если цель не существует, не стрел€ть
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

    // перемещает башню в указанную позицию
    public void MoveTo(Vector3 newPosition)
    {
        if (!isBuilt) // если башн€ еще не построена, она может перемещатьс€
        {
            transform.position = newPosition;
        }
    }

    // размещает башню в указанную позицию и делает еЄ неподвижной
    public void PlaceTower(Vector3 position)
    {
        transform.position = position;
        isBuilt = true;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && isBuilt)
        {
            if (towerType == TowerType.Type1)
            {
                coinCounter.AddCoins(50);
            }
            else if (towerType == TowerType.Type2)
            {
                coinCounter.AddCoins(100);
            }
            Destroy(gameObject); // ”дал€ем объект башни
        }
    }

}
