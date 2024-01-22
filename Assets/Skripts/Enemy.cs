using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public int currentWaypointIndex = 0;
    private CoinCounter counter; // Добавьте ссылку на CoinCounter

    private void Start()
    {
        // Предположим, что ваш объект TextMeshPro имеет тег "CoinText"
        GameObject textMeshObject = GameObject.FindWithTag("CoinText");
        if (textMeshObject != null)
        {
            counter = textMeshObject.GetComponent<CoinCounter>();
        }
        else
        {
            Debug.LogWarning("Не удалось найти объект с тегом 'CoinText'.");
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
                        counter.AddCoins(5); // Увеличиваем количество монет перед уничтожением объекта
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
