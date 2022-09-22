using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private Texts texts;

    private void Start()
    {
        texts = GameObject.FindObjectOfType<Texts>();
    }

    private void Update()
    {
        var o = gameObject;
        var position = o.transform.position;
        position = new Vector3(position.x, position.y - bulletSpeed, position.z);
        o.transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().PlayerCombat.PlayerHealth -= bulletDamage;
            col.GetComponent<Player>().PlayerHealthCheck();
            texts.PlayerHealthUIUpdate();
            gameObject.SetActive(false);
        }   
        if (col.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}
