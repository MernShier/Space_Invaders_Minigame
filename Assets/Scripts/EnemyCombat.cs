using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCombat : MonoBehaviour
{
    private readonly System.Random _rnd = new System.Random();
    [SerializeField] private EnemyArmy enemyArmy;
    public float minReload, maxReload;
    [SerializeField] private float reloadTime, enemyBulletPoolAmount;
    [SerializeField] private GameObject[] enemies, bullets;
    [SerializeField] private GameObject bullet, enemyBulletsPool;
    [SerializeField] private int bulletCounter;
    private void Start()
    {
        enemyBulletPoolAmount = (int)enemyArmy.effectivBulletAmountValue;
        bullets = new GameObject[(int)enemyBulletPoolAmount];
        for (int i = 0; i < (int)enemyBulletPoolAmount; i++)
        {
            bullets[i] = Instantiate(bullet, enemyBulletsPool.transform.position, Quaternion.identity, enemyBulletsPool.transform);
            bullets[i].SetActive(false);
        }
        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        while (true)
        {
            reloadTime = Random.Range(minReload, maxReload);
            yield return new WaitForSeconds(reloadTime);
            Shoot(GetShootingEnemy());
        }
    }
    private GameObject GetShootingEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies[_rnd.Next(0, enemies.Length)];
    }
    private void Shoot(GameObject shootingEnemy)
    {
        bullets[bulletCounter].transform.position = shootingEnemy.transform.position;
        bullets[bulletCounter].SetActive(true);
        if (bulletCounter < enemyBulletPoolAmount)
        {
            bulletCounter++;
        }
        if (bulletCounter == (int)enemyBulletPoolAmount)
        {
            bulletCounter = 0;
        }
    }
}