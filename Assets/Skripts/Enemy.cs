using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;

    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Получаем текущую позицию пути
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;

            // Вычисляем направление движения
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            // Вычисляем новую позицию на основе текущей позиции, направления движения и скорости
            Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;

            // Перемещаем объект на новую позицию
            transform.position = newPosition;

            // Проверяем, достигли ли мы текущей позиции пути
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Если достигли, переходим к следующей позиции пути
                currentWaypointIndex++;

                // Проверяем, является ли текущая позиция последней позицией
                if (currentWaypointIndex == waypoints.Length)
                {
                    // Если да, то удаляем объект
                    Destroy(gameObject);
                }
            }
        }
    }
}
