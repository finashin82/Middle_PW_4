using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float health = 50f;
    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
