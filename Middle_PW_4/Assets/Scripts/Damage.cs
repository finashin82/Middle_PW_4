using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealth ihealth))
        {
            ihealth.TakeDamage(damage);
        }
    }
}
