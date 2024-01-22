using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int towerPrice = 100; // ���� �� �����

    // �������������� ���������� ��� �����
    public bool isBuilt = false; // ������� ����������, ����� ���������, ��������� �� �����

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Update()
    {
        if (isBuilt) // ������ ���� ����� ���������, ��� ����� ��������
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
        if (target == null) // ���� ���� �� ����������, �� ��������
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

    // ���������� ����� � ��������� �������
    public void MoveTo(Vector3 newPosition)
    {
        if (!isBuilt) // ���� ����� ��� �� ���������, ��� ����� ������������
        {
            transform.position = newPosition;
        }
    }

    // ��������� ����� � ��������� ������� � ������ � �����������
    public void PlaceTower(Vector3 position)
    {
        transform.position = position;
        isBuilt = true;
    }
}
