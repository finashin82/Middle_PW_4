using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float health = 50f;
    
    void Update()
    {
        if (health <= 0)
        {
            EventController.onRecord?.Invoke();

            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
