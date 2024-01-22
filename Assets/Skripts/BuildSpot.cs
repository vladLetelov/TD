using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    public Build buildScript;
    public GameObject TowerPrefab;
    public bool isButtonClicked = false;
    public bool isBuilding = false; // Переменная для отслеживания движения башни.
    public GameObject BuildSpotPrefab;

    private void OnMouseDown()
    {
        if (isButtonClicked && buildScript.coinCounter.coinCount >= (buildScript.currentTower.towerType == TowerType.Type1 ? 100 : 200))
        {
            GameObject tower = Instantiate(TowerPrefab, transform.position, Quaternion.identity);
            TowerScript towerScript = tower.GetComponent<TowerScript>();
            if (towerScript != null)
            {
                towerScript.isBuilt = true; // Устанавливаем значение "построено" в true при создании башни
            }
            Destroy(gameObject);
            isButtonClicked = false;

            // Вычитаем монеты только после успешного размещения башни
            buildScript.coinCounter.coinCount -= buildScript.currentTower.towerType == TowerType.Type1 ? 100 : 200;
            buildScript.coinCounter.UpdateCoinText();
        }
    }

    private void OnMouseRightClick()
    {
        Destroy(gameObject);
        Instantiate(BuildSpotPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform == this.transform)
                {
                    OnMouseRightClick();
                }
            }
        }

        // Если башня существует и движется, установить isBuilding в true.
        // Если башня удалена, установить isBuilding в false.
        isBuilding = buildScript.currentTower != null && buildScript.isBuilding;

        // Установить isButtonClicked равным isBuilding
        isButtonClicked = isBuilding;

        // Проверка, что ПКМ было нажато на башню
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform == this.transform)
                {
                    Debug.Log("Right-clicked on tower");
                }
            }
        }
    }
}
