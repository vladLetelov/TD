using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    public Build buildScript;
    public GameObject TowerPrefab;
    public bool isButtonClicked = false;
    public bool isBuilding = false; // ѕеременна€ дл€ отслеживани€ движени€ башни.

    private void OnMouseDown()
    {
        if (isButtonClicked)
        {
            GameObject tower = Instantiate(TowerPrefab, transform.position, Quaternion.identity);
            TowerScript towerScript = tower.GetComponent<TowerScript>();
            if (towerScript != null)
            {
                towerScript.isBuilt = true; // ”станавливаем значение "построено" в true при создании башни
            }
            Destroy(gameObject);
            isButtonClicked = false;
        }
    }

    private void Update()
    {
        // ≈сли башн€ существует и движетс€, установить isBuilding в true.
        // ≈сли башн€ удалена, установить isBuilding в false.
        isBuilding = buildScript.currentTower != null && buildScript.isBuilding;

        // ”становить isButtonClicked равным isBuilding
        isButtonClicked = isBuilding;
    }
}