using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // скорость пули
    public int damage = 50; // урон от пули
    private GameObject target; // цель пули

    // метод для установки цели пули
    public void Seek(GameObject _target)
    {
        target = _target;
    }

    // обновление позиции пули каждый кадр
    void Update()
    {
        if (target == null) // если цель не существует, удалить пулю
        {
            Destroy(gameObject);
            return;
        }

        // движение пули к цели
        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) // если пуля достигла цели
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        // расчет угла поворота
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle); // применить угол поворота
    }




    // обработка попадания в цель
    void HitTarget()
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            health.TakeHit(damage);
        }

        Destroy(gameObject); // уничтожить пулю после попадания
    }
}
