using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    void Update()
    {
        var o = gameObject;
        var position = o.transform.position;
        position = new Vector3(position.x, position.y + bulletSpeed, position.z);
        o.transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Enemy>().health -= bulletDamage;
            gameObject.SetActive(false);
        }   
        if (col.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}