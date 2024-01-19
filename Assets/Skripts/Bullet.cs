using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // �������� ����
    public int damage = 50; // ���� �� ����
    private GameObject target; // ���� ����

    // ����� ��� ��������� ���� ����
    public void Seek(GameObject _target)
    {
        target = _target;
    }

    // ���������� ������� ���� ������ ����
    void Update()
    {
        if (target == null) // ���� ���� �� ����������, ������� ����
        {
            Destroy(gameObject);
            return;
        }

        // �������� ���� � ����
        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) // ���� ���� �������� ����
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        // ������ ���� ��������
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle); // ��������� ���� ��������
    }




    // ��������� ��������� � ����
    void HitTarget()
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            health.TakeHit(damage);
        }

        Destroy(gameObject); // ���������� ���� ����� ���������
    }
}
