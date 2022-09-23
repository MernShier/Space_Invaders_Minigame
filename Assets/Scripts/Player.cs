using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public GameObject player, firePoint;
    [SerializeField] public GameObject[] playerBullets;
    [SerializeField] private WinLose winLose;
    [SerializeField] public float playerBorders, playerSpeed;
    public readonly PlayerMovement PlayerMovement = new PlayerMovement();
    public readonly PlayerCombat PlayerCombat = new PlayerCombat();
    public void PlayerHealthCheck()
    {
        if (PlayerCombat.PlayerHealth <= 0 && winLose.lost != true)
        {
            winLose.GameLose();
        }
    }
}