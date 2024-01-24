using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public int health = 200;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
