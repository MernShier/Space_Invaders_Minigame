using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField] private Score score;
    [SerializeField] private EnemyArmy enemyArmy;
    [SerializeField] private Texts texts;
    [SerializeField] private WinLose winLose;
    private void Start()
    {
        var o = GameObject.FindGameObjectWithTag("Manager");
        texts = o.GetComponent<Texts>();
        winLose = o.GetComponent<WinLose>();
        score = o.GetComponent<Score>();
        enemyArmy = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyArmy>();
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
        score.score+=score.scorePerKill;
        enemyArmy.enemies--;
        texts.ScoreTextUpdate();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerLine"))
        {
            winLose.GameLose();
        }
    }
}
