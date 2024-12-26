using System.IO.Pipes;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Rendering;

public class FireBullet : InputData
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private float rayDistance = 10f;

    [SerializeField] private float speedBullet = 20f;

    private RaycastHit hit;

    private float currentTime;

    private float timeToAttack = 0.2f;

    private bool isTime;

    void Start()
    {
        currentTime = timeToAttack;
    }

    void Update()
    {
        RaycastRender();

        if (currentTime > 0f && !isTime)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            isTime = true;

            currentTime = timeToAttack;
        }

        if (isAttack && isTime)
        {
            Shoot();

            isTime = false;
        }
    }

    /// <summary>
    /// —оздание луча и его визуализаци€
    /// </summary>
    void RaycastRender()
    {
        Physics.Raycast(transform.position, transform.forward, out hit, rayDistance);

        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, hit.point);
    }

    /// <summary>
    /// ¬ыстрел в направлении луча
    /// </summary>
    void Shoot()
    {   if (hit.normal != Vector3.zero)
        {
            // —оздаем экземпл€р и разворачиваем его в направлении луча
            var fire = Instantiate(bullet, transform.position, Quaternion.LookRotation(hit.normal));

            // ƒвигаем вперед использу€ локальные координаты
            fire.GetComponent<Rigidbody>().linearVelocity += transform.forward * speedBullet;
        }
    }
}
