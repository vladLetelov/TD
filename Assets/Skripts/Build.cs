using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public TowerScript currentTower;
    public GameObject TowerPrefab;
    public List<GameObject> buildSpots;
    public bool isBuilding = false; // Сделано общедоступным
    private bool hasBuiltTower = false;

    public void OnButtonClick()
    {
        if (hasBuiltTower) // Если уже построена башня
        {
            Destroy(currentTower.gameObject); // Удаляем текущую башню
            currentTower = null; // Обнуляем ссылку на башню
            hasBuiltTower = false; // Сбрасываем флаг построенной башни
        }
        else
        {
            if (!isBuilding) // Если не находимся в режиме строительства
            {
                isBuilding = true;
                Vector3 mousePosition = GetMousePosition();
                currentTower = Instantiate(TowerPrefab, mousePosition, Quaternion.identity).GetComponent<TowerScript>();
                currentTower.MoveTo(mousePosition);
            }
            else // Если уже находимся в режиме строительства
            {
                isBuilding = false; // Выключаем режим строительства
            }
        }
    }

    void Update()
    {
        if (isBuilding)
        {
            Vector3 mousePosition = GetMousePosition();
            currentTower.MoveTo(mousePosition);
        }

        if (Input.GetMouseButtonDown(0) && isBuilding) // Если нажата левая кнопка мыши и находимся в режиме строительства
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // Если луч пересекает что-то
            {
                if (buildSpots.Contains(hit.collider.gameObject)) // Если это объект под башню
                {
                    currentTower.PlaceTower(hit.transform.position);
                    hasBuiltTower = true; // Устанавливаем флаг построенной башни в true
                }
            }
            else // Если луч не пересекает объект под башню
            {
                Destroy(currentTower.gameObject); // Удаляем текущую башню
                currentTower = null; // Обнуляем ссылку на башню
            }
            isBuilding = false; // Сбрасываем флаг режима строительства в false после каждого нажатия мыши
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector2 screenPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));

        return worldPosition;
    }
}

