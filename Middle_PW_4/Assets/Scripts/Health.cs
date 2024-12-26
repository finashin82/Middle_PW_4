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

    /// <summary>
    /// Нанесение урона
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
