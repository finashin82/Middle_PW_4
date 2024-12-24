using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speedEnemy;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(0, 0, -speedEnemy * Time.deltaTime);
    }
}
