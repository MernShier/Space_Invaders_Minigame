using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public GameObject player, firePoint;
    [SerializeField] public GameObject[] playerBullets;
    [SerializeField] private GameConditions gameConditions;
    [SerializeField] public float playerBorders, playerSpeed;
    public readonly PlayerMovement PlayerMovement = new PlayerMovement();
    public readonly PlayerCombat PlayerCombat = new PlayerCombat();
    public void PlayerHealthCheck()
    {
        if (PlayerCombat.PlayerHealth <= 0 && gameConditions.lost != true)
        {
            gameConditions.GameLose();
        }
    }
}