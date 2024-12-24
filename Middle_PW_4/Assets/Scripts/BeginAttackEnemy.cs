using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BeginAttackEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] startPoint;

    [SerializeField] private GameObject enemy;

    [SerializeField] private int countEnemy = 10;

    private int currentEnemy;

    private float currentTime;

    private float timeToAttack = 1f;

    private int randPoint;

    private bool isAttack = false;

    void Start()
    {
        currentEnemy = countEnemy;

        currentTime = timeToAttack;
    }
    
    void FixedUpdate()
    {
        if (currentTime > 0f && !isAttack) 
        {        
            currentTime -= Time.deltaTime;
        }
        else
        {
            isAttack = true;

            currentTime = timeToAttack;
        }

        if (isAttack && currentEnemy < countEnemy)
        {
            randPoint = Random.Range(0, startPoint.Length);

            Instantiate(enemy, startPoint[randPoint].position, Quaternion.identity);

            isAttack = false;

            currentEnemy++;
        }
    }

    public void BeginAttack()
    {
        isAttack = true;

        currentEnemy = 0;
    }
}
