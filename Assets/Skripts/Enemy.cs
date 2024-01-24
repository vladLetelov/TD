using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public int currentWaypointIndex = 0;
    public int damage = 10; // ����� ���� ��� ��������� �����
    private CoinCounter counter; // �������� ������ �� CoinCounter
    private Health health; // �������� ������ �� Health ������ BuildingScript
    public int coinReward = 5;

    private void Start()
    {
        // �����������, ��� ��� ������ TextMeshPro ����� ��� "CoinText"
        GameObject textMeshObject = GameObject.FindWithTag("CoinText");
        if (textMeshObject != null)
        {
            counter = textMeshObject.GetComponent<CoinCounter>();
        }
        else
        {
            Debug.LogWarning("�� ������� ����� ������ � ����� 'CoinText'.");
        }

        // ������ ������ Health �� �����
        GameObject healthObject = GameObject.FindWithTag("Base");
        if (healthObject != null)
        {
            health = healthObject.GetComponent<Health>();
        }
        else
        {
            Debug.LogWarning("�� ������� ����� ������ � ����� 'Base'.");
        }
    }

    private void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;
            transform.position = newPosition;

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex == waypoints.Length)
                {
                    if (counter != null)
                    {
                        counter.AddCoins(coinReward); // ����������� ���������� ����� ����� ������������ �������
                    }

                    if (health != null)
                    {
                        health.TakeHit(damage); // ��������� ��������
                    }

                    Destroy(gameObject);
                }
            }
        }
    }
}
