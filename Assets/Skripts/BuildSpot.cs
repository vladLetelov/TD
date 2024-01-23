using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    public Build buildScript;
    public GameObject TowerPrefab;
    public bool isButtonClicked = false;
    public bool isBuilding = false; // ���������� ��� ������������ �������� �����.

    private void OnMouseDown()
    {
        if (isButtonClicked && buildScript.coinCounter.coinCount >= (buildScript.currentTower.towerType == TowerType.Type1 ? 100 : 200))
        {
            GameObject tower = Instantiate(TowerPrefab, transform.position, Quaternion.identity);
            TowerScript towerScript = tower.GetComponent<TowerScript>();
            if (towerScript != null)
            {
                towerScript.isBuilt = true; // ������������� �������� "���������" � true ��� �������� �����
            }

            isButtonClicked = false;

            // �������� ������ ������ ����� ��������� ���������� �����
            buildScript.coinCounter.coinCount -= buildScript.currentTower.towerType == TowerType.Type1 ? 100 : 200;
            buildScript.coinCounter.UpdateCoinText();
        }
    }

    private void Update()
    {
        // ���������� isBuilding ������ �������� ���������� isBuilding � ������� Build.
        isBuilding = buildScript.isBuilding;

        // ���������� isButtonClicked � true, ���� isBuilding ����� true. � ��������� ������, ���������� �������� isButtonClicked � false.
        isButtonClicked = isBuilding;
    }
}
