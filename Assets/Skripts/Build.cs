using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public TowerScript currentTower;
    public GameObject TowerPrefab;
    public List<GameObject> buildSpots;
    public bool isBuilding = false; // ������� �������������
    private bool hasBuiltTower = false;

    public void OnButtonClick()
    {
        if (hasBuiltTower) // ���� ��� ��������� �����
        {
            Destroy(currentTower.gameObject); // ������� ������� �����
            currentTower = null; // �������� ������ �� �����
            hasBuiltTower = false; // ���������� ���� ����������� �����
        }
        else
        {
            if (!isBuilding) // ���� �� ��������� � ������ �������������
            {
                isBuilding = true;
                Vector3 mousePosition = GetMousePosition();
                currentTower = Instantiate(TowerPrefab, mousePosition, Quaternion.identity).GetComponent<TowerScript>();
                currentTower.MoveTo(mousePosition);
            }
            else // ���� ��� ��������� � ������ �������������
            {
                isBuilding = false; // ��������� ����� �������������
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

        if (Input.GetMouseButtonDown(0) && isBuilding) // ���� ������ ����� ������ ���� � ��������� � ������ �������������
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // ���� ��� ���������� ���-��
            {
                if (buildSpots.Contains(hit.collider.gameObject)) // ���� ��� ������ ��� �����
                {
                    currentTower.PlaceTower(hit.transform.position);
                    hasBuiltTower = true; // ������������� ���� ����������� ����� � true
                }
            }
            else // ���� ��� �� ���������� ������ ��� �����
            {
                Destroy(currentTower.gameObject); // ������� ������� �����
                currentTower = null; // �������� ������ �� �����
            }
            isBuilding = false; // ���������� ���� ������ ������������� � false ����� ������� ������� ����
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector2 screenPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));

        return worldPosition;
    }
}

