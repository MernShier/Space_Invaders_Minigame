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
    private float _reloadTime;
    private int _effectiveBulletAmountValue, _bulletCounter;
    [SerializeField] private GameObject[] enemies, bullets;
    [SerializeField] private GameObject bullet, enemyBulletsPool;
    private void Start()
    {
        _effectiveBulletAmountValue = (int)(enemyArmy.enemies / ((maxReload + minReload) / 2) * (enemyArmy.stepValue / enemyArmy.stepTime) * 3 + 5);
        bullets = new GameObject[_effectiveBulletAmountValue];
        for (int i = 0; i < _effectiveBulletAmountValue; i++)
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
            _reloadTime = Random.Range(minReload, maxReload);
            yield return new WaitForSeconds(_reloadTime);
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
        bullets[_bulletCounter].transform.position = shootingEnemy.transform.position;
        bullets[_bulletCounter].SetActive(true);
        if (_bulletCounter < _effectiveBulletAmountValue)
        {
            _bulletCounter++;
        }
        if (_bulletCounter == _effectiveBulletAmountValue)
        {
            _bulletCounter = 0;
        }
    }
}