using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    public Build buildScript;
    public GameObject TowerPrefab;
    public bool isButtonClicked = false;
    public bool isBuilding = false; // ѕеременна€ дл€ отслеживани€ движени€ башни.

    private void OnMouseDown()
    {
        if (isButtonClicked && buildScript.coinCounter.coinCount >= (buildScript.currentTower.towerType == TowerType.Type1 ? 100 : 200))
        {
            GameObject tower = Instantiate(TowerPrefab, transform.position, Quaternion.identity);
            TowerScript towerScript = tower.GetComponent<TowerScript>();
            if (towerScript != null)
            {
                towerScript.isBuilt = true; // ”станавливаем значение "построено" в true при создании башни
            }

            isButtonClicked = false;

            // ¬ычитаем монеты только после успешного размещени€ башни
            buildScript.coinCounter.coinCount -= buildScript.currentTower.towerType == TowerType.Type1 ? 100 : 200;
            buildScript.coinCounter.UpdateCoinText();
        }
    }

    private void Update()
    {
        // ”становите isBuilding равным значению переменной isBuilding в скрипте Build.
        isBuilding = buildScript.isBuilding;

        // ”становите isButtonClicked в true, если isBuilding равно true. ¬ противном случае, установите значение isButtonClicked в false.
        isButtonClicked = isBuilding;
    }
}
