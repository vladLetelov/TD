using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    public Build buildScript;
    public GameObject TowerPrefab;
    public bool isButtonClicked = false;
    public bool isBuilding = false; // ���������� ��� ������������ �������� �����.
    public GameObject BuildSpotPrefab;

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
            Destroy(gameObject);
            isButtonClicked = false;

            // �������� ������ ������ ����� ��������� ���������� �����
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

        // ���� ����� ���������� � ��������, ���������� isBuilding � true.
        // ���� ����� �������, ���������� isBuilding � false.
        isBuilding = buildScript.currentTower != null && buildScript.isBuilding;

        // ���������� isButtonClicked ������ isBuilding
        isButtonClicked = isBuilding;

        // ��������, ��� ��� ���� ������ �� �����
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
