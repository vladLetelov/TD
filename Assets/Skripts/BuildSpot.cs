using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    public Build buildScript;
    public GameObject TowerPrefab;
    public bool isButtonClicked = false;
    public bool isBuilding = false; // ���������� ��� ������������ �������� �����.

    private void OnMouseDown()
    {
        if (isButtonClicked)
        {
            GameObject tower = Instantiate(TowerPrefab, transform.position, Quaternion.identity);
            TowerScript towerScript = tower.GetComponent<TowerScript>();
            if (towerScript != null)
            {
                towerScript.isBuilt = true; // ������������� �������� "���������" � true ��� �������� �����
            }
            Destroy(gameObject);
            isButtonClicked = false;
        }
    }

    private void Update()
    {
        // ���� ����� ���������� � ��������, ���������� isBuilding � true.
        // ���� ����� �������, ���������� isBuilding � false.
        isBuilding = buildScript.currentTower != null && buildScript.isBuilding;

        // ���������� isButtonClicked ������ isBuilding
        isButtonClicked = isBuilding;
    }
}