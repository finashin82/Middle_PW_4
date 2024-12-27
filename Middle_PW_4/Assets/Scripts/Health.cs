using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float health = 50f;

    private Animator animator;

    private Collider col;

    private bool isInvoke = false;

    private float timeDaed = 2f;

    private void Start()
    {
        animator = GetComponent<Animator>();

        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (health <= 0 && !isInvoke)
        {
            EventController.onScore?.Invoke();            

            col.enabled = false;

            animator.SetBool("isDead", true);

            Invoke("Dead", timeDaed);

            isInvoke = true;       
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

    /// <summary>
    /// Уничтожение объекта
    /// </summary>
    private void Dead()
    {
        Destroy(this.gameObject);
    }
}
