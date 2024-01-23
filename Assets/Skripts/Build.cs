using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public TowerScript currentTower;
    public GameObject TowerPrefab;
    public bool isBuilding = false;
    public CoinCounter coinCounter; // Добавьте переменную coinCounter

    void Start()
    {
        coinCounter = FindObjectOfType<CoinCounter>(); // Найдите объект CoinCounter в сцене
    }

    public void OnButtonClick()
    {
        if (!isBuilding)
        {
            Vector3 mousePosition = GetMousePosition();
            currentTower = Instantiate(TowerPrefab, mousePosition, Quaternion.identity).GetComponent<TowerScript>();
            currentTower.MoveTo(mousePosition);
            isBuilding = true;
        }
        else
        {
            isBuilding = false;
            Destroy(currentTower.gameObject);
            currentTower = null;
        }
    }

    void Update()
    {
        if (isBuilding)
        {
            Vector3 mousePosition = GetMousePosition();
            currentTower.MoveTo(mousePosition);
        }

        if (Input.GetMouseButtonDown(0) && isBuilding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Spot"))
                {
                    currentTower.PlaceTower(hit.transform.position);
                    isBuilding = false;
                    currentTower = null;

                    // Используйте переменную coinCounter для изменения количества монет
                    if (currentTower.towerType == TowerType.Type1)
                    {
                        coinCounter.AddCoins(50);
                    }
                    else if (currentTower.towerType == TowerType.Type2)
                    {
                        coinCounter.AddCoins(100);
                    }
                }
                else
                {
                    Destroy(currentTower.gameObject);
                    currentTower = null;
                    isBuilding = false;
                }
            }
            else
            {
                Destroy(currentTower.gameObject);
                currentTower = null;
                isBuilding = false;
            }
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector2 screenPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));

        return worldPosition;
    }
}

