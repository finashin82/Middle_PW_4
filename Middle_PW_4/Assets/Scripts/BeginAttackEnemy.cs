using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BeginAttackEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] startPoint;

    [SerializeField] private GameObject enemy;

    [SerializeField] private int countEnemy = 10;

    [SerializeField] private float timeToAttack = 1f;

    private int currentEnemy;

    private float currentTime;    

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

            // Создаем префаб в случайной позиции из массива позиций
            var prefab = Instantiate(enemy, startPoint[randPoint].position, Quaternion.identity);

            // Разворот префаба на 180 по оси Y            
            prefab.transform.rotation = Quaternion.AngleAxis(180, Vector3.up); ;

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
