using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private MainGameManager mainGameManager;
    [SerializeField] private EnemyArmy enemyArmy;
    [SerializeField] private Texts texts;
    [SerializeField] private GameConditions gameConditions;
    private void Start()
    {
        var o = GameObject.FindGameObjectWithTag("Manager");
        texts = o.GetComponent<Texts>();
        gameConditions = o.GetComponent<GameConditions>();
        mainGameManager = o.GetComponent<MainGameManager>();
        enemyArmy = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyArmy>();
        
        health = mainGameManager.enemyHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        mainGameManager.score+=mainGameManager.scorePerKill;
        enemyArmy.enemies--;
        texts.ScoreTextUpdate();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerLine"))
        {
            gameConditions.GameLose();
        }
    }
}
